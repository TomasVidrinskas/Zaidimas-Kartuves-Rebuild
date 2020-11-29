using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartuves.BL.Interfaces
{
    public interface ICRUDRepository<Type>
    {
        List<Type> GetAll();
        Type Get(int key);
        void Update(Type entity);
        int Add(Type entity);
        void Delete(int key);
    }
}
