using System.Collections.Generic;
using System.Linq;

namespace AI.nRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IList<IUnitOfWorkItem> _workItems;
        private bool _inTransaction;
        
        public UnitOfWork()
        {
            _workItems = new List<IUnitOfWorkItem>();
            _inTransaction = false;
        }

        public void AddWorkItem(IUnitOfWorkItem workItem)
        {
            if (_inTransaction)
            {
                workItem.BeginTransaction();    
            }
            _workItems.Add(workItem);
        }

        public void BeginTransaction()
        {
            _workItems.ToList().ForEach(x => x.BeginTransaction());
            _inTransaction = true;
        }

        public void RollbackTransaction()
        {
            _workItems.ToList().ForEach(x => x.RollbackTransaction());
            _inTransaction = false;
        }

        public void CommitTransaction()
        {
            _workItems.ToList().ForEach(x => x.CommitTransaction());
            _inTransaction = false;
        }

        public void Dispose()
        {
            _workItems.ToList().ForEach(x => x.Dispose());
            _inTransaction = false;
        }
    }
}