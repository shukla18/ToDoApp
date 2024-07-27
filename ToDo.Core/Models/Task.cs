using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Models
{
    public class MyTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Key]
        public virtual Category Category { get; set; } // Foreign key to Category

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public bool IsComplete { get; set; } = false;

        public bool IsImportant { get; set; } = false;

        // For recurring tasks
        public int? RecurrenceFrequency { get; set; } // Enum or integer representing frequency
        public DateTime? RecurrenceEndDate { get; set; }





    }
}
