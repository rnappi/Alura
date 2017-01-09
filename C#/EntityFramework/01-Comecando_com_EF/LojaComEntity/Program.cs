using LojaComEntity.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Atualizando um registro no banco de dados
            UsuarioDAO dao = new UsuarioDAO();

            // status gerenciado pelo EF = unchanged
            Usuario user = dao.BuscarPorId(1);

            // status gerenciado pelo EF = Modified
            user.Nome = "Rodrigaouuuu";

            // atualiza os dados da entidade no bando de dados
            // gnora todas que estiverem com status = unchanged
            dao.SaveChanges();*/

            var vendaDAO = new VendaDAO();
            var venda = vendaDAO.BuscarPorId(1);

            foreach (var pv in venda.Produtovenda)
            {
                Console.WriteLine(pv.Produto.Nome);
            }

            Console.ReadLine();
        }

        private void CriarCategoria()
        {
            CategoriaDAO catDao = new CategoriaDAO();
            Categoria c = new Categoria()
            {
                Nome = "Informática"
            };
            catDao.Salva(c);
            Console.WriteLine(c.Nome);
            Console.ReadLine();
        }

        private void CriarProduto()
        {
            CategoriaDAO catDao = new CategoriaDAO();
            ProdutoDAO dao = new ProdutoDAO();
            Produto p = new Produto()
            {
                Nome = "Mouse",
                Preco = 10,
                Categoria = catDao.BuscarPorId(1)
            };
            dao.Salva(p);
            Console.WriteLine(p.Nome);
            Console.ReadLine();
        }

        private void AcessarCategoriaDoProduto()
        {
            var dao = new ProdutoDAO();
            var categoria = dao.BuscarPorId(1).Categoria;
            Console.WriteLine(categoria.Nome);
            Console.ReadLine();
        }

        private void ListarProdutosDaCategoria()
        {
            var dao = new CategoriaDAO();
            var categoria = dao.BuscarPorId(1);
            foreach (var p in categoria.Produtos)
            {
                Console.WriteLine(p.Nome);
            }
            Console.ReadLine();
        }

        private void CadastraVenda()
        {
            UsuarioDAO userDAO = new UsuarioDAO();
            ProdutoDAO produtoDAO = new ProdutoDAO();
            VendaDAO vendaDAO = new VendaDAO();
            ProdutoVendaDAO pvDAO = new ProdutoVendaDAO();
            Usuario user = userDAO.BuscarPorId(1);
            Venda venda = new Venda()
            {
                Cliente = user
            };
            vendaDAO.Salva(venda);

            Produto prod1 = produtoDAO.BuscarPorId(1);
            Produto prod2 = produtoDAO.BuscarPorId(2);

            ProdutoVenda pv1 = new ProdutoVenda()
            {
                Venda = venda,
                Produto = prod1
            };
            pvDAO.Salva(pv1);

            ProdutoVenda pv2 = new ProdutoVenda()
            {
                Venda = venda,
                Produto = prod2
            };
            pvDAO.Salva(pv2);

            // salva as alteracoes
            pvDAO.SaveChanges();

        }
    }
}