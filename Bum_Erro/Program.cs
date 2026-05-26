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
    }

    static void Main(string[] args)
    {

        User_Pra_Tudo p = new User_Pra_Tudo();
        

        Console.WriteLine(" ola user==?? qual arquivo voce vai quere criptografar ? ");
        Console.WriteLine(" arraste o o nome por em texto do arquivo que voce quer criptografar  ");
        p.Interagir = Console.ReadLine().Trim().Replace(" ", "");
        p.arquivo = p.Interagir;
        Console.WriteLine(" carregando... ");
        try
        {
            
            if (File.Exists(p.arquivo))
            {
                criptor criptografar = new criptor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" arquivo encontradao com sucesso!");
                Console.ResetColor();
                
                criptografar.GerarChaveSegura();
                
                
                byte[] bytesOriginais = File.ReadAllBytes(p.arquivo);
                Console.WriteLine($" Tamanho Original do arquivo: {bytesOriginais.Length} bytes.");

                
                byte[] bytesProntos = criptografar.AplicarPadding(bytesOriginais);
    
                
                Console.WriteLine($" Novo tamanho (Múltiplo de 8): {bytesProntos.Length} bytes.");
    
               
                byte ultimoByte = bytesProntos[bytesProntos.Length - 1];
                Console.WriteLine($" O número injetado no final foi: {ultimoByte}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" arquivo não existe ");
                Console.ResetColor();
            }
        }
        catch (FileNotFoundException erro )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erro.Message);
        }
    }
}




