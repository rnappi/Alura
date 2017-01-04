using LojaComEntity;
using LojaComEntity.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    class CategoriaDAO : BaseContext<Categoria>
    {
        public override Categoria BuscarPorId(int Id)
        {
            return Context.Categrias.Include(c => c.Produtos).FirstOrDefault(c => c.ID == Id);
        }

        public override void Remove(Categoria categoria)
        {
            Context.Categrias.Remove(categoria);
            this.SaveChanges();
        }

        public override void Salva(Categoria categoria)
        {
            Context.Categrias.Add(categoria);
            this.SaveChanges();
        }
    }
}