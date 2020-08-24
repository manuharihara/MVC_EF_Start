﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Models {
    public interface IAuthProvider {
        void Authenticate(string username);
        void SignOut();
    }


        
    
    
}
