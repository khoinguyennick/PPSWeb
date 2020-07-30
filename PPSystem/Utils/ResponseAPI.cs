using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PPSystem.Utils
{
    public interface IResponseAPI
    {
        StringContent GetContent<T>(T data);
        Task<T> ReadAsJsonAsync<T>(HttpContent content);
    }
    public class ResponseAPI : IResponseAPI
    {
        /// <summary>
        /// Link of host API
        /// </summary>
        [Required]
        public string APIHost { get; set; }
        private HttpClient client = new HttpClient();

        internal object GetContent<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ResponseAPI()
        {
            var apiHost = Environment.GetEnvironmentVariable("_responseAPI.APIHost");
            if (string.IsNullOrEmpty(apiHost))
                apiHost = "https://api-ppsystem.tvvs.xyz/";
            APIHost = apiHost;
        }

        public HttpClient Initial()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(APIHost)
            };
            return client;
        }

        /// <summary>
        /// Convert Content To String Content
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public StringContent GetContent<T>(T data)
        {
            var dataConvert = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataConvert, UnicodeEncoding.UTF8, "application/json");
            return content;
        }

        /// <summary>
        /// Read Json as Convert To Data
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="content">HttpContent</param>
        /// <returns></returns>
        public async Task<T> ReadAsJsonAsync<T>(HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }

        /// <summary>
        /// Method GET Async
        /// </summary>
        /// <typeparam name="T">Type of Data</typeparam>
        /// <param name="path">Path of API</param>
        /// <returns></returns>
        public async Task<T> GetTAsync<T>(string path) where T : class
        {
            T result = null;
            using (client = Initial())
            {
                try
                {
                    HttpResponseMessage rs = await client.GetAsync(path);
                    if (rs.IsSuccessStatusCode)
                    {
                        result = await ReadAsJsonAsync<T>(rs.Content);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
    }
}
