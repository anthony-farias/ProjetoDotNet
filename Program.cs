using System;
using System.Collections.Generic;

namespace PROJECT.BANK
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                       Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                opcaoUsuario = obterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            Console.ReadLine();
            
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de origem:  ");
            int indexContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino:  ");
            int indexContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido:  ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indexContaOrigem].Transferir(valorTransferencia, listContas[indexContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da sua conta:  ");
            int indexConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado:  ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indexConta].Depositar(valorDeposito);

        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da sua conta:  ");
            int indexConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor a ser sacado:  ");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indexConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for ( int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Juridica:  "); 
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente:  ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial:  ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito:  ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);

        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja bem vindo ao Banco Project!");
            Console.WriteLine("Selecione abaixo uma de nossas opções:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Criar nova conta");
            Console.WriteLine("3 - Realizar transferência");
            Console.WriteLine("4 - Realizar saque");
            Console.WriteLine("5 - Realizar deposito");
            Console.WriteLine("6 - Limpar a tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
