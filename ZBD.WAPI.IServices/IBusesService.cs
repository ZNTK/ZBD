using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZBD.WAPI.Models;

namespace ZBD.WAPI.IServices
{
    public interface IBusesService
    {
        IList<Bus> Get();
        Bus Get(Guid id);
        Bus Get(string name);
        void Add(Bus bus);
        void Update(Bus bus);
        void Remove(Guid id);
    }
}
