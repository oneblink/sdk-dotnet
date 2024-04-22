using System;
using System.Threading.Tasks;
using OneBlink.SDK.Model;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace OneBlink.SDK
{
    internal class PreFillUploadResponse : S3UploadResponse
    {
        [JsonProperty]
        internal Guid preFillFormDataId
        {
            get; set;
        }
    }

    internal class PrefillClient
    {
        OneBlinkApiClient oneBlinkApiClient;

        internal PrefillClient(OneBlinkApiClient oneBlinkApiClient)
        {
            this.oneBlinkApiClient = oneBlinkApiClient;
        }

        internal async Task<Guid> SetPreFillData<T>(T preFillData, long formId)
        {
            string key = "forms/" + formId.ToString() + "/pre-fill";
            string serializedJson = JsonConvert.SerializeObject(preFillData);
            byte[] byteArray = Encoding.UTF8.GetBytes(serializedJson);
            Stream stream = new MemoryStream(byteArray);
            PreFillUploadResponse preFillUploadResponse = await this.oneBlinkApiClient.Upload<PreFillUploadResponse>(key, stream, "application/json");
            return preFillUploadResponse.preFillFormDataId;
        }
    }
}
