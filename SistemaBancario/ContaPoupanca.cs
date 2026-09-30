using System;

namespace SistemaBancario
{
    public class ContaPoupanca : ContaBancaria
    {
        public double Rendimento { get; set; }

        public ContaPoupanca(int numeroConta, string titular, double saldo, int senha, double rendimento)
            : base(numeroConta, titular, saldo, senha)
        {
            Rendimento = rendimento;
        }

        public void AplicarRendimento()
        {
            double valorRendimento = Saldo * (Rendimento / 100);
            Saldo += valorRendimento;
            Console.WriteLine($"Rendimento de {Rendimento}% aplicado! Novo saldo da conta: {Saldo:C}");
        }
    }
}