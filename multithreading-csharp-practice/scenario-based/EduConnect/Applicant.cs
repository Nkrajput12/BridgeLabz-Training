using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLabzTraining.EduConnect
{
    internal class Applicant
    {
        public int ApplicationId { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidEmail]
        public string Email { get; set; }

        public string ApplicationStatus { get; set; } = "Pending";

        
    }

   
}
