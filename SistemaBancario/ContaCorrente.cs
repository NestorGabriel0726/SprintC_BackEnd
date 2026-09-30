using System;

namespace SistemaBancario
{
    public class ContaCorrente : ContaBancaria
    {
        public double TaxaSaque { get; set; }

        public ContaCorrente(int numeroConta, string titular, double saldo, int senha, double taxaSaque)
            : base(numeroConta, titular, saldo, senha)
        {
            TaxaSaque = taxaSaque;
        }

        public override void Sacar(double valor)
        {
            double valorTotal = valor + TaxaSaque;
            if (valorTotal <= Saldo)
            {
                Saldo -= valorTotal;
                Console.WriteLine($"Saque de {valor:C} (Taxa por saque: {TaxaSaque:C}) realizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Saque não realizado! Saldo insuficiente para cobrir o valor solicitado mais a taxa de {TaxaSaque:C}.");
            }
        }
    }
}