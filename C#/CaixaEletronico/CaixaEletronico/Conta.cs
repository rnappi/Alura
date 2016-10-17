using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaEletronico
{
    class Conta
    {
        public int numero;
        public string titutlar;
        public double saldo;
        public Cliente cliente;

        public void Saca(double ValorASerSacado)
        {
            this.saldo -= ValorASerSacado;
        }

        public void Deposita(double ValorASerDepositado)
        {
            this.saldo += ValorASerDepositado;
        }

        public void Transfere(double valor, Conta destino)
        {
            this.Saca(valor);
            destino.Deposita(valor);
        }
    }
}