using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TfsGitApiProject.Entities;

namespace TfsGitApiProject.Services
{
    public class ProjectService
    {
        public async Task<Project> GetResult()
        {
            var httpClientService = new HttpClientService();
            var result = await httpClientService.GetResponse<Project>();
            //result.Value.ForEach(i => Console.WriteLine(i.Name));
            return result;
        }
        
    }
}
