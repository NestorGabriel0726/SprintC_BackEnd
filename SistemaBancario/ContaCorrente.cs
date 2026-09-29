using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaCorrente:ContaBancaria
    {
         public double TaxaSaque { get ; set; }
         public ContaCorrente(int numeroConta, string titular, double saldo, double taxaSaque) : base( numeroConta, titular, saldo)
        {
            TaxaSaque = taxaSaque;
        }

        public override void Sacar(double valor)
        {
            double valorTotal = valor + TaxaSaque;
            if (valorTotal <= Saldo)
            {
                Saldo -= valorTotal;
                Console.WriteLine($"Saque de {valor:C} (Taxa: {TaxaSaque:C}) realizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Saque não realizado! Saldo insuficiente para cobrir o saque e a taxa por saque.");
            }
        }
        
    }
}
