using System;

namespace SistemaBancario
{
    public class ContaBancaria
    {
        public int NumeroConta { get; private set; }
        public string Titular { get; private set; }
        public double Saldo { get; protected set; }
        public int Senha { get; private set; }

        public ContaBancaria(int numeroConta, string titular, double saldo, int senha)
        {
            NumeroConta = numeroConta;
            Titular = titular;
            Saldo = saldo;
            Senha = senha;
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
                Console.WriteLine("Saldo insuficiente ou valor inválido!");
            }
        }

        public bool ValidarSenha(int senhaDigitada)
        {
            return Senha == senhaDigitada;
        }

        public virtual void ExibirInformacoesConta()
        {
            Console.WriteLine("--- DADOS DA CONTA ---");
            Console.WriteLine($"Número da Conta: {NumeroConta}");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Saldo: {Saldo:C}");
        }

        public string MascararNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return "*****";

            var partes = nome.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < partes.Length; i++)
            {
                string palavra = partes[i];
                if (palavra.Length <= 2)
                {
                    partes[i] = new string('*', palavra.Length);
                }
                else
                {
                    partes[i] = palavra[0] + new string('*', palavra.Length - 2) + palavra[^1];
                }
            }
            return string.Join(" ", partes);
        }

        public string MascararSaldo()
        {
            return "R$ ******";
        }
    }
}