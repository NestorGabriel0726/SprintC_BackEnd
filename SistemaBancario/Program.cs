using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    public class Program
    {
        static List<ContaBancaria> contas = new List<ContaBancaria>();

        static void Main(string[] args)
        {
            Console.WriteLine("****** Bem-vindo ao Sistema Bancário ******\n");

            bool abrirSistema = true;
            while (abrirSistema)
            {
                abrirSistema = ExibirMenu();
            }

            Console.WriteLine("\nObrigado por utilizar nosso sistema! Encerrando...");
        }

        public static bool ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("====== MENU PRINCIPAL ======");
            Console.WriteLine("1. Cadastrar Nova Conta");
            Console.WriteLine("2. Acessar Conta Existente");
            Console.WriteLine("3. Listar Contas Cadastradas");
            Console.WriteLine("4. Encerrar o Sistema");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    CadastrarConta();
                    break;

                case "2":
                    AcessarConta();
                    break;

                case "3":
                    ListarContas();
                    break;

                case "4":
                    return false;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    PressionarParaContinuar();
                    break;
            }
            return true;
        }

        // ================= CADASTRO E ACESSO =================

        public static void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("====== CADASTRO DE NOVA CONTA ======\n");

            string titular = LerNomeTitular("Digite seu nome completo (apenas letras e espaços):");
            int senha = LerSenhaNumerica("Crie uma senha NUMÉRICA para sua conta:");

            Console.WriteLine("\nSelecione o tipo de conta que deseja cadastrar:");
            Console.WriteLine("1. Conta Corrente (Taxa de saque: R$ 2,50)");
            Console.WriteLine("2. Conta Poupança (Rendimento: 0,5%)");
            Console.WriteLine("3. Conta Empresarial (Limite de empréstimo: R$ 5.000,00)");
            Console.Write("Opção: ");
            string tipo = Console.ReadLine()!;

            int numeroConta = GerarNumeroConta();

            switch (tipo)
            {
                case "1":
                    contas.Add(new ContaCorrente(numeroConta, titular, 0.0, senha, 2.50));
                    break;
                case "2":
                    contas.Add(new ContaPoupanca(numeroConta, titular, 0.0, senha, 0.5));
                    break;
                case "3":
                    contas.Add(new ContaEmpresarial(numeroConta, titular, 0.0, senha, 5000.00));
                    break;
                default:
                    Console.WriteLine("\nOpção inválida! Cadastro cancelado.");
                    PressionarParaContinuar();
                    return;
            }

            Console.WriteLine($"\n Conta criada com sucesso!");
            Console.WriteLine($" O NÚMERO DA SUA CONTA É: {numeroConta}");
            Console.WriteLine("Guarde esse número para realizar o seu login!");
            PressionarParaContinuar();
        }

        public static void AcessarConta()
        {
            Console.Clear();
            Console.WriteLine("====== ACESSO À CONTA ======\n");

            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada no sistema até o momento.");
                PressionarParaContinuar();
                return;
            }

            int numeroBusca = LerNumeroConta("Digite o número da conta:");
            ContaBancaria contaEncontrada = contas.FirstOrDefault(c => c.NumeroConta == numeroBusca)!;

            if (contaEncontrada == null)
            {
                Console.WriteLine("\nConta não encontrada!");
                PressionarParaContinuar();
                return;
            }

            int senhaDigitada = LerSenhaNumerica("Digite sua senha:");

            if (contaEncontrada.ValidarSenha(senhaDigitada))
            {
                Console.WriteLine($"\nLogin realizado com sucesso!");
                PressionarParaContinuar();
                ExibirMenuOperacoes(contaEncontrada);
            }
            else
            {
                Console.WriteLine("\nSenha incorreta! Acesso negado.");
                PressionarParaContinuar();
            }
        }

        public static void ExibirMenuOperacoes(ContaBancaria conta)
        {
            bool logado = true;

            while (logado)
            {
                Console.Clear();
                Console.WriteLine($"=== ÁREA DO CLIENTE - {conta.Titular.ToUpper()} ===");
                Console.WriteLine($"Conta: {conta.NumeroConta} | Saldo Atual: {conta.Saldo:C}\n");

                Console.WriteLine("1. Consultar Saldo e Dados");
                Console.WriteLine("2. Realizar Depósito");
                Console.WriteLine("3. Realizar Saque");

                if (conta is ContaEmpresarial)
                {
                    Console.WriteLine("4. Solicitar Empréstimo");
                }
                else if (conta is ContaPoupanca)
                {
                    Console.WriteLine("4. Aplicar Rendimento");
                }

                Console.WriteLine("0. Sair da Conta");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine()!;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        conta.ExibirInformacoesConta();
                        PressionarParaContinuar();
                        break;

                    case "2":
                        Console.Clear();
                        double valorDeposito = LerValorDouble("Digite o valor do depósito:");
                        conta.Depositar(valorDeposito);
                        PressionarParaContinuar();
                        break;

                    case "3":
                        Console.Clear();
                        double valorSaque = LerValorDouble("Digite o valor do saque:");
                        conta.Sacar(valorSaque);
                        PressionarParaContinuar();
                        break;

                    case "4":
                        Console.Clear();
                        if (conta is ContaEmpresarial contaEmp)
                        {
                            double valorEmp = LerValorDouble("Digite o valor do empréstimo solicitado:");
                            contaEmp.RealizarEmprestimo(valorEmp);
                        }
                        else if (conta is ContaPoupanca contaPoup)
                        {
                            contaPoup.AplicarRendimento();
                        }
                        else
                        {
                            Console.WriteLine("Opção inválida.");
                        }
                        PressionarParaContinuar();
                        break;

                    case "0":
                        logado = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        PressionarParaContinuar();
                        break;
                }
            }
        }

        public static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("====== CONTAS CADASTRADAS ======\n");

            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada no sistema.");
            }
            else
            {
                foreach (var c in contas)
                {
                    string titularOculto = c.MascararNome(c.Titular);
                    string saldoOculto = c.MascararSaldo();

                    Console.WriteLine($"Número: {c.NumeroConta} | Titular: {titularOculto} | Saldo: {saldoOculto:C} | Tipo: {c.GetType().Name}");
                }
            }

            PressionarParaContinuar();
        }

        // ================= FUNÇÕES AUXILIARES =================

        private static Random random = new Random();

        public static int GerarNumeroConta()
        {
            int novoNumero;
            do
            {
                novoNumero = random.Next(1000, 9999);
            }
            while (contas.Any(c => c.NumeroConta == novoNumero));

            return novoNumero;
        }

        public static int LerNumeroConta(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                if (int.TryParse(Console.ReadLine(), out int numeroValido))
                {
                    return numeroValido;
                }
                Console.WriteLine("\nNúmero de conta inválido! Digite apenas números inteiros.\n");
            }
        }

        public static string LerNomeTitular(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string nome = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(nome) && !nome.Any(char.IsDigit))
                {
                    return nome;
                }
                Console.WriteLine("\nNome inválido! Digite apenas letras e espaços (sem números ou caracteres especiais).\n");
            }
        }

        public static int LerSenhaNumerica(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                if (int.TryParse(Console.ReadLine(), out int senha) && senha > 0)
                {
                    return senha;
                }
                Console.WriteLine("\nSenha inválida! Digite apenas números inteiros sem letras ou caracteres especiais.\n");
            }
        }

        public static double LerValorDouble(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                {
                    return valor;
                }
                Console.WriteLine("\nValor inválido! Digite um valor numérico positivo.\n");
            }
        }

        public static void PressionarParaContinuar()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}