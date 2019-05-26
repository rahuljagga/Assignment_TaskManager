using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerTool.Models
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }

        [Display(Name = "Task Name")]
        public string Name { get; set; }
        public Priorities Priority { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Estimated Cost")]
        public double EstimatedCost { get; set; }
        public string Description { get; set; }
    }
    public enum Priorities { P1, P2, P3 }
}