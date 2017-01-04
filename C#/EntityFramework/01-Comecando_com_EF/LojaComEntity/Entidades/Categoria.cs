using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity.Entidades
{
    // public para o EF acessar as propriedades
    public class Categoria
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        // Criando o relacionamento da categoria com o produto (Navigation Property)
        // assumimos que a categoria pode ter vários produtos
        // TODA Navigation Property deve ser virtual para que o EF possa dar um overqrite nela
        public virtual IList<Produto> Produtos { get; set; }
    }
}