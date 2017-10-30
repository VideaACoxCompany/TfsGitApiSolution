using System;
using System.Collections.Generic;
using System.Text;

namespace TfsGitApiProject.Entities
{
    public class Repo
    {
        public List<RepoItem> Value { get; set; }
    }

    public class RepoItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ProjectItem Project { get; set; }

    }
}
