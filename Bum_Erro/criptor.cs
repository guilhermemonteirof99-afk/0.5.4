using System.Security.Cryptography;
namespace bum_erro;

public class criptor
{
    private byte[] Sbox;
    private int[] Pbox;
    public byte[] chave { private set; get; }

    public criptor()
    {
        chave=new byte[16];
        Sbox=new byte[8];
        Pbox=new int[8];
    }
    
    public string GerarChaveSegura()
    {
        RandomNumberGenerator.Fill(chave);
        
        return Convert.ToBase64String(chave);
    }

    public byte[] AplicarPadding(byte[] arquivoOriginal)
    {
        
        int sobra = arquivoOriginal.Length % 8;
    
        
        byte bytesFaltando = (byte)(8 - sobra);

        
        int novoTamanho = arquivoOriginal.Length + bytesFaltando;
        byte[] arquivoComPadding = new byte[novoTamanho];

        
        Array.Copy(arquivoOriginal, arquivoComPadding, arquivoOriginal.Length);

        
        for (int i = arquivoOriginal.Length; i < arquivoComPadding.Length; i++)
        {
            arquivoComPadding[i] = bytesFaltando;
        }

        
        return arquivoComPadding;
    }

    public static void vetorInicial()
    {
        byte[] VI = new byte[16];
        
        RandomNumberGenerator.Fill(VI);
        
        Convert.ToBase64String(VI);
    }

    
}