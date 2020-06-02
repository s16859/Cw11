using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public Patient Patient { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }

    }
}
