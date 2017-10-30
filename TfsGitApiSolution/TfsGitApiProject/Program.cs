using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TfsGitApiProject.Entities;
using TfsGitApiProject.Services;

namespace TfsGitApiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetProjects();
            Console.Read();
        }

        

        public static async void GetProjects()
        {
            try
            {
                ProjectService projectService = new ProjectService();
                var result = await projectService.GetResult();
                result.Value.ForEach(i => Console.WriteLine(i.Name));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

}