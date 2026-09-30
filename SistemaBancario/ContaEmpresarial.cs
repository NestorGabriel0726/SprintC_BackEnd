using System;

namespace SistemaBancario
{
    public class ContaEmpresarial : ContaBancaria
    {
        public double LimiteEmprestimo { get; set; }

        public ContaEmpresarial(int numeroConta, string titular, double saldo, int senha, double limiteEmprestimo)
            : base(numeroConta, titular, saldo, senha)
        {
            LimiteEmprestimo = limiteEmprestimo;
        }

        public void RealizarEmprestimo(double valor)
        {
            if (valor <= LimiteEmprestimo)
            {
                Saldo += valor;
                LimiteEmprestimo -= valor;
                Console.WriteLine($"Empréstimo de {valor:C} aprovado! Novo saldo: {Saldo:C}");
                Console.WriteLine($"Limite de empréstimo restante: {LimiteEmprestimo:C}");
            }
            else
            {
                Console.WriteLine($"Valor solicitado acima do limite de empréstimo disponível ({LimiteEmprestimo:C}).");
            }
        }
    }
}