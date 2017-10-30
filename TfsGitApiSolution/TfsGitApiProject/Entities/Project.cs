﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TfsGitApiProject.Entities
{
    public class Project
    {
        public int Count { get; set; }
        public List<ProjectItem> Value { get; set; }
    }

    public class ProjectItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
