using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace SistemaBancario
{
    public class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria contaBancaria = new ContaBancaria(1077, "Marcelo", 10.90);
            Console.WriteLine("****** Bem vindo ao sistema da rede bancária ******\n");

            bool abrirSistema = true;
            while (abrirSistema)
            {
                abrirSistema = ExibirMenu(contaBancaria);
            }
            Console.WriteLine("Obrigado por utilizar nosso sistema! Encerrando...");
        }

        public static bool ExibirMenu(ContaBancaria contaBancaria)
        {
            Console.WriteLine("Escolha uma opção para acessar a sua conta:");
            Console.WriteLine("1. Conta Poupança");
            Console.WriteLine("2. Conta Corrente");
            Console.WriteLine("3. Conta Empresarial");
            Console.WriteLine("4. Encerrar o sistema");

            string opcao = Console.ReadLine()!;

            if (!int.TryParse(opcao, out int opcaoInt))
            {
                Console.WriteLine("Digite uma opção válida para poder continuar!");
                Console.ReadKey();
                Console.Clear();
                return true;
            }

            string nome;

            switch (opcaoInt)
            {
                case 1:
                    Console.Clear();
                    int numeroContP = LerNumeroConta("Digite o número da conta poupança:");
                    nome = LerNomeTitular("Digite o nome do titular da conta");

                    ContaPoupanca cp = new ContaPoupanca(numeroContP, nome, 100.00, 0.5);
                    cp.ExibirInformacoesConta();
                    break;

                case 2:
                    Console.Clear();
                    int numeroContaC = LerNumeroConta("Digite o número da conta corrente:");
                    nome = LerNomeTitular("Digite o nome do titular da conta");

                    ContaCorrente cc = new ContaCorrente(numeroContaC, nome, 100.00, 4.5);
                    cc.ExibirInformacoesConta();
                    break;

                case 3:
                    Console.Clear();
                    int numeroContE = LerNumeroConta("Digite o número da conta Empresarial:");
                    nome = LerNomeTitular("Digite o nome do titular da conta");

                    ContaEmpresarial ce = new ContaEmpresarial(numeroContE, nome, 1000.00, 10000.00);
                    ce.ExibirInformacoesConta();
                    break;

                case 4:
                    Console.WriteLine("Saindo do sistema...");
                    return false;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
            return true;
        }


        // Funções para validar o número da conta e nome do titular.
        public static int LerNumeroConta(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string entrada = Console.ReadLine()!;

                if (int.TryParse(entrada, out int numeroValido))
                {
                    return numeroValido;
                }

                Console.Clear();
                Console.WriteLine("Número de conta inválido! Digite apenas números (sem letras, espaços ou símbolos).\n");
            }

        }

        public static string LerNomeTitular(string menagem)
        {
            while (true)
            {
                Console.WriteLine(menagem);
                string nome = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(nome) && !nome.Any(char.IsDigit))
                {
                    return nome;
                }
                Console.Clear();
                Console.WriteLine("Nome inválido! Digite apenas letras e não deixe em branco.\n");
            }
        }
    }

}
        
        

