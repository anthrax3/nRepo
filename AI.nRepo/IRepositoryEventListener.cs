using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI.nRepo
{
    public interface IRepositoryEventListener
    {
        void Handle(object entity);
    }
}
