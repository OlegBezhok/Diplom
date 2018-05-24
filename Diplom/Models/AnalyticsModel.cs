using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class AnalyticsModel
    {
        public double AverageMarkEmp { get; set; }
        public double AverageMarkMan { get; set; }
        public double AverageMarkHr { get; set; }
        public List<int> MarkEmp { get; set; }
        public List<int> MarkHr { get; set; }
        public List<int> MarkMan { get; set; }
        public string Comment { get; set; }
        public string ResultMan { get; set; }
        public string ResultEmp { get; set; }
        public string ResultHr { get; set; }

    }
}