using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZooStore.Entities;

namespace ZooStore.ViewModels.Pets
{
    public class IndexVM
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }

        public List<Pet> Items { get; set; }
    }
}