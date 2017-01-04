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
    }
}