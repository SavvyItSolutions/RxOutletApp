using Newtonsoft.Json;
using RxOutlet.Models;
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
           

        public async Task<RegistrationResponseModel> Registration(RegistrationModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "Registration");
                var content = JsonConvert.SerializeObject(model);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont);
                var output = await response.Content.ReadAsStringAsync();

                var x = JsonConvert.DeserializeObject<RegistrationResponseModel>(output);
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> Login(LoginModel model)
        {
            try
            {
                var uri = new Uri(ServiceURL + "Login");
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
