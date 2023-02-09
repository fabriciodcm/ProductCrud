using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
