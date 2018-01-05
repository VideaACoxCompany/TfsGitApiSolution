using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
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

                RepoService repoService = new RepoService();
                //var repos = await repoService.GetResult();
                //repos.Value.ForEach(i => Console.WriteLine(i.Name + " " + i.Id));


                var repoNameList = new List<string>
                {
                    "vom",
                    "order-management",
                    "support",
                    "billing",
                    "sellers",
                    "sss-services",
                    "data-integration"
                };

                var repos = repoService.FindNameAndIds(repoNameList);

                var gitStatService = new GitStatsService();
                var branchesImInterested = new[] {"dev", "release-93"};

                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    gitStat.Value.Where(i => branchesImInterested.Contains(i.Name)).ToList().ForEach(i =>
                        Console.WriteLine($"Repo: {repo.Value.PadRight(20)} Branch {i.Name.PadRight(20)} is {i.BehindCount.PadRight(5)} commit(s) behind master branch"));

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

    }

}