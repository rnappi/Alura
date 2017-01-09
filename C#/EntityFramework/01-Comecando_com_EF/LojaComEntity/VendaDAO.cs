using LojaComEntity.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    public class VendaDAO : BaseContext<Venda>
    {
        public override Venda BuscarPorId(int Id)
        {
            // busca a venda e ickui as referencias para produto venda e os produtos relacionados a venda
            return Context.Vendas.Include(v => v.Produtovenda).ThenInclude(pv => pv.Produto).FirstOrDefault(v => v.ID == Id);
        }

        public override void Remove(Venda entity)
        {
            Context.Vendas.Remove(entity);
            this.SaveChanges();
        }

        public override void Salva(Venda entity)
        {
            Context.Vendas.Add(entity);
            this.SaveChanges();
        }
    }
}