using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TfsGitApiProject.Services;

namespace TfsGitApiProject
{
    public class Program
    {
        static void Main(string[] args)
        {

            var result = GetPullRequests();


            //var result = GetResults().Result;

            //var emailer = new SmtpService();
            //emailer.SendEmail(result);
            Console.WriteLine("Success!");
            //Console.Read();
        }

        public static Task GetPullRequests()
        {
            var prService = new PullRequestService();
            var result = prService.GetResult();
            return Task.FromResult(0);
        }

        public static async Task<string> GetResults()
        {
            try
            {
                //Display all projects
                //ProjectService projectService = new ProjectService();
                //var projects = await projectService.GetResult();
                //projects.Value.ForEach(i => Console.WriteLine(i.Name));

                RepoService repoService = new RepoService();

                //Dispaly all repos
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
                var branchesInterested = new[] {"dev", "release"};


                var result = new StringBuilder();


                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    gitStat.Value.Where(i => branchesInterested.Contains(i.Name)).ToList().ForEach(i =>
                        //Console.WriteLine($"Repo: {repo.Value.PadRight(20)} Branch {i.Name.PadRight(20)} is {i.BehindCount.PadRight(5)} commit(s) behind master branch"));
                            result.AppendLine(
                                $"Repo: {repo.Value, -50} Branch {i.Name} is {i.BehindCount} commit(s) behind master branch"));

                }
                return result.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return string.Empty;
        }

        

    }

}