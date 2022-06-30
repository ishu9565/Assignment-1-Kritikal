using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Student.Models
{
    public class StudentDataModel
    {
        
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress] [Required]
        public string Email { get; set; }
        public int? HostelID { get; set; }
        [Required]
        public string RollNumber { get; set; }

        public HostelDataModel HostelData { get; set; }
    
    }
}
