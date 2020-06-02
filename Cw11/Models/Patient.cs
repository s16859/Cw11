using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Patient
    {

        [Key]
        public int IdPatient { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirsName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        List<Prescription> prescriptions { get; set; }
    }
}
