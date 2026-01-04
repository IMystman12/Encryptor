using System.Text;
using System;

EncryptorType et = EncryptorType.Caesar;
TextEncoderType etp = TextEncoderType.Default;
Encoding encoding = Encoding.Default;

while (true)
{
    PrintCurrentMode();
    switch (ChooseType())
    {
        case TypeMode.PlaceholderTexts:
            Console.WriteLine("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Console.WriteLine("abcdefghijklmnopqrstuvwxyz");
            Console.WriteLine("AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz");
            Whitespace();
            Console.WriteLine("A B C D E F G H I J K L M N O P Q R S T U V W X Y Z");
            Console.WriteLine("a b c d e f g h i j k l m n o p q r s t u v w x y z");
            Console.WriteLine("Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz");
            Whitespace();
            Console.WriteLine("Lorem ipsum");
            Whitespace();
            Console.WriteLine("Placeholder");
            Console.WriteLine("PLACEHOLDER");
            Whitespace();
            Console.WriteLine("The quick brown fox jumps over the lazy dog.");
            break;
        case TypeMode.ChooseEncrypte:
            ChooseEncryptorType();
            break;
        case TypeMode.Encrypte:
            switch (et)
            {
                case EncryptorType.Caesar:
                    string a = TextSampler("plainText"), b = TextSampler("shift");
                    int c;
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("shift");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.CaesarEncrypt(a, c)}");
                    break;
                case EncryptorType.Atbash:
                    a = TextSampler("text");
                    Console.WriteLine($"Result: {PuzzleEncryption.AtbashEncrypt(a)}");
                    break;
                case EncryptorType.Vigenère:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    Console.WriteLine($"Result: {PuzzleEncryption.VigenereEncrypt(a, b)}");
                    break;
                case EncryptorType.ROT13:
                    a = TextSampler("text");
                    Console.WriteLine($"Result: {PuzzleEncryption.Rot13Encrypt(a)}");
                    break;
                case EncryptorType.RailFence:
                    a = TextSampler("plainText");
                    b = TextSampler("rails");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("rails");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.RailFenceEncrypt(a, c)}");
                    break;
                case EncryptorType.Baconian:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.BaconianEncrypt(a)}");
                    break;
                case EncryptorType.Base64:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.Base64Encode(a)}");
                    break;
                case EncryptorType.XOR:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    Console.WriteLine($"Result: {PuzzleEncryption.XOREncrypt(a, b)}");
                    break;
                case EncryptorType.Morse:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.MorseEncode(a)}");
                    break;
                case EncryptorType.Transposition:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("key");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.TranspositionEncrypt(a, c)}");
                    break;
                case EncryptorType.A1Z26:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.A1Z26Encrypt(a)}");
                    break;
                case EncryptorType.ForceEncoded:
                    ChooseEncoderType();
                    a = TextSampler("plainText");
                    Console.WriteLine(EncodeEncrypte(a));
                    break;
                case EncryptorType.DitherUpper:
                    a = TextSampler("plainText");
                    Console.WriteLine(DitherUpper(a));
                    break;
                case EncryptorType.ReverseUpper:
                    a = TextSampler("plainText");
                    Console.WriteLine(ReverseUpper(a));
                    break;
                case EncryptorType.RandomUpper:
                    a = TextSampler("plainText");
                    b = TextSampler("seed");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("seed");
                    }
                    Console.WriteLine($"Result: {RandomUpper(a, c)}");
                    break;
                case EncryptorType.EnumLength:
                    break;
                case EncryptorType.Null:
                    break;
            }
            break;
        case TypeMode.Decrypte:
            switch (et)
            {
                case EncryptorType.Caesar:
                    string a = TextSampler("plainText"), b = TextSampler("shift");
                    int c;
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("shift");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.CaesarDecrypt(a, c)}");
                    break;
                case EncryptorType.Atbash:
                    a = TextSampler("text");
                    Console.WriteLine($"Result: {PuzzleEncryption.AtbashDecrypt(a)}");
                    break;
                case EncryptorType.Vigenère:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    Console.WriteLine($"Result: {PuzzleEncryption.VigenereDecrypt(a, b)}");
                    break;
                case EncryptorType.ROT13:
                    a = TextSampler("text");
                    Console.WriteLine($"Result: {PuzzleEncryption.Rot13Decrypt(a)}");
                    break;
                case EncryptorType.RailFence:
                    a = TextSampler("plainText");
                    b = TextSampler("rails");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("rails");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.RailFenceDecrypt(a, c)}");
                    break;
                case EncryptorType.Baconian:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.BaconianDecrypt(a)}");
                    break;
                case EncryptorType.Base64:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.Base64Decode(a)}");
                    break;
                case EncryptorType.XOR:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    Console.WriteLine($"Result: {PuzzleEncryption.XORDecrypt(a, b)}");
                    break;
                case EncryptorType.Morse:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.MorseDecode(a)}");
                    break;
                case EncryptorType.Transposition:
                    a = TextSampler("plainText");
                    b = TextSampler("key");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("key");
                    }
                    Console.WriteLine($"Result: {PuzzleEncryption.TranspositionDecrypt(a, c)}");
                    break;
                case EncryptorType.A1Z26:
                    a = TextSampler("plainText");
                    Console.WriteLine($"Result: {PuzzleEncryption.A1Z26Decrypt(a)}");
                    break;
                case EncryptorType.ForceEncoded:
                    ChooseEncoderType();
                    a = TextSampler("plainText");
                    Console.WriteLine(EncodeDecrypte(a));
                    break;
                case EncryptorType.DitherUpper:
                    a = TextSampler("plainText");
                    Console.WriteLine(DitherLower(a));
                    break;
                case EncryptorType.ReverseUpper:
                    a = TextSampler("plainText");
                    Console.WriteLine(ReverseUpper(a));
                    break;
                case EncryptorType.RandomUpper:
                    a = TextSampler("plainText");
                    b = TextSampler("seed");
                    while (!int.TryParse(b, out c))
                    {
                        b = TextSampler("seed");
                    }
                    Console.WriteLine($"Result: {RandomLower(a, c)}");
                    break;
                case EncryptorType.EnumLength:
                    break;
                case EncryptorType.Null:
                    break;
            }
            break;
    }
    Whitespace();
}

void PrintCurrentMode()
{
    Console.WriteLine($"Encryptor: {et}");
    Whitespace();
}

void Whitespace()
{
    Console.WriteLine();
}

string ToString(byte[] bytes)
{
    return encoding.GetString(bytes);
}

byte[] GetBytes(string txt)
{
    return encoding.GetBytes(txt);
}

string TextSampler(string thingName = "text")
{
    Console.WriteLine($"Type {thingName}:");
    return Console.ReadLine();
}

TypeMode ChooseType()
{
    int val0;
    bool flag = true;
    while (flag)
    {
        Console.WriteLine("Type intger number to choose the encryptor!");
        for (int i = 0; i < (int)TypeMode.EnumLength; i++)
        {
            Console.WriteLine($"{i}.{(TypeMode)i}");
        }
        Whitespace();
        while (!int.TryParse(Console.ReadLine(), out val0))
        {
        }
        Whitespace();
        if (!(val0 >= (int)TypeMode.EnumLength || val0 < 0))
        {
            flag = false;
            Whitespace();
            return (TypeMode)val0;
        }
    }
    return TypeMode.Null;
}

void ChooseEncoderType()
{
    int val0;
    bool flag = true;
    while (flag)
    {
        Console.WriteLine("Type intger number to choose the text encoder!");
        for (int i = 0; i < (int)TextEncoderType.EnumLength; i++)
        {
            Console.WriteLine($"{i}.{(TextEncoderType)i}");
        }
        val0 = int.Parse(Console.ReadLine());
        if (!(val0 >= (int)TextEncoderType.EnumLength || val0 < 0))
        {
            flag = false;
            etp = (TextEncoderType)val0;
            switch (etp)
            {
                case TextEncoderType.UTF8:
                    encoding = Encoding.UTF8;
                    break;
                case TextEncoderType.UTF7:
                    encoding = Encoding.UTF7;
                    break;
                case TextEncoderType.UTF32:
                    encoding = Encoding.UTF32;
                    break;
                case TextEncoderType.Unicode:
                    encoding = Encoding.Unicode;
                    break;
                case TextEncoderType.BigEndianUnicode:
                    encoding = Encoding.BigEndianUnicode;
                    break;
                case TextEncoderType.Latin1:
                    encoding = Encoding.Latin1;
                    break;
                case TextEncoderType.ASCII:
                    encoding = Encoding.ASCII;
                    break;
                case TextEncoderType.Default:
                    encoding = Encoding.Default;
                    break;
            }
        }
    }
}

void ChooseEncryptorType()
{
    int val0;
    bool flag = true;
    while (flag)
    {
        Console.WriteLine("Type intger number to choose the encryptor!");
        for (int i = 0; i < (int)EncryptorType.EnumLength; i++)
        {
            Console.WriteLine($"{i}.{(EncryptorType)i}");
        }
        Whitespace();
        while (!int.TryParse(Console.ReadLine(), out val0))
        {
        }
        if (!(val0 >= (int)EncryptorType.EnumLength || val0 < 0))
        {
            flag = false;
            et = (EncryptorType)val0;
        }
    }
    Whitespace();
}

string EncodeEncrypte(string text)
{
    string result = "[";
    foreach (var item in GetBytes(text))
    {
        result += $"{item},";
    }
    result = result.Remove(result.Length - 1);
    result += "]";
    return result;
}

string EncodeDecrypte(string text)
{
    text = text.Remove(0, 1);
    text = text.Remove(text.Length - 1);
    List<byte> bytes = new List<byte>();
    byte byte0;
    foreach (var item in text.Split(','))
    {
        if (byte.TryParse(item, out byte0))
        {
            bytes.Add(byte0);
        }
        else
        {
            Console.WriteLine($"String: {item} can't be read!");
        }
    }
    return ToString(bytes.ToArray());
}

string DitherUpper(string text)
{
    char[] chars = text.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = i % 2 != 0 ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
    }
    return new string(chars);
}

string ReverseUpper(string text)
{
    char[] chars = text.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = char.IsLower(chars[i]) ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
    }
    return new string(chars);
}

string RandomUpper(string text, int seed)
{
    System.Random r = new System.Random(seed);
    char[] chars = text.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = r.NextDouble() > 0.5d ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
    }
    return new string(chars);
}

string DitherLower(string text)
{
    char[] chars = text.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = i % 2 == 0 ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
    }
    return new string(chars);
}

string RandomLower(string text, int seed)
{
    System.Random r = new System.Random(seed);
    char[] chars = text.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = r.NextDouble()! > 0.5d ? char.ToUpper(chars[i]) : char.ToLower(chars[i]);
    }
    return new string(chars);
}

enum TypeMode
{
    PlaceholderTexts,
    ChooseEncrypte,
    Encrypte,
    Decrypte,
    EnumLength,
    Null
}

enum EncryptorType
{
    Caesar,
    Atbash,
    Vigenère,
    ROT13,
    RailFence,
    Baconian,
    Base64,
    XOR,
    Morse,
    Transposition,
    A1Z26,
    ForceEncoded,
    DitherUpper,
    ReverseUpper,
    RandomUpper,
    EnumLength,
    Null
}

enum TextEncoderType
{
    UTF8,
    UTF7,
    UTF32,
    Unicode,
    BigEndianUnicode,
    Latin1,
    ASCII,
    Default,
    EnumLength,
    Null
}