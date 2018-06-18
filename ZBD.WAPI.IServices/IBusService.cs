using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBD.WAPI.IServices
{
    public interface IBusService
    {
        IList<object> Get();
    }
}
