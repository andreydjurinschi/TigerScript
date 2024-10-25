using System;


public class TigerHash 
{
    private static readonly byte[] H0 =
    [
        0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF
    ];

    private static readonly byte[] H1 =
    [
        0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10
    ];

    private static readonly byte[] H2 =
    [
        0xF0, 0x96, 0xA5, 0xB4, 0xC3, 0xB2, 0xE1, 0x87
    ];

    private static readonly byte[][] H = { H0, H1, H2 };

    private static readonly int[] _sBlocks = { 0xB1, 0xA2, 0xC4, 0xF6, 0x8D, 0xE3, 0xC3, 0xD7 };


    public static void Main(string[] args) {
        string myWord = "ADCRYPTO";
        byte[] stringToDecimal = System.Text.Encoding.UTF8.GetBytes(myWord);
        Console.WriteLine("Bytes: " + ToHex(stringToDecimal));
        Console.WriteLine("Байты: " + ToHex(stringToDecimal));
        byte[] SBlocksResult = SBlocks(stringToDecimal);
        Console.WriteLine("S Blocks " + ToHex(SBlocksResult));
        byte[] permutation = Permutation(SBlocksResult);
        Console.WriteLine("Результат после перестановок: " + ToHex(permutation));
        byte[] afterShift = BitShift(permutation);
        Console.WriteLine("Результат после сдвига: " + ToHex(afterShift));
    }

    private static string[] ToHex(byte[] input) 
    {
        string[] result = new string[input.Length];
        for (int i = 0; i < input.Length; i++) 
        {
            int ascciValue = (int)input[i];
            result[i] = input[i].ToString("X2");
        }
        return result;
    }

    private static byte[] SBlocks(byte[] input) 
    {
        byte[] result = new byte[input.Length];
        for (int i = 0; i < input.Length; i++) 
        {
            result[i] = (byte)_sBlocks[i];
        }
        return result;
    
    }

    private static byte[] Permutation(byte[] input) 
    {
        byte[] result = new byte[input.Length];
        int[] permutationOrder = {2,3,1,4,0,6,7,5};
        for (int i = 0; i < permutationOrder.Length; i++) {
            result[i] = input[permutationOrder[i]];
        }
        return result;
    }

    private static byte[] BitShift(byte[] input) 
    {
        byte[] result = new byte[input.Length];
        for (int i = 0; i < input.Length; i++) 
        {
            result[i] = (byte)(input[i] << 2);
        }
        return result;
    }
}