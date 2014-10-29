using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AI.nRepo.EntityFramework
{
    public interface IConfigureATypeForPersistence
    {
        void Configure(DbModelBuilder modelBuilder);
    }

    
}
