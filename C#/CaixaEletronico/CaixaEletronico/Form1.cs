using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaixaEletronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContaPoupanca cp = new ContaPoupanca();
            cp.Deposita(1000);
            cp.Saca(100);
            MessageBox.Show("Saldo Poupanca: " + cp.Saldo);

            Conta c = new ContaCorrente();
            c.Deposita(1000);
            c.Saca(100);
            MessageBox.Show("Saldo Conta: " + c.Saldo);
        }
    }
}