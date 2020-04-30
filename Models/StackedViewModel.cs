using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugRelatedDeaths.Models
{
    public class StackedViewModel
    {
        public string StackedDimensionOne { get; set; }
        public List<ReportViewModel> LstData { get; set; }
    }
}
