namespace CaixaEletronico
{
    class Cliente
    {
        public string nome;
        public string rg;
        public string cpf;
        public string endereco;
        public int idade;

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public bool EhMaiorDeIdade()
        {
            return this.idade >= 18;
        }
    }
}