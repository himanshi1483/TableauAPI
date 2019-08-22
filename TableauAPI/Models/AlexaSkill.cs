using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableauAPI.Models
{
    public class AlexaSKill
    {
        [Key]
        public int Id { get; set; }
        public string DashboardUrl { get; set; }
        public string DashboardData { get; set; }
    }
}