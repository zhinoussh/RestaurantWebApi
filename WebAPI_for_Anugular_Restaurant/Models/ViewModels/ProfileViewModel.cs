using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_for_Anugular_Restaurant.Models
{
    public class ProfileViewModel
    {
        public String UserName { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String PhoneNumber { get; set; }

        public String Address { get; set; }
    }
}