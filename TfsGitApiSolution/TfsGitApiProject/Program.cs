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

            //GetWorkItems
            //var result = GetWorkItems();

            //Get Pull Requests
            //var result = GetPullRequests();

            //branches
            var result = GetResults().Result;

            //var emailer = new SmtpService();
            //emailer.SendEmail(result);
            Console.WriteLine("Success!");
            //Console.Read();
        }

        public static Task GetWorkItems()
        {
            var workItemService = new WorkItemService();
            var result = workItemService.GetResult();
            return Task.FromResult(0);
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
                var devReleaseBranches = new[] {"dev", "release"};


                var result = new StringBuilder();
                foreach (var repo in repos)
                {
                    result.AppendLine($"{repo.Key}  {repo.Value}");
                }

                foreach (var repo in repos)
                {
                    var gitStat = await gitStatService.GetResult(repo.Key);
                    var devReleaseBranchesStat = gitStat.Value.Where(i => devReleaseBranches.Contains(i.Name)).ToList();

                    devReleaseBranchesStat.ForEach(i =>
                        result.AppendLine(
                            $"Repo: {repo.Value} Branch {i.Name} is {i.BehindCount} commit(s) behind and {i.AheadCount} commit(s) ahead master branch"));

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