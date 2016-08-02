using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RpgSystem.ViewModel.Login
{
    public class User
    {
        public int idPlayer { get; set; }
        public string nick { get; set; }
        public string password { get; set; }
        public string message { get; set; }
        public bool master { get; set; }
    }
}



