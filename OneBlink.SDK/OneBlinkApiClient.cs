using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneBlink.SDK.Model;
using System.IO;
using Amazon.Runtime;
using System.Threading;
using System.Collections.Specialized;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.S3;
using Amazon.S3.Model;
using System.Net.Mime;

namespace OneBlink.SDK
{
    internal class OneBlinkApiClient : OneBlinkHttpClient
    {
        internal Tenant tenant;

        public OneBlinkApiClient(string accessKey, string secretKey, Tenant tenant, int expiryInSeconds = 300)
          : base(accessKey, secretKey, expiryInSeconds)
        {
            this.tenant = tenant ?? new Tenant(TenantName.ONEBLINK);
        }

        public async Task<T> PostRequest<T>(string path)
        {
            return await PostRequest<object, T>(path, null);
        }

        public async Task<Tout> PostRequest<T, Tout>(string path, T t)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, tenant.oneBlinkAPIOrigin + path);
            if (t != null)
            {
                string jsonPayload = JsonConvert.SerializeObject(t, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                httpRequestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            }
            return await SendRequest<Tout>(httpRequestMessage);
        }

        public async Task<T> GetRequest<T>(string path)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, tenant.oneBlinkAPIOrigin + path);
            return await SendRequest<T>(httpRequestMessage);
        }

        public async Task<Stream> GetStreamRequest(string path)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, tenant.oneBlinkAPIOrigin + path);
            return await StreamRequest(httpRequestMessage);
        }

        public async Task<T> GetRequest<T>(string path, string userToken)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, tenant.oneBlinkAPIOrigin + path);
            return await SendRequest<T>(httpRequestMessage, userToken);
        }

        public async Task<HttpContent> DeleteRequest(string path)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, tenant.oneBlinkAPIOrigin + path);
            return await SendRequest(httpRequestMessage);
        }

        public async Task<Tout> PutRequest<T, Tout>(string path, T t)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, tenant.oneBlinkAPIOrigin + path);
            if (t != null)
            {
                string jsonPayload = JsonConvert.SerializeObject(t, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                httpRequestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            }
            return await SendRequest<Tout>(httpRequestMessage);
        }

        private class CustomHttpClientFactory : HttpClientFactory
        {
            private HttpClient client;

            public CustomHttpClientFactory(HttpClient client)
            {
                this.client = client;
            }
            public override HttpClient CreateHttpClient(IClientConfig clientConfig)
            {
                return client;
            }
            public override bool UseSDKHttpClientCaching(IClientConfig clientConfig)
            {
                // return false to indicate that the SDK should not cache clients internally
                return false;
            }
            public override bool DisposeHttpClientsAfterUse(IClientConfig clientConfig)
            {
                // return false to indicate that the SDK shouldn't dispose httpClients because they're cached in your pool
                return false;
            }
            public override string GetConfigUniqueString(IClientConfig clientConfig)
            {
                // has no effect because UseSDKHttpClientCaching returns false
                return null;
            }
        }

        private class CustomHttpMessageHandler<T, Tout> : DelegatingHandler
            where Tout : S3UploadResponse
        {
            private T requestBody;
            internal Tout oneblinkResponse;
            private OneBlinkApiClient oneBlinkApiClient;

            internal CustomHttpMessageHandler(OneBlinkApiClient _oneBlinkApiClient, T requestBody) : base(new HttpClientHandler())
            {
                this.oneBlinkApiClient = _oneBlinkApiClient;
                this.requestBody = requestBody;
            }

            protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
            {
                // Add authorisation headers
                httpRequestMessage.Headers.Remove("authorization");
                string token = Token.GenerateJSONWebToken(this.oneBlinkApiClient.accessKey, this.oneBlinkApiClient.secretKey, this.oneBlinkApiClient.expiryInSeconds);
                httpRequestMessage.Headers.Add("authorization", "Bearer " + token);

                // Add request body
                if (this.requestBody != null)
                {
                    string jsonPayload = JsonConvert.SerializeObject(this.requestBody, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    httpRequestMessage.Headers.Add("x-oneblink-request-body", jsonPayload);
                }

                // Add set querystring parameters for multi-part uploads
                NameValueCollection query = HttpUtility.ParseQueryString(httpRequestMessage.RequestUri.Query);
                query.Add("x-id", "PutObject");
                if (this.oneblinkResponse != null)
                {
                    query.Add("key", this.oneblinkResponse.s3.key);
                }
                UriBuilder uriBuilder = new UriBuilder(httpRequestMessage.RequestUri);
                uriBuilder.Query = query.ToString();
                httpRequestMessage.RequestUri = uriBuilder.Uri;

                HttpResponseMessage httpResponseMessage = await base.SendAsync(httpRequestMessage, cancellationToken);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    IEnumerable<string> results = httpResponseMessage.Headers.GetValues("x-oneblink-response");
                    string result = results.FirstOrDefault();
                    if (!String.IsNullOrEmpty(result))
                    {
                        this.oneblinkResponse = JsonConvert.DeserializeObject<Tout>(result);
                    }
                }
                else
                {
                    string result = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (httpResponseMessage.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        APIErrorResponse apiErrorResponse = JsonConvert.DeserializeObject<APIErrorResponse>(result);
                        throw new OneBlinkAPIException(apiErrorResponse);
                    }
                    throw new OneBlinkAPIException(httpResponseMessage.StatusCode, result);
                }

                return httpResponseMessage;
            }
        }

        internal async Task<Tout> Upload<Tout>(string key, Stream stream, string contentType)
          where Tout : S3UploadResponse
        {
            return await this.Upload<object, Tout>(key, stream, contentType, requestBody: null, isPublic: false, disposition: null);
        }

        internal async Task<S3UploadResponse> Upload<T>(string key, Stream stream, string contentType, T requestBody, ContentDisposition disposition)
        {
            return await this.Upload<T, S3UploadResponse>(key, stream, contentType, requestBody, isPublic: false, disposition);
        }

        internal async Task<Tout> Upload<T, Tout>(string key, Stream stream, string contentType, T requestBody, bool isPublic)
          where Tout : S3UploadResponse
        {
            return await this.Upload<T, Tout>(key, stream, contentType, requestBody, isPublic, disposition: null);
        }

        internal async Task<Tout> Upload<T, Tout>(string key, Stream stream, string contentType, T requestBody, bool isPublic, ContentDisposition disposition)
          where Tout : S3UploadResponse
        {
            CustomHttpMessageHandler<T, Tout> customHttpMessageHandler = new CustomHttpMessageHandler<T, Tout>(this, requestBody);
            HttpClient httpClient = new HttpClient(customHttpMessageHandler);
            CustomHttpClientFactory customHttpClientFactory = new CustomHttpClientFactory(httpClient);

            // The endpoint we use instead of the the AWS S3 endpoint is
            // formatted internally by the AWS S3 SDK. It will add the Bucket
            // parameter below as the subdomain to the URL (as long as the
            // bucket does not contain a `.`). The logic below allows the final
            // URL used to upload the object to be the origin that is passed in.
            // The suffix on the end is important as it will allow us to route
            // traffic to S3 via lambda at edge instead of going to our API.
            UriBuilder oneBlinkAPIUriBuilder = new UriBuilder(this.tenant.oneBlinkAPIOrigin);
            string[] hostParts = oneBlinkAPIUriBuilder.Host.Split('.');
            string bucketName = hostParts[0];
            oneBlinkAPIUriBuilder.Host = string.Join(".", hostParts.Skip(1));

            AmazonS3Config config = new AmazonS3Config()
            {
                ServiceURL = oneBlinkAPIUriBuilder.ToString() + "storage",
                HttpClientFactory = customHttpClientFactory
            };
            AmazonS3Client amazonS3Client = new AmazonS3Client(null, config);

            PutObjectRequest request = new PutObjectRequest
            {
                BucketName = bucketName,
                Key = key,
                InputStream = stream,
                ContentType = contentType,
                CannedACL = S3CannedACL.BucketOwnerFullControl,
                ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
            };
            if (disposition != null)
            {
                request.Headers.ContentDisposition = disposition.ToString();
            }
            request.Headers.Expires = new DateTime().AddYears(1); // Max 1 year
            request.Headers.CacheControl = "max-age=31536000"; // Max 1 year(365 days)
            if (isPublic)
            {
                request.TagSet = new List<Tag>
                {
                    new Tag()
                    {
                        Key = "public-read",
                        Value = "yes"
                    }
                };
            }

            await amazonS3Client.PutObjectAsync(request);

            return customHttpMessageHandler.oneblinkResponse;
        }
    }
}