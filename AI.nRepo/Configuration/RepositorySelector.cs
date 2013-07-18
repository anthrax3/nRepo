
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AI.nRepo.NHibernate;


namespace AI.nRepo.Configuration
{
    public class RepositorySelector : IRepositorySelector
    {
        
        

        

        public NHibernateConfiguration NHibernate()
        {
            return new NHibernateConfiguration();
        }

       

        




        
    }
}
