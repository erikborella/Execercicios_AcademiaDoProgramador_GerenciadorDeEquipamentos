using System;
using System.Text;

namespace GerenciadorDeEquipamentos
{
    class Program
    {
        static ListaDeEquipamentos listaDeEquipamentos = new ListaDeEquipamentos();


        static void Main(string[] args)
        {

            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                int opcao = MenuDeOpcao(
                    "1. Ver Equipamentos\n" +
                    "2. Adicionar Equipamento\n" +
                    "3. Remover Equipamento\n" +
                    "4. Sair\n" +
                    "Digite o que deseja fazer: ",
                    "Voce digitou uma opcao incorreta, tente novamente",
                    1, 4);

                switch (opcao)
                {
                    case 1:
                        VerEquipamentosMenu();
                        break;
                    case 2:
                        AdicionarEquipamentoMenu();
                        break;
                    case 3:
                        RemoverEquipamentoMenu();
                        break;
                    case 4:
                        noMenu = false;
                        break;
                }
            }
            
        }

        private static string PegarNome()
        {
            while (true)
            {
                string nome = Console.ReadLine();
                if (nome.Length < 6)
                    Console.WriteLine("O nome deve ter no minimo 6 caracteres, tente novamente\n");
                else
                    return nome;
            }
        }

        private static DateTime PegarData()
        {
            while (true)
            {

                try
                {

                    Console.Write("Digite a data no formato dd/mm/yyyy: ");
                    string dataRaw = Console.ReadLine();

                    string[] datasRaw = dataRaw.Split("/");

                    int dia = Convert.ToInt32(datasRaw[0]);
                    int mes = Convert.ToInt32(datasRaw[1]);
                    int ano = Convert.ToInt32(datasRaw[2]);

                    return new DateTime(ano, mes, dia);
                } 
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Voce Digitou uma data invalida, tente novamente");
                }
            }
        }

        private static void AdicionarEquipamentoMenu()
        {
            Console.Clear();

            Equipamento novoEquipamento = CriarEquipamento();
            listaDeEquipamentos.AdicionarEquipamento(novoEquipamento);
        }

        private static void RemoverEquipamentoMenu()
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                StringBuilder listaEquipamentosStr = new StringBuilder();

                Equipamento[] equipamentos = listaDeEquipamentos.Equipamentos;

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    listaEquipamentosStr.Append($"{i + 1}: {equipamentos[i].Nome}\n");
                }

                listaEquipamentosStr.Append($"{equipamentos.Length + 1} : Voltar\n");
                listaEquipamentosStr.Append("Digite o que deseja fazer: ");

                int opcao = MenuDeOpcao(
                    listaEquipamentosStr.ToString(),
                    "Voce digitou uma operacao incoreta, tente novamente",
                    1, equipamentos.Length + 1);

                if (opcao == equipamentos.Length + 1)
                    noMenu = false;
                else
                    listaDeEquipamentos.RemoverEquipamento(opcao - 1);
            }

        }

        private static Equipamento CriarEquipamento()
        {
            Console.Write("Digite o nome do equipamento: ");
            string nome = PegarNome();

            Console.Write("Digite o preco de aquisicao: ");
            float precoAquisicao = (float)Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o numero de serie: ");
            string serie = Console.ReadLine();

            DateTime dataFabricacao = PegarData();

            Console.Write("Digite a fabricante: ");
            string fabricante = Console.ReadLine();

            Equipamento novoEquipamento = new Equipamento(nome, precoAquisicao, serie, dataFabricacao, fabricante);
            return novoEquipamento;
        }

        private static void VerEquipamentosMenu()
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                StringBuilder mensagemMenu = new StringBuilder();

                Equipamento[] equipamentos = listaDeEquipamentos.Equipamentos;

                for (int i = 0; i < equipamentos.Length; i++)
                {
                    mensagemMenu.Append($"{i + 1}: {equipamentos[i].Nome}\n");
                }

                mensagemMenu.Append($"{equipamentos.Length + 1}: Voltar\n");
                mensagemMenu.Append("Digite qual equipamento voce deseja acessar: ");

                int opcao = MenuDeOpcao(
                    mensagemMenu.ToString(),
                    "Voce Digitou uma operacao incorreta, tente novamente",
                    1, equipamentos.Length + 1);

                if (opcao == equipamentos.Length + 1)
                    noMenu = false;
                else
                {
                    EquipamentoMenu(equipamentos[opcao - 1]);
                }
            }
        }


        private static void EquipamentoMenu(Equipamento equipamento)
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                int opcao = MenuDeOpcao(
                    "Informacoes do equipamento:\n" +
                    $"{equipamento}\n\n" +
                    "1. Editar Equipamento\n" +
                    "2. Ver Manutencoes\n" +
                    "3. Adicionar Manutencoes\n" +
                    "4. Remover Manutencoes\n" +
                    "5. Voltar\n" +
                    "Digite o que deseja fazer: ",
                    "Voce digitou uma opcao invalida, tente novamente",
                    1, 5);

                switch(opcao)
                {
                    case 1:
                        EditarEquipamentoMenu(equipamento);
                        break;
                    case 2:
                        VerManutencoesMenu(equipamento);
                        break;
                    case 3:
                        AdicionarManutencaoMenu(equipamento);
                        break;
                    case 4:
                        RemoverManutencaoMenu(equipamento);
                        break;
                    case 5:
                        noMenu = false;
                        break;
                }
            }
        }

        private static Manutencao CriarManutencao()
        {
            Console.Write("Digite o titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao: ");
            string descricao = Console.ReadLine();

            DateTime dataDeAbertura = PegarData();

            return new Manutencao(titulo, descricao, dataDeAbertura);
        }

        private static void AdicionarManutencaoMenu(Equipamento equipamento)
        {
            Console.Clear();

            Manutencao manutencao = CriarManutencao();
            equipamento.AdicionarManutencao(manutencao);
        }

        private static void RemoverManutencaoMenu(Equipamento equipamento)
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                StringBuilder mensagemMenu = new StringBuilder();

                Manutencao[] manutencoes = equipamento.Manutencaos;

                for (int i = 0; i < manutencoes.Length; i++)
                {
                    mensagemMenu.Append($"{i + 1}: {manutencoes[i].Titulo}\n");
                }

                mensagemMenu.Append($"{manutencoes.Length + 1}: Voltar\n");
                mensagemMenu.Append("Digite qual manutencao voce deseja excluir: ");

                int opcao = MenuDeOpcao(
                    mensagemMenu.ToString(),
                    "Voce Digitou uma operacao incorreta, tente novamente",
                    1, manutencoes.Length + 1);

                if (opcao == manutencoes.Length + 1)
                    noMenu = false;
                else
                    equipamento.RemoverManutencao(opcao - 1);
            }
        }

        private static void VerManutencoesMenu(Equipamento equipamento)
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                StringBuilder mensagemMenu = new StringBuilder();

                Manutencao[] manutencoes = equipamento.Manutencaos;

                for (int i = 0; i < manutencoes.Length; i++)
                {
                    mensagemMenu.Append($"{i + 1}: {manutencoes[i].Titulo}\n");
                }

                mensagemMenu.Append($"{manutencoes.Length + 1}: Voltar\n");
                mensagemMenu.Append("Digite qual manutencao voce deseja acessar: ");

                int opcao = MenuDeOpcao(
                    mensagemMenu.ToString(),
                    "Voce Digitou uma operacao incorreta, tente novamente",
                    1, manutencoes.Length + 1);

                if (opcao == manutencoes.Length + 1)
                    noMenu = false;
                else
                {
                    ManutencaoMenu(manutencoes[opcao - 1]);
                }
            }
        }

        private static void ManutencaoMenu(Manutencao manutencao)
        {
            bool noMenu = true;

            while (noMenu)
            {
                Console.Clear();

                int opcao = MenuDeOpcao(
                    "Infomacoes da manutencao:\n" +
                    $"{manutencao}\n\n" +
                    "1. Editar Manutencao\n" +
                    "2. Voltar\n" +
                    "Digite o que deseja fazer: ",
                    "Voce digitou uma operacao incoreta, tente novamente",
                    1, 2);

                switch (opcao)
                {
                    case 1:
                        EditarManutencaoMenu(manutencao);
                        break;
                    case 2:
                        noMenu = false;
                        break;
                }
            }
        }

        private static void EditarManutencaoMenu(Manutencao manutencao)
        {
            Console.Clear();

            Manutencao novaManutencao = CriarManutencao();

            manutencao.Titulo = novaManutencao.Titulo;
            manutencao.Descricao = novaManutencao.Descricao;
            manutencao.DataDeAbertura = novaManutencao.DataDeAbertura;

        }

        private static void EditarEquipamentoMenu(Equipamento equipamento)
        {
            Console.Clear();

            Equipamento novoEquipamento = CriarEquipamento();
            equipamento.Nome = novoEquipamento.Nome;
            equipamento.Preco = novoEquipamento.Preco;
            equipamento.Fabricante = novoEquipamento.Fabricante;
            equipamento.DataDeFabricacao = novoEquipamento.DataDeFabricacao;


        }

        private static bool OpcaoEstaCorreta(int opMin, int opMax, int op)
        {
            return (op >= opMin && op <= opMax);
        }

        private static int MenuDeOpcao(string msg, string erroMsg, int opMin, int opMax)
        {
            int opcao = opMin - 1;

            while (opcao <= opMin - 1)
            {
                Console.Write(msg);
                opcao = Convert.ToInt32(Console.ReadLine());

                if (!OpcaoEstaCorreta(opMin, opMax, opcao))
                {
                    Console.WriteLine(erroMsg);
                    opcao = opMin - 1;
                }
            }

            return opcao;
        }

    }
}
