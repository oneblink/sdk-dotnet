using System;
using OneBlink.SDK.Model;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System.IO;

namespace OneBlink.SDK
{
    public class OrganisationsClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        public OrganisationsClient(string accessKey, string secretKey, TenantName tenantName = TenantName.ONEBLINK)
        {
            this.oneBlinkApiClient = new OneBlinkApiClient(
                accessKey,
                secretKey,
                tenant: new Tenant(tenantName)
            );
        }

        public async Task<string> UploadAsset(Stream assetDataStream, string contentType, string assetFileName)
        {
            string getUrl = "/organisations";
            OrganiationsSearchResult searchResult = await this.oneBlinkApiClient.GetRequest<OrganiationsSearchResult>(getUrl);
            if (searchResult.organisations.Count != 1)
            {
                throw new ArgumentException("You do not have access to any organisations");
            }
            string postUrl = "/asset-upload-credentials";
            AssetUploadCredentialsRequest assetUploadCredentialsRequest = new AssetUploadCredentialsRequest();
            assetUploadCredentialsRequest.assetPath = "assets/" + assetFileName;
            assetUploadCredentialsRequest.organisationId = searchResult.organisations[0].id;
            AssetUploadCredentialsResponse assetUploadCredentialsResponse = await this.oneBlinkApiClient.PostRequest<AssetUploadCredentialsRequest, AssetUploadCredentialsResponse>(postUrl, assetUploadCredentialsRequest);
            RegionEndpoint regionEndpoint = RegionEndpoint.GetBySystemName(assetUploadCredentialsResponse.s3.region);

            SessionAWSCredentials sessionAWSCredentials = new SessionAWSCredentials(
                assetUploadCredentialsResponse.credentials.AccessKeyId,
                assetUploadCredentialsResponse.credentials.SecretAccessKey,
                assetUploadCredentialsResponse.credentials.SessionToken
            );
            AmazonS3Client amazonS3Client = new AmazonS3Client(sessionAWSCredentials, regionEndpoint);
            PutObjectRequest request = new PutObjectRequest
            {
                BucketName = assetUploadCredentialsResponse.s3.bucket,
                Key = assetUploadCredentialsResponse.s3.key,
                InputStream = assetDataStream,
                ContentType = contentType,
                CannedACL = S3CannedACL.PublicRead,
                ServerSideEncryptionMethod = ServerSideEncryptionMethod.AES256,
            };
            request.Headers.ExpiresUtc = new DateTime().AddYears(1).ToUniversalTime(); // Max 1 year
            request.Headers.CacheControl = "max-age=31536000"; // Max 1 year(365 days)

            await amazonS3Client.PutObjectAsync(request);
            return string.Format("https://s3.{0}.amazonaws.com/{1}/{2}", assetUploadCredentialsResponse.s3.region, assetUploadCredentialsResponse.s3.bucket, assetUploadCredentialsResponse.s3.key);
        }

        public async Task<Organisation> GetOrganisation(string id)
        {
            string url = "/organisations/" + id;
            return await this.oneBlinkApiClient.GetRequest<Organisation>(url);
        }
    }
}