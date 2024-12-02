using OneBlink.SDK.Model;
using System;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OneBlink.SDK
{
    internal class AssetUploadRequest
    {
        [JsonProperty]
        internal string fileName
        {
            get; set;
        }
    }

    internal class AssetUploadResponse : S3UploadResponse
    {
        [JsonProperty]
        internal string url
        {
            get; set;
        }
    }

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
            OrganiationsSearchResult searchResult = await this.oneBlinkApiClient.GetRequest<OrganiationsSearchResult>("/organisations");
            if (searchResult.organisations.Count != 1)
            {
                throw new ArgumentException("You do not have access to any organisations");
            }

            AssetUploadRequest assetUploadRequest = new AssetUploadRequest()
            {
                fileName = Uri.EscapeDataString(assetFileName)
            };
            string key = "organisations/" + searchResult.organisations[0].id + "/assets";
            AssetUploadResponse assetUploadResponse = await this.oneBlinkApiClient.Upload<AssetUploadRequest, AssetUploadResponse>(key, assetDataStream, contentType, assetUploadRequest, isPublic: true);

            return assetUploadResponse.url;
        }

        public async Task<Organisation> GetOrganisation(string id)
        {
            string url = "/organisations/" + id;
            return await this.oneBlinkApiClient.GetRequest<Organisation>(url);
        }
    }
}