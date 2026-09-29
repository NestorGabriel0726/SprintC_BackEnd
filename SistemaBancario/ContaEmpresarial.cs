using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaEmpresarial : ContaBancaria
    {
        public double LimiteEmprestimo { get; set; }
        public ContaEmpresarial(int numeroConta, string titular, double saldo, double limiteEmprestimo) : base(numeroConta, titular, saldo)
        {
            LimiteEmprestimo = limiteEmprestimo;
        }

        public void RealizarEmprestimo(double valor)
        {
            if (valor <= LimiteEmprestimo)
            {
                Saldo += valor;
                LimiteEmprestimo -= valor;
                Console.WriteLine($"Empréstimo de {valor:C} aprovado! Saldo atual da conta: {Saldo:C}");
            }
            else
            {
                Console.WriteLine($"Valor solicitado acima do limite de empréstimo disponível ({LimiteEmprestimo:C}).");
            }
        }
    }
}
