class CaesarCipher
{
    private static string inputFilePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
    private static string encryptFilePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "encrypt.txt");
    private static string decryptFilePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "decrypt.txt");

    static void Main()
    {
        Console.Write("Caesar cipher:\nShift: ");
        uint shift = Convert.ToUInt32(Console.ReadLine()) % 26;

        EncryptFile(shift);
        DecryptFile(shift);

        Console.ReadKey();
    }

    static void EncryptFile(uint shift)
    {
        string fileText = File.ReadAllText(inputFilePath);
        Console.WriteLine($"\nText in input.txt:\n{fileText}");

        string encryptedText = Caesar(fileText, shift);
        File.WriteAllText(encryptFilePath, encryptedText);
        Console.WriteLine($"\nEncrypted text in encrypt.txt:\n{encryptedText}");
    }

    static void DecryptFile(uint shift)
    {
        string encryptedText = File.ReadAllText(encryptFilePath);
        string decryptedText = Caesar(encryptedText, 0 - shift + 26);
        File.WriteAllText(decryptFilePath, decryptedText);
        Console.WriteLine($"\nDecrypted text in decrypt.txt:\n{decryptedText}");
    }

    static string Caesar(string input, uint shift)
    {
        char[] text = input.ToCharArray();

        for (int i = 0; i < text.Length; i++)
        {
            char asciiOffset = char.IsUpper(text[i]) ? 'A' : 'a';
            text[i] = (char)((text[i] + shift - asciiOffset) % 26 + asciiOffset);
        }

        return new string(text);
    }
}
