using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace MenuTPA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Trabalho de TPA Menu
            string continuar;
            string[] lista = { "[0] Menu Vetores", "[1] Jogo Adivinha Número", "[2] Tabuada",
                               "[3] Média Aritmética", "[4] Animação de Texto", "[5] Fim"};
            bool loop = true;
            int opcao;

            while (loop)
            {
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Blue;
                Clear();

                JanelaTitulo(20, 2, "MENU");
                Lista(10, 6, lista);

                SetCursorPosition(10, 21);
                Write("Digite o número da opção que preferir: ");
                opcao = int.Parse(ReadLine());

                switch (opcao)
                {
                    case 0:
                        MenuVetores();
                        break;
                    case 1:
                        AdivinhaNum(0);
                        break;
                    case 2:
                        Tabuada();
                        break;
                    case 3:
                        Media();
                        break;
                    case 4:
                        AnimacaoTexto();
                        break;
                    case 5:
                        loop = false;
                        break;
                }
            }
        }
        static void MenuVetores()
        {
            int opcao = 0;
            bool loop = true;

            Clear();
            string titulo = "Menu vetores";
            string[] lista = new string[5] { "[1] Estados", "[2] Número por extenso(0-1000)", "[3] Dia do mês", "[4] ordena vetor", "[5] Sair" };



            do
            {
                Clear();
                JanelaTitulo(20, 2, titulo);
                Lista(10, 6, lista);
                Write("  Digite sua opção: ");


                if (!int.TryParse(ReadLine(), out opcao))
                {
                    WriteLine("\n\t\tOpção Inválida\n");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Estados();

                        break;
                    case 2:
                        Numextenso();

                        break;
                    case 3:
                        Diaemes();

                        break;
                    case 4:
                        OrdenaVetor();

                        break;
                    case 5:

                        loop = false;
                        break;
                    default:
                        WriteLine("\n\t\tOpção Inválida\n");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
            }
            while (loop);
        }
        private static void Numextenso()
        {
            Clear();
            string[] unidade = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            string[] dezena = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            string[] centena = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
            string extenso = "", r;
            int n, ne, nd, nc, a = 0;

            Write("Começar [s/n]? ");
            r = ReadLine();

            while (r == "s")
            {
                Clear();
                JanelaTitulo(20, 2, "NÚMEROS POR EXTENSO");
                SetCursorPosition(10, 6);
                Write("Digite um número (0-1000): ");
                if (!int.TryParse(ReadLine(), out n))
                {
                    JanelaTitulo(10, 8, "Valor inválido.");
                    Thread.Sleep(3000);
                    continue;
                }

                if (n < 0 || n > 1000)
                {
                    JanelaTitulo(10, 8, "Número fora da faixa");
                }
                else if (n == 100)
                {
                    extenso = "cem";
                }
                else if (n < 20)
                {
                    extenso = unidade[n];
                }
                else if (n < 100)
                {
                    ne = n / 10;
                    nd = n % 10;
                    extenso = dezena[ne];
                    if (nd > 0)
                    {
                        extenso += " e " + unidade[nd];


                    }
                }
                else if (n < 1000)
                {
                    nc = n / 100;
                    a = n % 100;
                    ne = a / 10;
                    nd = a % 10;
                    extenso = centena[nc];
                    if (ne > 2)
                    {
                        extenso += " e " + dezena[ne];


                        if (nd > 0)
                        {
                            extenso += " e " + unidade[nd];


                        }
                    }
                    else if (ne >= 0 && ne < 2 && a > 0)
                    {
                        extenso += " e " + unidade[a];


                    }
                }
                else if (n == 1000)
                {
                    extenso = "mil";
                }
                JanelaTitulo(10, 8, extenso);


                Write("\nRecomeçar [s/n]? ");
                r = ReadLine();
            }
        }
        private static void Estados()
        {
            Clear();
            string[,] estados = {
                { "acre", "ac" }, { "alagoas", "al" }, { "amapá", "ap" }, { "amazonas", "am" }, { "bahia", "ba" },
                { "ceará", "ce" }, { "distrito federal", "df" }, { "espírito santo", "es" }, { "goiás", "go" }, { "maranhão", "ma" },
                { "mato grosso", "mt" }, { "mato grosso do sul", "ms" }, { "minas gerais", "mg" }, { "pará", "pa" }, { "paraíba", "pb" },
                { "paraná", "pr" }, { "pernambuco", "pe" }, { "piauí", "pi" }, { "rio de janeiro", "rj" }, { "rio grande do norte", "rn" },
                { "rio grande do sul", "rs" }, { "rondônia", "ro" }, { "roraima", "rr" }, { "santa catarina", "sc" }, { "são paulo", "sp" },
                { "sergipe", "se" }, { "tocantins", "to" }
            };
            string r;
            do
            {
                Clear();
                Write("Começar[s/n]? ");
                r = ReadLine();
                if (r != "s") break;
                Clear();
                JanelaTitulo(20, 2, "ESTADOS");

                SetCursorPosition(10, 6);
                Write("Digite o nome ou sigla de um estado: ");
                string nome = ReadLine().ToLower();

                bool encontrado = false;
                for (int i = 0; i < estados.GetLength(0); i++)
                {
                    if (nome == estados[i, 0])
                    {
                        JanelaTitulo(10, 8, estados[i, 1].ToUpper());
                        encontrado = true;
                        break;
                    }
                    else if (nome == estados[i, 1])
                    {

                        string estadoFormatado = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(estados[i, 0]);
                        JanelaTitulo(10, 8, estadoFormatado);
                        encontrado = true;
                        break;
                    }
                }
                if (!encontrado)
                {
                    JanelaTitulo(10, 8, "Estado ou sigla não encontrado.");
                }

                Write("\nRecomeçar[s/n]? ");
                r = ReadLine();
            } while (r == "s");

        }
        private static void Diaemes()
        {
            Clear();
            string[] diasu = { "", "Um", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Onze", "Doze", "Treze", "Quatorze", "Quinze", "Dezesseis", "Dezessete", "Dezoito", "Dezenove" };
            string[] diasd = { "", "", "Vinte", "Trinta" };
            string[] meses = { "", "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

            string r, dia = "", mes = "";
            int numdia = 0, nummes = 0, numdiadez = 0, numdiauni = 0;

            do
            {
                Write("Começar [s/n]? ");
                r = ReadLine();
                if (r != "s") break;

                Clear();
                JanelaTitulo(20, 2, "DIA E MÊS");
                SetCursorPosition(10, 6);
                Write("Informe o dia do mês: ");
                if (!int.TryParse(ReadLine(), out numdia))
                {
                    JanelaTitulo(10, 8, "Valor inválido para o dia.");
                    continue;
                }

                if (numdia == 1)
                {
                    dia = "Primeiro";
                }
                else if (numdia < 20)
                {
                    dia = diasu[numdia];
                }
                else if (numdia < 32)
                {
                    numdiadez = numdia / 10;
                    numdiauni = numdia % 10;
                    dia = diasd[numdiadez];
                    if (numdiauni > 0)
                    {
                        dia += " e " + diasu[numdiauni];
                    }
                }
                else
                {
                    JanelaTitulo(10, 8, "Dia inválido.");
                    continue;
                }
                SetCursorPosition(10, 8);
                Write("Informe o número do mês: ");
                if (!int.TryParse(ReadLine(), out nummes))
                {
                    JanelaTitulo(10, 12, "Valor inválido para o mês.");
                    continue;
                }

                if (nummes < 1 || nummes > 12)
                {
                    JanelaTitulo(10, 12, "Data inválida\n");
                }
                else if ((nummes == 4 || nummes == 6 || nummes == 9 || nummes == 11) && numdia > 30)
                {
                    JanelaTitulo(10, 12, "Data inválida\n");
                }
                else if (nummes == 2 && numdia > 29)
                {
                    JanelaTitulo(10, 12, "Data inválida\n");
                }
                else
                {
                    mes = meses[nummes];
                    JanelaTitulo(10, 12, dia + " de " + mes);
                }

                Write("\n\nRecomeçar [s/n]? ");
                r = ReadLine();
            } while (r == "s");
        }
        private static void OrdenaVetor()
        {
            Clear();
            JanelaTitulo(20, 2, "ORDENA VETOR");
            SetCursorPosition(10, 6);
            Write("Quantos elementos terá o vetor? ");
            if (!int.TryParse(ReadLine(), out int tamanho) || tamanho <= 0)
            {
                JanelaTitulo(10, 8, "Tamanho inválido.");
                return;
            }

            int[] vetor = new int[tamanho];
            for (int i = 0; i < tamanho; i++)
            {
                Clear();
                JanelaTitulo(20, 2, "ORDENA VETOR");
                SetCursorPosition(10, 6);
                Write($"Digite o valor para a posição {i + 1}: ");
                while (!int.TryParse(ReadLine(), out vetor[i]))
                {
                    JanelaTitulo(10, 8, "Valor inválido. Digite novamente: ");
                }
            }

            BubbleSort(vetor);

            JanelaTitulo(10, 12, "Vetor ordenado:");
            SetCursorPosition(10, 16);
            foreach (var item in vetor)
            {
                Write(item + " ");
            }
            WriteLine("\n\nPressione qualquer tecla para voltar ao menu...");
            ReadKey();
        }
        static void BubbleSort(int[] vetor)
        {
            int n = vetor.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (vetor[j] > vetor[j + 1])
                    {
                        (vetor[j], vetor[j + 1]) = (vetor[j + 1], vetor[j]);
                    }
                }
            }
        }
        static void AdivinhaNum(int nivelAtual)
        {
            bool loop = true;
            string resposta;
            int[] limite = { 10, 50, 100 }, chances = { 100, 15, 10 };

            while (loop)
            {
                Clear();

                JanelaTitulo(20, 2, "ADIVINHA NÚMERO");

                if (nivelAtual == 3)
                {
                    SetCursorPosition(10, 6);
                    Write("Parabéns, você chegou ao fim! Recomeçar [s/n]? ");
                    resposta = ReadLine();
                    if (resposta != "s")
                    {
                        loop = false;
                    }
                    else
                    {
                        nivelAtual = 0;
                    }
                    continue;
                }

                for (int i = nivelAtual; i < 3; i++)
                {
                    Clear();

                    JanelaTitulo(20, 2, "ADIVINHA NÚMERO");

                    SetCursorPosition(10, 6);
                    Write($"Ir para o nível {i + 1} [s/n]? ");
                    resposta = ReadLine();
                    if (resposta == "s")
                    {
                        bool acertou = Tentativas(limite[i], chances[i], i, 8);
                        if (!acertou)
                        {
                            loop = false;
                            break;
                        }
                        else
                        {
                            nivelAtual = i + 1;
                        }
                    }
                    else
                    {
                        loop = false;
                        break;
                    }
                }
            }
        }
        static bool Tentativas(int limite, int chances, int nivel, int y)
        {
            Random aleatorio = new Random();
            int numero = aleatorio.Next(limite), tentativa;
            List<int> tentativas = new List<int>();
            string[] dificuldade = { "FÁCIL", "MÉDIO", "DIFÍCIL" };
            string resposta;

            JanelaTitulo(20, y, $"NÍVEL {dificuldade[nivel]}");

            for (int i = 0; i < chances; i++)
            {
                SetCursorPosition(10, (y + (i * 2) + 4));
                Write($"Digite um número de 0 a {limite} (Você tem {chances - i} tentativas restantes): ");
                tentativa = int.Parse(ReadLine());
                tentativas.Add(tentativa);

                if (tentativa == numero)
                {
                    SetCursorPosition(10, (y + (i * 2) + 5));
                    Write("Você acertou!");
                    Thread.Sleep(3000);
                    return true;
                }
                else
                {
                    SetCursorPosition(10, (y + (i * 2) + 5));
                    Write(tentativa > numero ? "O número é menor." : "O número é maior.");
                    Write(" Tentar novamente [s/n]? ");
                    resposta = ReadLine();
                    if (resposta != "s")
                    {
                        return false;
                    }
                }
            }

            SetCursorPosition(10, (y + (chances * 2) + 6));
            Write("Você ultrapassou o limite.");
            SetCursorPosition(10, (y + (chances * 2) + 8));
            Write("Suas tentativas foram: ");
            foreach (int j in tentativas)
            {
                Write($" {j}");
            }
            Thread.Sleep(5000);

            return false;
        }
        static void Tabuada()
        {
            bool loop = true;
            int numero;
            string[] metade1 = new string[5], metade2 = new string[5];

            while (loop)
            {
                Clear();

                JanelaTitulo(20, 2, "TABUADA");

                SetCursorPosition(10, 6);

                Write("Deseja ver a tabuada de que número? ");
                numero = int.Parse(ReadLine());

                for (int i = 0; i < 5; i++)
                {
                    metade1[i] = $"{i + 1} X {numero} = {(i + 1) * numero}";
                }
                for (int j = 5; j < 10; j++)
                {
                    metade2[j - 5] = $"{j + 1} X {numero} = {(j + 1) * numero}";
                }

                Lista(10, 8, metade1);
                Lista(30, 8, metade2);

                SetCursorPosition(10, 20);
                Write("Deseja continuar? (s/n): ");
                if (ReadLine().ToLower() != "s")
                    loop = false;
            }
        }
        static void Media()
        {
            bool loop = true;
            double[] notas = new double[4];
            double media;

            while (loop)
            {
                Clear();
                JanelaTitulo(20, 2, "MÉDIA");
                for (int i = 0; i < notas.Length; i++)
                {
                    SetCursorPosition(10, 6 + i);
                    Write($"Nota do {i + 1}° bimestre: ");
                    notas[i] = double.Parse(ReadLine());
                }
                media = (notas[0] + notas[1] + notas[2] + notas[3]) / 4;
                if (media >= 9.5)
                {
                    JanelaTitulo(10, 12, "Parabéns, sua nota é MB!!!");
                }
                else if (media < 9.5 && media >= 7.5)
                {
                    JanelaTitulo(10, 12, "Sua nota é B!");
                }
                else if (media < 7.5 && media >= 5)
                {
                    JanelaTitulo(10, 12, "Sua nota é R");
                }
                else
                {
                    JanelaTitulo(10, 12, "Sua nota é I");
                }
                SetCursorPosition(10, 16);
                Write("Deseja continuar? (s/n): ");
                if (ReadLine().ToLower() != "s")
                    loop = false;
            }
        }
        static void AnimacaoTexto()
        {
            bool loop = true, lista;
            string op, frase;
            List<string> list = new List<string>();
            string[] cores = { "[0] Branco", "[1] Preto", "[2] Vermelho", "[3] Amarelo", "[4] Verde", "[5] Azul" };
            int cor, x = 1;

            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Blue;

            while (loop)
            {
                Clear();
                lista = true;
                JanelaTitulo(20, 2, "ANIMAÇÃO DE TEXTO");

                SetCursorPosition(10, 6);
                Write("Deseja fazer uma frase curta[f] ou uma lista[l]?");
                op = ReadLine();
                if (op == "f")
                {
                    SetCursorPosition(10, 8);
                    Write("Digite a frase: ");
                    frase = ReadLine();
                    JanelaTitulo(10, 10, "cor");
                    Lista(10, 14, cores);

                    SetCursorPosition(10, 28);
                    Write("Escolha uma cor para o texto: ");
                    cor = int.Parse(ReadLine());
                    switch (cor)
                    {
                        case 0:
                            BackgroundColor = ConsoleColor.Black;
                            ForegroundColor = ConsoleColor.White;
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.Black;
                            if (BackgroundColor == ConsoleColor.Black)
                            {
                                BackgroundColor = ConsoleColor.White;
                            }
                            break;
                        case 2:
                            ForegroundColor = ConsoleColor.Red;
                            break;
                        case 3:
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 4:
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        case 5:
                            ForegroundColor = ConsoleColor.Blue;
                            break;
                    }
                    SetCursorPosition(10, 30);
                    Write("E uma cor para o fundo: ");
                    cor = int.Parse(ReadLine());
                    switch (cor)
                    {
                        case 0:
                            BackgroundColor = ConsoleColor.White;
                            if (ForegroundColor == ConsoleColor.White)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 1:
                            BackgroundColor = ConsoleColor.Black;
                            if (ForegroundColor == ConsoleColor.Black)
                            {
                                ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 2:
                            BackgroundColor = ConsoleColor.Red;
                            if (ForegroundColor == ConsoleColor.Red)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 3:
                            BackgroundColor = ConsoleColor.Yellow;
                            if (ForegroundColor == ConsoleColor.Yellow)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 4:
                            BackgroundColor = ConsoleColor.Green;
                            if (ForegroundColor == ConsoleColor.Green)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 5:
                            BackgroundColor = ConsoleColor.Blue;
                            if (ForegroundColor == ConsoleColor.Blue)
                            {
                                ForegroundColor = ConsoleColor.Blue;
                            }
                            break;
                    }
                    JanelaTitulo(10, 34, frase);
                    SetCursorPosition(10, 38);
                    Write("Deseja continuar? (s/n): ");
                    if (ReadLine().ToLower() != "s")
                        loop = false;
                }
                else if (op == "l")
                {
                    while (lista)
                    {
                        Clear();
                        JanelaTitulo(20, 2, "ANIMAÇÃO DE TEXTO");

                        SetCursorPosition(10, 6);
                        Write($"Escreva o {x}° item da lista: ");
                        frase = ReadLine();
                        list.Add(frase);

                        SetCursorPosition(10, 8);
                        Write("Deseja continuar? (s/n): ");
                        x++;
                        if (ReadLine().ToLower() != "s")
                            lista = false;
                    }
                    JanelaTitulo(10, 10, "cor");
                    Lista(10, 14, cores);

                    SetCursorPosition(10, 28);
                    Write("Escolha uma cor para o texto: ");
                    cor = int.Parse(ReadLine());
                    switch (cor)
                    {
                        case 0:
                            BackgroundColor = ConsoleColor.Black;
                            ForegroundColor = ConsoleColor.White;
                            break;
                        case 1:
                            ForegroundColor = ConsoleColor.Black;
                            break;
                        case 2:
                            ForegroundColor = ConsoleColor.Red;
                            break;
                        case 3:
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 4:
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        case 5:
                            ForegroundColor = ConsoleColor.Blue;
                            break;
                    }
                    SetCursorPosition(10, 30);
                    Write("E uma cor para o fundo: ");
                    cor = int.Parse(ReadLine());
                    switch (cor)
                    {
                        case 0:
                            BackgroundColor = ConsoleColor.White;
                            if (ForegroundColor == ConsoleColor.White)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 1:
                            BackgroundColor = ConsoleColor.Black;
                            if (ForegroundColor == ConsoleColor.Black)
                            {
                                ForegroundColor = ConsoleColor.White;
                            }
                            break;
                        case 2:
                            BackgroundColor = ConsoleColor.Red;
                            if (ForegroundColor == ConsoleColor.Red)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 3:
                            BackgroundColor = ConsoleColor.Yellow;
                            if (ForegroundColor == ConsoleColor.Yellow)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 4:
                            BackgroundColor = ConsoleColor.Green;
                            if (ForegroundColor == ConsoleColor.Green)
                            {
                                ForegroundColor = ConsoleColor.Black;
                            }
                            break;
                        case 5:
                            BackgroundColor = ConsoleColor.Blue;
                            if (ForegroundColor == ConsoleColor.Blue)
                            {
                                ForegroundColor = ConsoleColor.Blue;
                            }
                            break;
                    }
                    Lista(10, 32, list.ToArray());
                    SetCursorPosition(10, (36 + list.ToArray().Length));
                    Write("Deseja continuar? (s/n): ");
                    if (ReadLine().ToLower() != "s")
                        loop = false;
                }
            }
        }
        static void JanelaTitulo(int x, int y, string titulo)
        {
            string cse = "╔", csd = "╗", cie = "╚", cid = "╝", hor = "═", ver = "║";
            SetCursorPosition(x, y);
            Write(cse);
            for (int i = 0; i < titulo.Length; i++)
            {
                Write(hor);
            }
            Write(csd);
            SetCursorPosition(x, (y + 1));
            Write(ver + titulo + ver);
            SetCursorPosition(x, (y + 2));
            Write(cie);
            for (int i = 0; i < titulo.Length; i++)
            {
                Write(hor);
            }
            Write(cid);
        }
        static void Lista(int x, int y, string[] lista)
        {
            string cse = "╔", csd = "╗", cie = "╚", cid = "╝", hor = "═", ver = "║", dive = "╠",
                   divd = "╣";
            int maior = 0, resto;

            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i].Length > maior)
                {
                    maior = lista[i].Length;
                }
            }
            for (int j = 0; j < lista.Length; j++)
            {
                SetCursorPosition(x, (y + (j * 2)));
                if (j == 0)
                {
                    Write(cse);
                }
                else
                {
                    Write(dive);
                }
                for (int k = 0; k < maior; k++)
                {
                    Write(hor);
                }
                if (j == 0)
                {
                    Write(csd);
                }
                else
                {
                    Write(divd);
                }
                SetCursorPosition(x, (y + (j * 2) + 1));
                resto = maior - lista[j].Length;
                Write(ver);
                Write(lista[j]);
                for (int l = 0; l < resto; l++)
                {
                    Write(" ");
                }
                Write(ver);
                if (j == lista.Length - 1)
                {
                    SetCursorPosition(x, (y + (j * 2) + 2));
                    Write(cie);
                    for (int m = 0; m < maior; m++)
                    {
                        Write(hor);
                    }
                    Write(cid);
                }
            }
        }
    }
}