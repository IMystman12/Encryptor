using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PuzzleEncryption
{
    #region 1. ø≠»ˆ√‹¬Î (Caesar Cipher) - æ≠µ‰ÃÊªª√‹¬Î
    public static string CaesarEncrypt(string plainText, int shift)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        char[] buffer = plainText.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];

            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)(((letter + shift - offset) % 26) + offset);
                buffer[i] = letter;
            }
        }
        return new string(buffer);
    }

    public static string CaesarDecrypt(string cipherText, int shift)
    {
        return CaesarEncrypt(cipherText, 26 - (shift % 26));
    }
    #endregion

    #region 2. Atbash√‹¬Î - ◊÷ƒ∏∑¥œÚÃÊªª
    public static string AtbashEncrypt(string text)
    {
        return AtbashDecrypt(text); // Atbashº”√‹Ω‚√‹œ‡Õ¨
    }

    public static string AtbashDecrypt(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;

        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            if (char.IsLetter(buffer[i]))
            {
                if (char.IsUpper(buffer[i]))
                {
                    buffer[i] = (char)('Z' - (buffer[i] - 'A'));
                }
                else
                {
                    buffer[i] = (char)('z' - (buffer[i] - 'a'));
                }
            }
        }
        return new string(buffer);
    }
    #endregion

    #region 3. Œ¨º™ƒ·—«√‹¬Î (Vigen®®re Cipher) - ∂‡±ÌÃÊªª
    public static string VigenereEncrypt(string plainText, string key)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        key = key.ToUpper();
        StringBuilder result = new StringBuilder();
        int keyIndex = 0;

        foreach (char c in plainText)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                int shift = key[keyIndex % key.Length] - 'A';
                char encrypted = (char)(((c - offset + shift) % 26) + offset);
                result.Append(encrypted);
                keyIndex++;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    public static string VigenereDecrypt(string cipherText, string key)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        key = key.ToUpper();
        StringBuilder result = new StringBuilder();
        int keyIndex = 0;

        foreach (char c in cipherText)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                int shift = key[keyIndex % key.Length] - 'A';
                char decrypted = (char)(((c - offset - shift + 26) % 26) + offset);
                result.Append(decrypted);
                keyIndex++;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
    #endregion

    #region 4. ROT13 - Ãÿ ‚µƒø≠»ˆ√‹¬Î
    public static string Rot13Encrypt(string text)
    {
        return CaesarEncrypt(text, 13);
    }

    public static string Rot13Decrypt(string text)
    {
        return Rot13Encrypt(text); // ROT13º”√‹Ω‚√‹œ‡Õ¨
    }
    #endregion

    #region 5. ’§¿∏√‹¬Î (Rail Fence Cipher)
    public static string RailFenceEncrypt(string plainText, int rails)
    {
        if (string.IsNullOrEmpty(plainText) || rails < 2) return plainText;

        List<StringBuilder> fence = new List<StringBuilder>();
        for (int i = 0; i < rails; i++)
            fence.Add(new StringBuilder());

        int rail = 0;
        bool down = false;

        foreach (char c in plainText)
        {
            fence[rail].Append(c);

            if (rail == 0 || rail == rails - 1)
                down = !down;

            rail += down ? 1 : -1;
        }

        StringBuilder result = new StringBuilder();
        foreach (var sb in fence)
            result.Append(sb.ToString());

        return result.ToString();
    }

    public static string RailFenceDecrypt(string cipherText, int rails)
    {
        if (string.IsNullOrEmpty(cipherText) || rails < 2) return cipherText;

        // ¥¥Ω®’§¿∏ƒ£ Ω
        int[] railLengths = new int[rails];
        int rail = 0;
        bool down = false;

        for (int i = 0; i < cipherText.Length; i++)
        {
            railLengths[rail]++;

            if (rail == 0 || rail == rails - 1)
                down = !down;

            rail += down ? 1 : -1;
        }

        // ÃÓ≥‰’§¿∏
        List<List<char>> fence = new List<List<char>>();
        int index = 0;

        for (int i = 0; i < rails; i++)
        {
            fence.Add(new List<char>());
            for (int j = 0; j < railLengths[i]; j++)
            {
                fence[i].Add(cipherText[index++]);
            }
        }

        // ∂¡»°Ω‚√‹Œƒ±æ
        StringBuilder result = new StringBuilder();
        int[] railIndices = new int[rails];
        rail = 0;
        down = false;

        for (int i = 0; i < cipherText.Length; i++)
        {
            result.Append(fence[rail][railIndices[rail]++]);

            if (rail == 0 || rail == rails - 1)
                down = !down;

            rail += down ? 1 : -1;
        }

        return result.ToString();
    }
    #endregion

    #region 6. ≈‡∏˘√‹¬Î (Baconian Cipher) - ∂˛Ω¯÷∆ÃÊªª
    private static readonly Dictionary<char, string> baconCipherMap = new Dictionary<char, string>()
        {
            {'A', "aaaaa"}, {'B', "aaaab"}, {'C', "aaaba"}, {'D', "aaabb"}, {'E', "aabaa"},
            {'F', "aabab"}, {'G', "aabba"}, {'H', "aabbb"}, {'I', "abaaa"}, {'J', "abaab"},
            {'K', "ababa"}, {'L', "ababb"}, {'M', "abbaa"}, {'N', "abbab"}, {'O', "abbba"},
            {'P', "abbbb"}, {'Q', "baaaa"}, {'R', "baaab"}, {'S', "baaba"}, {'T', "baabb"},
            {'U', "babaa"}, {'V', "babab"}, {'W', "babba"}, {'X', "babbb"}, {'Y', "bbaaa"},
            {'Z', "bbaab"}
        };

    private static readonly Dictionary<string, char> baconDecipherMap =
        baconCipherMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

    public static string BaconianEncrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        StringBuilder result = new StringBuilder();

        foreach (char c in plainText.ToUpper())
        {
            if (char.IsLetter(c) && baconCipherMap.ContainsKey(c))
            {
                result.Append(baconCipherMap[c] + " ");
            }
            else if (c == ' ')
            {
                result.Append("/ ");
            }
        }

        return result.ToString().Trim();
    }

    public static string BaconianDecrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        StringBuilder result = new StringBuilder();
        string[] parts = cipherText.ToLower().Split(' ');

        foreach (string part in parts)
        {
            if (part == "/")
            {
                result.Append(' ');
            }
            else if (baconDecipherMap.ContainsKey(part))
            {
                result.Append(baconDecipherMap[part]);
            }
        }

        return result.ToString();
    }
    #endregion

    #region 7. Base64±‡¬Î (≥£”√”⁄ºÚµ•“˛≤ÿ)
    public static string Base64Encode(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        if (string.IsNullOrEmpty(base64EncodedData)) return base64EncodedData;

        byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }
    #endregion

    #region 8. ºÚµ•“ÏªÚº”√‹
    public static string XOREncrypt(string plainText, string key)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < plainText.Length; i++)
        {
            char c = plainText[i];
            char keyChar = key[i % key.Length];
            result.Append((char)(c ^ keyChar));
        }

        return result.ToString();
    }

    public static string XORDecrypt(string cipherText, string key)
    {
        return XOREncrypt(cipherText, key); // “ÏªÚº”√‹Ω‚√‹œ‡Õ¨
    }
    #endregion

    #region 9. ƒ¶ÀπµÁ¬Î (Morse Code)
    private static readonly Dictionary<char, string> morseCodeMap = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
            {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {'0', "-----"}, {' ', "/"}
        };

    private static readonly Dictionary<string, char> morseDecodeMap =
        morseCodeMap.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

    public static string MorseEncode(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        StringBuilder result = new StringBuilder();
        plainText = plainText.ToUpper();

        for (int i = 0; i < plainText.Length; i++)
        {
            char c = plainText[i];
            if (morseCodeMap.ContainsKey(c))
            {
                result.Append(morseCodeMap[c]);
                if (i < plainText.Length - 1 && plainText[i + 1] != ' ')
                    result.Append(' ');
            }
        }

        return result.ToString();
    }

    public static string MorseDecode(string morseText)
    {
        if (string.IsNullOrEmpty(morseText)) return morseText;

        StringBuilder result = new StringBuilder();
        string[] codes = morseText.Split(' ');

        foreach (string code in codes)
        {
            if (morseDecodeMap.ContainsKey(code))
            {
                result.Append(morseDecodeMap[code]);
            }
            else if (code == "/" || code == "")
            {
                result.Append(' ');
            }
        }

        return result.ToString();
    }
    #endregion

    #region 10. ºÚµ•÷√ªª√‹¬Î (Transposition Cipher)
    public static string TranspositionEncrypt(string plainText, int key)
    {
        if (string.IsNullOrEmpty(plainText) || key <= 1) return plainText;

        int cols = key;
        int rows = (int)Math.Ceiling((double)plainText.Length / cols);
        char[,] grid = new char[rows, cols];

        int index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (index < plainText.Length)
                    grid[row, col] = plainText[index++];
                else
                    grid[row, col] = 'X'; // ÃÓ≥‰◊÷∑˚
            }
        }

        StringBuilder result = new StringBuilder();
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                result.Append(grid[row, col]);
            }
        }

        return result.ToString();
    }

    public static string TranspositionDecrypt(string cipherText, int key)
    {
        if (string.IsNullOrEmpty(cipherText) || key <= 1) return cipherText;

        int cols = key;
        int rows = (int)Math.Ceiling((double)cipherText.Length / cols);
        char[,] grid = new char[rows, cols];

        int index = 0;
        for (int col = 0; col < cols; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (index < cipherText.Length)
                    grid[row, col] = cipherText[index++];
            }
        }

        StringBuilder result = new StringBuilder();
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] != '\0')
                    result.Append(grid[row, col]);
            }
        }

        return result.ToString().TrimEnd('X');
    }
    #endregion

    #region 11. A1Z26√‹¬Î (◊÷ƒ∏◊™ ˝◊÷)
    public static string A1Z26Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        StringBuilder result = new StringBuilder();
        plainText = plainText.ToUpper();

        foreach (char c in plainText)
        {
            if (char.IsLetter(c))
            {
                int number = c - 'A' + 1;
                result.Append(number.ToString() + "-");
            }
            else if (c == ' ')
            {
                result.Append("/ ");
            }
        }

        return result.ToString().TrimEnd('-');
    }

    public static string A1Z26Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        StringBuilder result = new StringBuilder();
        string[] parts = cipherText.Split(' ');

        foreach (string part in parts)
        {
            if (part == "/")
            {
                result.Append(' ');
            }
            else
            {
                string[] numbers = part.Split('-');
                foreach (string numStr in numbers)
                {
                    if (int.TryParse(numStr, out int num) && num >= 1 && num <= 26)
                    {
                        result.Append((char)('A' + num - 1));
                    }
                }
            }
        }

        return result.ToString();
    }
    #endregion
}
