using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using TfsGitApiProject.Entities;
using TfsGitApiProject.Services;

namespace TfsGitApiProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetResults();
            Console.Read();
        }

        

        public static async void GetResults()
        {
            try
            {
                //ProjectService projectService = new ProjectService();
                //var projects = await projectService.GetResult();
                //projects.Value.ForEach(i => Console.WriteLine(i.Name));

                //RepoService repoService = new RepoService();
                //var repos = await repoService.GetResult();
                //repos.Value.ForEach(i => Console.WriteLine(i.Name + " " + i.Id));

                //var repoId = repoService.FindId("avail-gateway-svc");

                var gitStatService = new GitStatsService();
                var gitStat = await gitStatService.GetResult();
                gitStat.Value.ForEach(i => Console.WriteLine($"{i.Name} ahead {i.AheadCount} behind {i.BehindCount}"));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }

}