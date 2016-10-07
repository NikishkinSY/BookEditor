using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEditor_Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        //here we need to add rollback
    }
}
