using LojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    public class ProdutoVendaDAO : BaseContext<ProdutoVenda>
    {
        public override ProdutoVenda BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ProdutoVenda entity)
        {
            Context.ProdutoVenda.Remove(entity);
            //this.SaveChanges();
        }

        public override void Salva(ProdutoVenda entity)
        {
            Context.ProdutoVenda.Add(entity);
            //this.SaveChanges();
        }
    }
}