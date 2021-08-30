using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OneBlink.SDK.Model;

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

        public async Task<T> GetRequest<T>(string path, IDictionary<string, string> searchParams)
        {
            string url = path + CreateQueryString(searchParams);
            return await GetRequest<T>(url);
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

        public async Task<HttpContent> DeleteRequest(string path, IDictionary<string, string> searchParams)
        {
            string url = path + CreateQueryString(searchParams);
            return await DeleteRequest(url);
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

        public async Task<Tout> PutRequest<T, Tout>(string path, IDictionary<string, string> searchParams, T t)
        {
            string url = path + CreateQueryString(searchParams);
            return await PutRequest<T, Tout>(url, t);
        }
    }
}