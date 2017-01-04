using LojaComEntity.Entidades;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    class ProdutoDAO : BaseContext<Produto>
    {
        public override Produto BuscarPorId(int Id)
        {
            // O Include informa ao EF que ele deve trazer a Categoria preenchida
            // Ou seja, deve considerar este relacionamento no retorno da pesquisa pelo ID do produto
            return Context.Produtos.Include(p => p.Categoria).FirstOrDefault(p => p.ID == Id);
        }

        public override void Remove(Produto produto)
        {
            Context.Produtos.Remove(produto);
            this.SaveChanges();
        }

        public override void Salva(Produto produto)
        {
            Context.Produtos.Add(produto);
            Context.SaveChanges();
        }
    }
}