using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public interface IRepositorio<T>
    { 
        int Create(T p);
        int Delete(int id);
        int Update(T p);
        IList<T> GetAll();
        T GetAllById(int id);
    }
}
