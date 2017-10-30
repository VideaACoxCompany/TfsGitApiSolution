using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TfsGitApiProject.Entities;

namespace TfsGitApiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetProjects();
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        

        public static async void GetProjects()
        {
            try
            {
                var personalaccesstoken = "4lck6b2fcjnfrddl5tpiru356xbkb2chgo4du4nirhor4fxmmqka";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = client.GetAsync(
                        "https://tfs.videa.tv/tfs/Videa/_apis/projects").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<Project>(responseBody);

                        
                        result.Value.ForEach(i => Console.WriteLine(i.Name));
                        //Console.WriteLine($"Projects:  {string.Join(",", result.Value.Select(i => i.Name))}");

                        //Console.WriteLine(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

}