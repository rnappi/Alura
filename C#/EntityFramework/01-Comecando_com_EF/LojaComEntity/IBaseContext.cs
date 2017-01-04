using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    public interface IBaseContext<T> where T : class
    {
        void Salva(T entity);
        void Remove(T entity);
        void SaveChanges();
        T BuscarPorId(int Id);
    }
}