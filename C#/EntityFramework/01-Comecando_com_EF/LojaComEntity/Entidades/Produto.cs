using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity.Entidades
{
    // public para que o EF consiga acessar as propriedades
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        // cirando o relacionamento do produto com a categoria (Navigation Property)
        // assumimos que o produto pode ter apenas uma categoria
        // TODA Navitgation Property deve ser virtual para que o EF sobreescreva (overwrite) esta propriedade
        public virtual Categoria Categoria { get; set; }

        // informamos ao EF qual a propriedade da categpria será utilizada para gerar a FK no banco
        public int CategoriaID { get; set; }
    }
}