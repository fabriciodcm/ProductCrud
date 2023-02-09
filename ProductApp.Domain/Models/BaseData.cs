using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Models
{
    public abstract class BaseData
    {
        public virtual bool IsActive { get; set; }  
    }
}
