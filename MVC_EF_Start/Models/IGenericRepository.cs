using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Models {
    public interface IGenericRepository<T> {
        
        IEnumerable<T> Entities { get; }
      


        void SaveEntity(T entity);
        


        T DeleteEntity(int entityID);
    }
}