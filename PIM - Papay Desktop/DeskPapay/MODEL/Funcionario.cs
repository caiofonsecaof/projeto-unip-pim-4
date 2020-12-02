namespace DeskPapay.MODEL
{
    public class Funcionario:Pessoa
    {
        public string Cargo { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(string nome, string cpf, string endereco, string telefone, string cargo, double salario)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            Cargo = cargo;
            Salario = salario;
        }
    }
}
