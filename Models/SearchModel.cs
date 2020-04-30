using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugRelatedDeaths.Models
{
    public class SearchModel
    {
        public List<SelectListItem> DrugDetails { get; set; }
        public string[] DrugIds { get; set; }
    }
}

