using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Apply_For_Jobs_Core_Webapp.BusinessLayer
{
    //Holds advertisement information
    public class Advertisement
    {
        //Primary Key
        public int Id { get; set; }

        //Advertisement title
        public string Title { get; set; }

        //Advertisement description
        public string Description { get; set; }

        //Employer Id foriegn key
        public int EmployerId { get; set; }

        //Employer reference 
        public Employer Employer { get; set; }

        //Holds salary information.
        public string SalaryInformation { get; set; }

        //One of possible job types 
        public JobType JobType { get; set; }

        //Displayed advert Id 
        [NotMapped]
        public string AdvertisementDisplayId {

              get {return "AD-"+Title +"-"+ Id +"-" + (this.Employer!=null ?this.Employer.Name:" ");
    }
}

    }

    //Job type enum
    public enum JobType {

        FULL_TIME_CONTRACT, FULL_TIME_PERMANENT, PART_TIME_CONTRACT, PART_TIME_PERMANENT

    }
}
