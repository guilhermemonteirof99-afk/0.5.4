using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using bum_erro;

class Program
{
    class User_Pra_Tudo
    {
        public string Interagir;
        public string arquivo;
        public string arquivoCompleto;
        public int opcoes;
    }

    static void Main(string[] args)
    {

        User_Pra_Tudo p = new User_Pra_Tudo();
        criptor criptografar = new criptor();
        Console.WriteLine(" ola vamos criptografar ou descriptografar ? ,lembre esse sistema vai ser so pra arguivos ");
        Console.WriteLine(" opção [1] criptografar ");
        Console.WriteLine(" opção [2]  descriptografar ");
        p.opcoes = Convert.ToInt32(Console.ReadLine());
        try
        {
            if (p.opcoes == 1)
            {

                Console.WriteLine(" escreva o nome e ponha em texto do arquivo que voce quer criptografar  ");
                p.Interagir = Console.ReadLine().Trim().Replace(" ", "");
                p.arquivo = p.Interagir;
                Console.WriteLine(" carregando... ");
                try
                {

                    if (File.Exists(p.arquivo))
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" arquivo encontradao com sucesso!");


                        string BaseChave = criptografar.GerarChaveSegura();
                        string baseVI = criptografar.vetorInicial();

                        string guardakey = p.arquivo + ".key";
                        File.WriteAllText(guardakey, BaseChave + "\n" + baseVI);

                        byte[] bytesOriginais = File.ReadAllBytes(p.arquivo);

                        Console.WriteLine($" Tamanho Original do arquivo: {bytesOriginais.Length} bytes.");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(" criptografando seu arquivo! ");
                        Console.ResetColor();

                        byte[] CifraArquivo = criptografar.Criptografia_Pessoal_Modo_CBC(bytesOriginais);

                        p.arquivoCompleto = p.arquivo + ".trancado";
                        File.WriteAllBytes(p.arquivoCompleto, CifraArquivo);
                        string IntegridadeHash = criptografar.lacreHash(CifraArquivo);

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"ciragem feita com sucesso! arquivo esta cifrado em {p.arquivoCompleto}");
                        Console.WriteLine(
                            $" arquivo cifrado e com seu hash sha256 original : {IntegridadeHash} , qulquer suspeita verifique o hash para garantir a integridade do arquivo ");
                        Console.WriteLine(
                            $"chave salva em {guardakey} para desigrame e cifragem lembra de guarda bem na sua trasmião da chave cuidado!!! ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" arquivo não existe ");
                        Console.ResetColor();
                    }
                }
                catch (FileNotFoundException erro)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(erro.Message);
                }
            }
            else if (p.opcoes == 2)
            {

            }
        }
        catch (FormatException erro)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erro.Message);
            Console.ResetColor();
        }
    }
}




