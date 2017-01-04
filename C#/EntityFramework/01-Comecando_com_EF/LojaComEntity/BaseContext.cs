using LojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    public abstract class BaseContext<T> : IBaseContext<T> where T : class
    {
        private EntidadesContext _context;
        protected EntidadesContext Context
        {
            get
            {
                _context = _context ?? new EntidadesContext();
                return _context;
            }
        }

        public abstract T BuscarPorId(int Id);

        public abstract void Remove(T entity);

        public abstract void Salva(T entity);

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}