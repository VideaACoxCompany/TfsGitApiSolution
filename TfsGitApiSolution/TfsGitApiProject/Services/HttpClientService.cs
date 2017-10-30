using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TfsGitApiProject.Entities;

namespace TfsGitApiProject.Services
{
    public class HttpClientService
    {
        public async Task<T> GetResponse<T>()
        {

            var personalaccesstoken = "4lck6b2fcjnfrddl5tpiru356xbkb2chgo4du4nirhor4fxmmqka";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", personalaccesstoken))));

                using (HttpResponseMessage response = client.GetAsync("https://tfs.videa.tv/tfs/Videa/_apis/projects").Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<T>(responseBody);


                    //result.Value.ForEach(i => Console.WriteLine(i.Name));
                    //Console.WriteLine($"Projects:  {string.Join(",", result.Value.Select(i => i.Name))}");
                    return result;
                    //Console.WriteLine(responseBody);
                }
            }
        }
    }
}
