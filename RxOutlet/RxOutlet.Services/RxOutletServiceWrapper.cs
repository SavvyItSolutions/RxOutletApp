//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Auth;
//using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using RxOutlet.Entity;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RxOutlet.Services
{
    public class RxOutletServiceWrapper
    {
        HttpClient client;
        public RxOutletServiceWrapper()
        {
            client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
        }
        
        public string ServiceURL
        {
            get
            {
                string host = "http://rxoutlet.azurewebsites.net/";
                return host + "api/RxOutlet/";
            }
        }
         
        public async Task<SignUpResponseModel> SignUp(SignUpModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "SignUp");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<SignUpResponseModel>(output);
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "Login");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont).ConfigureAwait(false);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<LoginResponse>(output);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UploadPrescription(UploadPrescriptionModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "UploadingPrescriptionNew");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont).ConfigureAwait(false);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<int>(output);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task UploadProfilePic(byte[] myByteArray, int i)
        {
            try
            {
                //StorageCredentials sc = new StorageCredentials("icsintegration", "+7UyQSwTkIfrL1BvEbw5+GF2Pcqh3Fsmkyj/cEqvMbZlFJ5rBuUgPiRR2yTR75s2Xkw5Hh9scRbIrb68GRCIXA==");
                //CloudStorageAccount storageaccount = new CloudStorageAccount(sc, true);
                //CloudBlobClient blobClient = storageaccount.CreateCloudBlobClient();
                //CloudBlobContainer container = blobClient.GetContainerReference("rxoutlet");
                //await container.CreateIfNotExistsAsync();
                ////string[] FileEntries = App.System.IO._dir.GetFiles(path);
                ////foreach (string FilePath in FileEntries)
                ////{
                //// string key = System.IO.Path.GetFileName(path);//.GetFileName(FilePath);
                //CloudBlockBlob blob = container.GetBlockBlobReference("Sample" + ".jpg"); //(path);
                //await blob.UploadFromByteArrayAsync(myByteArray, 0, i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UploadProfilePic(ByteArrayModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "ByteArray");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont).ConfigureAwait(false);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<int>(output);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UploadProfilePic_Array(Byte[] model, string extension, string userId)
        {
            try
            {
                ByteArrayModel byt = new ByteArrayModel();
                //byt.array = model;
                //byt.FileExtension = extension;
                //byt.userid = userId;
                var uri = new Uri(ServiceURL + "ByteArray");
                var content = JsonConvert.SerializeObject(byt);
                //var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont).ConfigureAwait(false);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<int>(output);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> TransferPrescription(TransferPrescriptionModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "TransferPrescription");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont).ConfigureAwait(false);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<int>(output);
                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
