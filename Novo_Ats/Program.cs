using System;
namespace Novo_Ats;

class Program
{
    class ParaTudo
    {
        public int Numeros_Saida_User { get; set; }
        public int Numeros_Endrada_User { get; set; } 
            public int Cofre_Numeros_User{ get; set;} 
            public int[] Guarda_Posicao { get; set; }
    }

    static void Main(string[] args)
    {
        ParaTudo tudo = new ParaTudo();
        tudo.Guarda_Posicao = new int[10];
        tudo.Cofre_Numeros_User = 0;


        for (int Rodadas = 0; Rodadas < 10; Rodadas++)
        {
            try
            {
            Console.WriteLine(" informe a posição ");
            tudo.Cofre_Numeros_User = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("informe o numero pra fica nele ");
            tudo.Numeros_Endrada_User = Convert.ToInt32(Console.ReadLine());

            tudo.Guarda_Posicao[tudo.Cofre_Numeros_User] = tudo.Numeros_Endrada_User;

            Console.WriteLine(
                $" posição {tudo.Cofre_Numeros_User}  numero dentro da pocião e {tudo.Numeros_Endrada_User}  essa e a rodada {Rodadas+1}");
            
            }
            catch (FormatException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("formato incorreto do texto ");
                Rodadas -= 1;
            }
            catch (IndexOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("posicao invalido");
                Rodadas -= 1;
            }
            
        }
    }
}