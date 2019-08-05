using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainCore
{
    public interface IUnitOfWork : IDisposable
    {

        bool Commit();

    }
}
