﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfsGitApiProject.Entities;

namespace TfsGitApiProject.Services
{
    public class RepoService
    {
        public async Task<Repo> GetResult()
        {
            var httpClientService = new HttpClientService();
            var result = await httpClientService.GetResponse<Repo>("https://tfs.videa.tv/tfs/Videa/_apis/git/repositories?api-version=1.0");
            return result;
        }

        public string FindId(string repoName)
        {
            var repos =  GetResult().Result;
            return repos.Value.First(i => i.Name == repoName).Id;
        }
    }
}
