using SistemaBancario;
using System;

namespace SistemaBancario
{
    public class ContaBancaria
    {
        public int NumeroConta { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; protected set; }
        public ContaBancaria(int numeroConta, string titular, double saldo)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldo;
        }

        public virtual void Depositar(double valor)
        {
            if (valor > 0)
            {
                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valor de depósito inválido!");
            }
        }

        public virtual void Sacar(double valor)
        {
            if (valor > 0 && valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente ou valor inválido!");
            }
        }

        

        public void ExibirInformacoesConta()
        {
            Console.WriteLine("--- DADOS DA CONTA ---");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: {Saldo:C}");
        }
    }

}




