using System;
using System.Collections.Generic;
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

                RepoService repoService = new RepoService();
                //var repos = await repoService.GetResult();
                //repos.Value.ForEach(i => Console.WriteLine(i.Name + " " + i.Id));


                var repoNameList = new List<string> {"vom", "order-management", "support", "billing", "sellers", "sss-services", "data-integration"};

                //var repoId = repoService.FindId("vom");
                var repos = repoService.FindNameAndIds(repoNameList);

                var gitStatService = new GitStatsService();
                var branchesImInterested = new[] { "dev", "release-91" };

                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    //gitStat.Value.ForEach(i => Console.WriteLine($"Branch {i.Name} is {i.BehindCount} commit(s) behind master branch"));
                    gitStat.Value.Where(i => branchesImInterested.Contains(i.Name)).ToList().ForEach(i => Console.WriteLine($"Repo: {repo.Value} Branch {i.Name} is {i.BehindCount} commit(s) behind master branch"));

                }


                //send email
                //SmtpService smtpService = new SmtpService();
                //smtpService.SendEmail();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

    }

}