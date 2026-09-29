using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public double Rendimento { get; set; }
        public ContaPoupanca(int numeroConta, string titular, double saldo, double rendimento) : base(numeroConta, titular, saldo)
        {
            Rendimento = rendimento;
        }

        public void AplicarRendimento()
        {
            double valorRendimento = Saldo * (Rendimento / 100);
            Saldo += valorRendimento;
            Console.WriteLine($"Rendimento de {Rendimento} aplicado! Novo saldo da conta: {Saldo:C}");
        }

    }
}
