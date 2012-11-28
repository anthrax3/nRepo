using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.nRepo
{
    public interface IDatabasePlatform
    {
        object AsNHibernateConfiguration(string connectionString);


    }
}
