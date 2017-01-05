using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity.Entidades
{
    public class ProdutoVenda
    {
        // representa a venda
        public int VendaID { get; set; }
        public virtual Venda Venda { get; set; }

        // representa o produto
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }
    }
}