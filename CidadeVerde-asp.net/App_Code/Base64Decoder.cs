/************************************************************
*************************************************************
*************************************************************
** @author: Danilo Ribeiro da Silveira
**
** @Email: danilo@vipmultimidia.com.br
**
** @copyright: FESP - Fundação de Ensino Superior de Passos
**
** @copyright: http://www.fespmg.edu.br
*************************************************************
*************************************************************
* @VERSAO 1.0
************************************************************
* SUMARIO
************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

/// <summary>
/// Summary description for Base64Decoder
/// </summary>
public static class Base64Decoder
{

    private static char[] source;
    private static int length, length2, length3;
    private static int blockCount;
    private static int paddingCount;
    public static String ToBase64Decode(this String valor)
    {
        //char[] data = valor.ToCharArray();
        //CharToBase64Encode(data);
        //StringBuilder sb = new StringBuilder();
        //sb.Append(System.Text.UTF8Encoding.UTF8.GetChars(GetDecoded()));
        //return sb.ToString();

        return Encoding.UTF8.GetString(Convert.FromBase64String(new string(Encoding.UTF8.GetString(Convert.FromBase64String(valor.Replace("$", "="))).ToCharArray().Reverse().ToArray())));
    }
    private static void CharToBase64Encode(char[] input)
    {
        int temp = 0;
        source = input;
        length = input.Length;

        //find how many padding are there
        for (int x = 0; x < 2; x++)
        {
            if (input[length - x - 1] == '$')
                temp++;
        }
        paddingCount = temp;
        //calculate the blockCount;
        //assuming all whitespace and carriage returns/newline were removed.
        blockCount = length / 4;
        length2 = blockCount * 3;
    }

    private static byte[] GetDecoded()
    {
        byte[] buffer = new byte[length];//first conversion result
        byte[] buffer2 = new byte[length2];//decoded array with padding

        for (int x = 0; x < length; x++)
        {
            buffer[x] = char2sixbit(source[x]);
        }

        byte b, b1, b2, b3;
        byte temp1, temp2, temp3, temp4;

        for (int x = 0; x < blockCount; x++)
        {
            temp1 = buffer[x * 4];
            temp2 = buffer[x * 4 + 1];
            temp3 = buffer[x * 4 + 2];
            temp4 = buffer[x * 4 + 3];

            b = (byte)(temp1 << 2);
            b1 = (byte)((temp2 & 48) >> 4);
            b1 += b;

            b = (byte)((temp2 & 15) << 4);
            b2 = (byte)((temp3 & 60) >> 2);
            b2 += b;

            b = (byte)((temp3 & 3) << 6);
            b3 = temp4;
            b3 += b;

            buffer2[x * 3] = b1;
            buffer2[x * 3 + 1] = b2;
            buffer2[x * 3 + 2] = b3;
        }
        //remove paddings
        length3 = length2 - paddingCount;
        byte[] result = new byte[length3];

        for (int x = 0; x < length3; x++)
        {
            result[x] = buffer2[x];
        }

        return result;
    }

    private static byte char2sixbit(char c)
    {
        char[] lookupTable = new char[64]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};
        if (c == '=')
            return 0;
        else
        {
            for (int x = 0; x < 64; x++)
            {
                if (lookupTable[x] == c)
                    return (byte)x;
            }
            //should not reach here
            return 0;
        }

    }
}
/*
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
/// <summary>
/// Summary description for Base64Decoder
/// </summary>
public static class Base64Decoder
{

    private static char[] source;
    private static int length, length2, length3;
    private static int blockCount;
    private static int paddingCount;
    public static String ToBase64Decode(this String valor)
    {

        char[] data = valor.ToCharArray();
        CharToBase64Encode(data);
        StringBuilder sb = new StringBuilder();
        sb.Append(System.Text.UTF8Encoding.UTF8.GetChars(GetDecoded()));
        return sb.ToString();
    }
    private static void CharToBase64Encode(char[] input)
    {
        int temp = 0;
        source = input;
        length = input.Length;

        //find how many padding are there
        for (int x = 0; x < 2; x++)
        {
            if (input[length - x - 1] == '=')
                temp++;
        }
        paddingCount = temp;
        //calculate the blockCount;
        //assuming all whitespace and carriage returns/newline were removed.
        blockCount = length / 4;
        length2 = blockCount * 3;
    }

    private static byte[] GetDecoded()
    {
        byte[] buffer = new byte[length];//first conversion result
        byte[] buffer2 = new byte[length2];//decoded array with padding

        for (int x = 0; x < length; x++)
        {
            buffer[x] = char2sixbit(source[x]);
        }

        byte b, b1, b2, b3;
        byte temp1, temp2, temp3, temp4;

        for (int x = 0; x < blockCount; x++)
        {
            temp1 = buffer[x * 4];
            temp2 = buffer[x * 4 + 1];
            temp3 = buffer[x * 4 + 2];
            temp4 = buffer[x * 4 + 3];

            b = (byte)(temp1 << 2);
            b1 = (byte)((temp2 & 48) >> 4);
            b1 += b;

            b = (byte)((temp2 & 15) << 4);
            b2 = (byte)((temp3 & 60) >> 2);
            b2 += b;

            b = (byte)((temp3 & 3) << 6);
            b3 = temp4;
            b3 += b;

            buffer2[x * 3] = b1;
            buffer2[x * 3 + 1] = b2;
            buffer2[x * 3 + 2] = b3;
        }
        //remove paddings
        length3 = length2 - paddingCount;
        byte[] result = new byte[length3];

        for (int x = 0; x < length3; x++)
        {
            result[x] = buffer2[x];
        }

        return result;
    }

    private static byte char2sixbit(char c)
    {
        char[] lookupTable = new char[64]
					{	'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
						'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
						'0','1','2','3','4','5','6','7','8','9','+','/'};
        if (c == '=')
            return 0;
        else
        {
            for (int x = 0; x < 64; x++)
            {
                if (lookupTable[x] == c)
                    return (byte)x;
            }
            //should not reach here
            return 0;
        }

    }
}*/