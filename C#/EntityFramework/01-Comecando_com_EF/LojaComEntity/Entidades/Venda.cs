using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaComEntity.Entidades
{
    public class Venda
    {
        public int ID { get; set; }

        // navigation property sempre como virtual!
        public virtual Usuario Cliente { get; set; }
        public int ClienteID { get; set; }

        // representa os produtos que fazem parte da venda
        // asumimos que uma venda pode ter vários produtos
        public virtual IList<ProdutoVenda> Produtovenda { get; set; }
    }
}