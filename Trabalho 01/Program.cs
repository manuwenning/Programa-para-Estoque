using System;

namespace Trabalho_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dados de estoque desorganizado elaborado pelo professor:
            
            int[][] estoque;
            GeraBD log = new GeraBD();
            estoque = log.GeraMatriz();

            for (int i = 0; i < estoque.Length; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    Console.Write(estoque[i][j] + "   ");
                }
                Console.WriteLine();
            }



            //Criação de nova matriz como "EstoqueOrganizado" para receber os dados organizados da matriz "Estoque"

            int[][] estoqueOrg = new int[40][];

            for (int i = 0; i < estoqueOrg.Length; i++)
            {
                estoqueOrg[i] = new int[40];
            }

            //Contagem dos produtos dentro da matriz (estoque) desorganizada:

            int produto1=0, produto2=0, produto3=0, produto4=0;

            for (int i = 0; i < estoque.Length; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if (estoque[i][j] == 1)
                    {
                        produto1++;
                        
                    }
                    else if (estoque[i][j] == 2)
                    {
                        produto2++;
                       
                    }
                    else if(estoque[i][j] == 3)
                    {
                        produto3++;
                        
                    }
                    else if (estoque[i][j] == 4)
                    {
                        produto4++;
                        
                    }

                }

            }

            //Descarte do excedente do estoque para lançamento na nova matriz:

            if(produto1>400)
            {
                int descarte1;
                descarte1 = produto1 - 400;
                produto1 = -descarte1;
                 
            }
            else if (produto2>400)
            {
                int descarte2;
                descarte2 = produto2 - 400;
                produto2 = -descarte2;

            }
            else if (produto3 > 400)
            {
                int descarte3;
                descarte3 = produto3 - 400;
                produto3 = -descarte3;
            }
            else if (produto4 > 400)
            {
                int descarte4;
                descarte4 = produto4 - 400;
                produto4 = -descarte4;
            }

            //preenchimento da matriz/estoque:
            
            int preencher1 = 0;
            int preencher2 = 0;
            int preencher3 = 0;
            int preencher4 = 0;
                                  
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < estoqueOrg[i].Length; j++)
                {
                     if (preencher1 <= produto1)
                     {

                            estoqueOrg[i][j] = 1;
                            preencher1++;
                     }
                }
            }
            for (int i = 10; i < 20; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if(preencher2 <= produto2)
                    {
                        estoqueOrg[i][j] = 2;
                        preencher2++;
                    }
                    
                }
            }

            for (int i = 20; i < 30; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if(preencher3 <= produto3)
                    {
                        estoqueOrg[i][j] = 3;
                        preencher3++;
                    }
                    
                }
            }
            for (int i = 30; i < 40; i++)
            {
                for (int j = 0; j < estoque[i].Length; j++)
                {
                    if(preencher4 <= produto4)
                    {
                        estoqueOrg[i][j] = 4;
                        preencher4++;
                    }
                    
                }
            }

            //Funcionamento do menu:

            bool choose = true;
            string escolha; //Para as escolhas de menu escolhi o tipo de variável string pois, caso o usuário aperte sem querer uma letra, o programa não vai travar!

            while (choose == true)
            {
                Console.WriteLine("\n MENU \n");
                Console.WriteLine("1 - Adicionar um produto");
                Console.WriteLine("2 - Retirar um produto");
                Console.WriteLine("3 - Ver o estoque");
                Console.WriteLine("4 - Fechar o programa");
                Console.WriteLine();

                escolha = Console.ReadLine();

                //Opção 1 - adicionar produto:

                if (escolha == "1")
                {
                    string escolha1, adicionarNovamente;
                    bool Adicionar = true;

                    while (Adicionar == true)
                    {
                        Console.WriteLine("\n Qual categoria de produto você deseja adicionar? \n");
                        Console.WriteLine("1 - Alimento   ->   capacidade (" + produto1 + "/400)");
                        Console.WriteLine("2 - Higiene Pessoal   ->   capacidade (" + produto2 + "/400)");
                        Console.WriteLine("3 - Limpeza   ->   capacidade (" + produto3 + "/400)");
                        Console.WriteLine("4 - Utensílios   ->   capacidade (" + produto4 + "/400)");
                        Console.WriteLine("\n-> Pressione qualquer outro número para voltar ao menu inicial \n");

                        int quantidade;

                        escolha1 = Console.ReadLine();

                        if (escolha1 == "1")
                        {
                            Console.WriteLine("\n Quantos produtos você deseja adicionar? \n");
                            quantidade = int.Parse(Console.ReadLine());

                            if ((produto1 + quantidade) <= 400)
                            {
                                produto1 = produto1 + quantidade;
                                preencher1 = 0;

                                for (int i = 0; i < 10; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {

                                        if (preencher1 <= produto1)
                                        {
                                            estoqueOrg[i][j] = 1;
                                            preencher1++;
                                        }

                                    }

                                }
                                Console.WriteLine("\n Produto(s) adicionado(s) com sucesso! \n");
                                Console.WriteLine("\n Deseja adicionar mais produtos? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                adicionarNovamente = Console.ReadLine();

                                if(adicionarNovamente == "1")
                                {
                                    Adicionar = true;
                                }
                                else if (adicionarNovamente == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    Adicionar = false;

                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    Adicionar = false;
                                }

                            }
                            else
                            {

                                Console.WriteLine("\n Estoque cheio ou sem capacidade para inserir a quantidade de produtos determinada! Tente novamente... \n");
                                Adicionar = true;

                            }

                        }

                        else if (escolha1 == "2")
                        {
                            Console.WriteLine("\n Quantos produtos você deseja adicionar? \n");
                            quantidade = int.Parse(Console.ReadLine());

                            if ((produto2 + quantidade) <= 400)
                            {
                                produto2 = produto2 + quantidade;
                                preencher2 = 0;

                                for (int i = 10; i < 20; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        if (preencher2 <= produto2)
                                        {
                                            estoqueOrg[i][j] = 2;
                                            preencher2++;
                                        }
                                    }
                                }
                                Console.WriteLine("\n Produto(s) adicionado(s) com sucesso! \n");
                                Console.WriteLine("\n Deseja adicionar mais produtos? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                adicionarNovamente = Console.ReadLine();

                                if (adicionarNovamente == "1")
                                {
                                    Adicionar = true;
                                }
                                else if (adicionarNovamente == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    Adicionar = false;

                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    Adicionar = false;
                                }

                            }
                            else
                            {

                                Console.WriteLine("\n Estoque cheio ou sem capacidade para inserir a quantidade de produtos determinada! Tente novamente... \n");
                                Adicionar = true;

                            }

                        }
                        else if (escolha1 == "3")
                        {
                            Console.WriteLine("\n Quantos produtos você deseja adicionar? \n");
                            quantidade = int.Parse(Console.ReadLine());

                            if ((produto3 + quantidade) <= 400)
                            {
                                produto3 = produto3 + quantidade;
                                preencher3 = 0;

                                for (int i = 20; i < 30; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        if (preencher3 <= produto3)
                                        {
                                            estoqueOrg[i][j] = 3;
                                            preencher3++;
                                        }
                                    }
                                }
                                Console.WriteLine("\n Produto(s) adicionado(s) com sucesso! \n");
                                Console.WriteLine("\n Deseja adicionar mais produtos? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                adicionarNovamente = Console.ReadLine();

                                if (adicionarNovamente == "1")
                                {
                                    Adicionar = true;
                                }
                                else if (adicionarNovamente == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    Adicionar = false;

                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    Adicionar = false;
                                }

                            }
                            else
                            {

                                Console.WriteLine("\n Estoque cheio ou sem capacidade para inserir a quantidade de produtos determinada! Tente novamente... \n");
                                Adicionar = true;

                            }

                        }
                        else if (escolha1 == "4")
                        {
                            Console.WriteLine("\n Quantos produtos você deseja adicionar? \n");
                            quantidade = int.Parse(Console.ReadLine());

                            if ((produto4 + quantidade) <= 400)
                            {
                                produto4 = produto4 + quantidade;
                                preencher4 = 0;

                                for (int i = 30; i < 40; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        if (preencher4 <= produto4)
                                        {
                                            estoqueOrg[i][j] = 4;
                                            preencher4++;
                                        }
                                    }
                                }
                                Console.WriteLine("\n Produto(s) adicionado(s) com sucesso! \n");
                                Console.WriteLine("\n Deseja adicionar mais produtos? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                adicionarNovamente = Console.ReadLine();

                                if (adicionarNovamente == "1")
                                {
                                    Adicionar = true;
                                }
                                else if (adicionarNovamente == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    Adicionar = false;

                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    Adicionar = false;
                                }

                            }
                            else
                            {

                                Console.WriteLine("\n Estoque cheio ou sem capacidade para inserir a quantidade de produtos determinada! Tente novamente... \n");
                                Adicionar = true;

                            }
                        }
                        else
                        {
                            Console.WriteLine("\n Escolha incorreta, retornando ao menu inicial... \n");
                            Adicionar = false;

                        }

                    }
                }

                //Opção 2 - remover produto:

                else if (escolha == "2")
                {
                    string escolhaA, escolhaB;
                    bool retirar = true;

                    while (retirar == true)
                    {
                        Console.WriteLine("\n De qual categoria de produto você deseja retirar do estoque? \n");
                        Console.WriteLine("1 - Alimento");
                        Console.WriteLine("2 - Higiene Pessoal");
                        Console.WriteLine("3 - Limpeza");
                        Console.WriteLine("4 - Utensílios");
                        Console.WriteLine("\n-> Pressione qualquer outro número para voltar ao menu inicial \n");

                        escolhaA = Console.ReadLine();

                        if (escolhaA == "1")
                        {
                            int escolhaA1, escolhaA2;

                            Console.WriteLine("\n Selecione de qual linha você deseja retirar: \n");
                            for (int i = 0; i < 10; i++)
                            {
                                Console.Write((i + 1) + " -> ");
                                for (int j = 0; j < estoqueOrg[i].Length; j++)
                                {

                                    Console.Write(estoqueOrg[i][j] + "   ");
                                }
                                Console.WriteLine();
                            }

                            escolhaA1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("\n Escolha a coluna: \n");
                            for (int i = 0; i < estoqueOrg[escolhaA1 - 1].Length; i++)
                            {
                                Console.Write((i + 1) + " -> " + estoqueOrg[escolhaA1 - 1][i] + "   ");
                            }
                            Console.WriteLine();
                            escolhaA2 = int.Parse(Console.ReadLine());

                            if (estoqueOrg[escolhaA1 - 1][escolhaA2 - 1] != 0)
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        estoqueOrg[escolhaA1 - 1][escolhaA2 - 1] = 0;
                                        
                                    }
                                }
                                produto1--;
                                Console.WriteLine("\n Produto retirado! Deseja retirar outro produto? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }

                            }
                            else
                            {
                                Console.WriteLine("\n O local já está vazio... \n");
                                Console.WriteLine("\n Deseja selecionar novamente? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                        }
                        else if (escolhaA == "2")
                        {
                            int escolhaB1, escolhaB2;

                            Console.WriteLine("\n Selecione de qual linha você deseja retirar: \n");
                            for (int i = 10; i < 20; i++)
                            {
                                Console.Write((i + 1) + " -> ");

                                for (int j = 0; j < estoqueOrg[i].Length; j++)
                                {
                                    Console.Write(estoqueOrg[i][j] + "   ");
                                }
                                Console.WriteLine();
                            }

                            escolhaB1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("\n Escolha a coluna: \n");
                            for (int i = 0; i < estoqueOrg[escolhaB1 - 1].Length; i++)
                            {
                                Console.Write((i + 1) + " -> " + estoqueOrg[escolhaB1 - 1][i] + "   ");
                            }
                            Console.WriteLine();
                            escolhaB2 = int.Parse(Console.ReadLine());

                            if (estoqueOrg[escolhaB1 - 1][escolhaB2 - 1] != 0)
                            {
                                for (int i = 10; i < 20; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        estoqueOrg[escolhaB1 - 1][escolhaB2 - 1] = 0;
                                        
                                    }

                                }
                                produto2--;
                                Console.WriteLine("\n Produto retirado! Deseja retirar outro produto? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n O local já está vazio... \n");
                                Console.WriteLine("\n Deseja selecionar novamente? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                        }
                        else if (escolhaA == "3")
                        {
                            int escolhaC1, escolhaC2;

                            Console.WriteLine("\n Selecione de qual linha você deseja retirar: \n");
                            for (int i = 20; i < 30; i++)
                            {
                                Console.Write((i + 1) + " -> ");

                                for (int j = 0; j < estoqueOrg[i].Length; j++)
                                {
                                    Console.Write(estoqueOrg[i][j] + "   ");
                                }
                                Console.WriteLine();
                            }

                            escolhaC1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("\n Escolha a coluna: \n");
                            for (int i = 0; i < estoqueOrg[escolhaC1 - 1].Length; i++)
                            {
                                Console.Write((i + 1) + " -> " + estoqueOrg[escolhaC1 - 1][i] + "   ");
                            }
                            Console.WriteLine();
                            escolhaC2 = int.Parse(Console.ReadLine());

                            if (estoqueOrg[escolhaC1 - 1][escolhaC2 - 1] != 0)
                            {
                                for (int i = 20; i < 30; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        estoqueOrg[escolhaC1 - 1][escolhaC2 - 1] = 0;
                                        
                                    }
                                }
                                produto3--;
                                Console.WriteLine("\n Produto retirado! Deseja retirar outro produto? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n O local já está vazio... \n");
                                Console.WriteLine("\n Deseja selecionar novamente? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                        }
                        else if (escolhaA == "4")
                        {
                            int escolhaD1, escolhaD2;

                            Console.WriteLine("\n Selecione de qual linha você deseja retirar: \n");
                            for (int i = 30; i < 40; i++)
                            {
                                Console.Write((i + 1) + "   ");

                                for (int j = 0; j < estoqueOrg[i].Length; j++)
                                {
                                    Console.Write(estoqueOrg[i][j] + "   ");
                                }
                                Console.WriteLine();
                            }
                            escolhaD1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("\n Escolha a coluna: \n");

                            for (int i = 0; i < estoqueOrg[escolhaD1 - 1].Length; i++)
                            {
                                Console.Write((i + 1) + " -> " + estoqueOrg[escolhaD1 - 1][i] + "   ");
                            }
                            Console.WriteLine();
                            escolhaD2 = int.Parse(Console.ReadLine());

                            if (estoqueOrg[escolhaD1 - 1][escolhaD2 - 1] != 0)
                            {
                                for (int i = 30; i < 40; i++)
                                {
                                    for (int j = 0; j < estoqueOrg[i].Length; j++)
                                    {
                                        estoqueOrg[escolhaD1 - 1][escolhaD2 - 1] = 0;
                                        
                                    }
                                }
                                produto4--;
                                Console.WriteLine("\n Produto retirado! Deseja retirar outro produto? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\n O local já está vazio... \n");
                                Console.WriteLine("\n Deseja selecionar novamente? \n");
                                Console.WriteLine("1 - sim");
                                Console.WriteLine("2 - não");
                                Console.WriteLine();
                                escolhaB = Console.ReadLine();

                                if (escolhaB == "1")
                                {
                                    retirar = true;
                                }
                                else if (escolhaB == "2")
                                {
                                    Console.WriteLine("Retornando ao menu inicial...");
                                    retirar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha incorreta, retornando ao menu inicial...");
                                    retirar = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n Voltando ao menu inicial... \n");
                            retirar = false;
                        }

                    }
                }

                //Opção 3 - mostrar o estoque:

                else if (escolha == "3")
                {
                    Console.WriteLine("\n 1 - Alimento: \n");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < estoqueOrg[i].Length; j++)
                        {
                            Console.Write(estoqueOrg[i][j] + "   ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n 2 - Higiene Pessoal: \n");
                    for (int i = 10; i < 20; i++)
                    {
                        for (int j = 0; j < estoqueOrg[i].Length; j++)
                        {
                            Console.Write(estoqueOrg[i][j] + "   ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n 3 - Limpeza: \n");
                    for (int i = 20; i < 30; i++)
                    {
                        for (int j = 0; j < estoqueOrg[i].Length; j++)
                        {
                            Console.Write(estoqueOrg[i][j] + "   ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n 4 - Utensílios: \n");
                    for (int i = 30; i < 40; i++)
                    {
                        for (int j = 0; j < estoqueOrg[i].Length; j++)
                        {
                            Console.Write(estoqueOrg[i][j] + "   ");
                        }
                        Console.WriteLine();
                    }

                }

                //Opção 4 - sair e encerrar o programa:

                else if(escolha == "4")
                {
                    Console.WriteLine("\n Obrigado por utilizar este programa! Encerrando... \n");
                    choose = false;
                }

                //Mensagem caso o usuário digite outro número e não queira necessariamente sair do programa:

                else
                {
                    Console.WriteLine("\n Comando incorreto... \n");
                    choose = true;
                }

            }

        }
    }

    class GeraBD
    {
        public int[][] bd;

        public int[][] GeraMatriz()
        {
            // Esse código NAO deve ser alterado, mas pode
            // ver se desejar (mensagem do próprio professor)
            bd = new int[40][];
            for (int i = 0; i < bd.Length; i++)
            {
                bd[i] = new int[40];
            }
            Random produto = new Random();
            Random gaveta = new Random();

            for (int i = 0; i < bd.Length; i++)
            {
                for (int j = 0; j < bd[i].Length; j++)
                {
                    if (gaveta.Next(0, 4) == 0)
                    {
                        bd[i][j] = produto.Next(1, 5);
                    }
                    else
                    {
                        bd[i][j] = 0;
                    }
                }
            }

            return bd;
        }
    }

}