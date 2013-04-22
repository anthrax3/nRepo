using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
