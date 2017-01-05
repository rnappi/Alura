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

        public IList<Produto> ListarProdutos()
        {
            var busca = from p in Context.Produtos
                        where p.Categoria.Nome == "Roupa" 
                        && p.Preco > 20
                        orderby p.Nome
                        select p;

            return busca.ToList();
        }

        public IList<Produto> BuscaPorPrecoNomeCategoria(string nome, decimal preco, string categoria)
        {
            var busca = from p in Context.Produtos
                        select p;

            if (!String.IsNullOrWhiteSpace(nome))
                busca = busca.Where(p => p.Nome == nome);

            if (preco > 0)
                busca = busca.Where(p => p.Preco == preco);

            if (!String.IsNullOrWhiteSpace(categoria))
                busca = busca.Where(p => p.Categoria.Nome == categoria);

            // o EF monta a query dinamicamente com base nos resultados dos if´s
            // a query só é executada quando chamamos o .ToList()
            return busca.ToList(); 
        }
    }
}