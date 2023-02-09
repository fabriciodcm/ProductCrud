using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Pagination
{
    public interface IPagination<t> where t : class
    {
        public int skip { get; set; }
        public int take { get; set; }
        public int count { get; set; }
        public ICollection<t> rows { get; set; }
    }
}
