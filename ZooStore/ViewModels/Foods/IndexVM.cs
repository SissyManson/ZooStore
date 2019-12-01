using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooStore.Entities;

namespace ZooStore.ViewModels.Foods
{
    public class IndexVM
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public List<Food> Items { get; set; }
    }
}