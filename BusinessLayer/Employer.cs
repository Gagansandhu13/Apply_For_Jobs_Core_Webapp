using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apply_For_Jobs_Core_Webapp.BusinessLayer
{
    //Holds employee information
    public class Employer
    {
        //Primary key
        public int Id { get; set; }

        //Name of the employee
        public string Name { get; set; }

        //Employee contact number.
        public string ContactNumber { get; set; }

        //Employee website
        public string WebSite { get; set; }

        //Employee registration number.
        [NotMapped]
        public string RegistrationNumber {

            get {
                return "E" + Id;
            }
        }
    }
}
