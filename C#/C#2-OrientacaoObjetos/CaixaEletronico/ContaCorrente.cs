using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class ContaCorrente : Conta
    {
        public override void Saca(double valorASerSacado)
        {
            this.Saldo -= valorASerSacado;
        }
    }
}