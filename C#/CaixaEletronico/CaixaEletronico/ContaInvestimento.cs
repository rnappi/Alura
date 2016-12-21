using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class ContaInvestimento : Conta, ITributavel
    {
        public double CalculaTributo()
        {
            return this.Saldo * 0.01;
        }

        public override void Saca(double valorASerSacado)
        {
            this.Saldo -= valorASerSacado;
        }
    }
}