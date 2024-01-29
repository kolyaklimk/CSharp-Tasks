using System.Text;

class VigenereCipher
{
    private static string inputFilePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
    private static string encryptFilePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "encrypt.txt");
    private static string decryptFilePath =
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "decrypt.txt");

    static void Main()
    {
        Console.Write("Vigenere cipher:\nKey: ");
        string key = Console.ReadLine().ToUpper();

        EncryptFile(key);
        DecryptFile(key);

        Console.ReadKey();
    }

    static void EncryptFile(string key)
    {
        string fileText = File.ReadAllText(inputFilePath);
        Console.WriteLine($"\nText in input.txt:\n{fileText}");

        string encryptedText = Vigenere(fileText, key);
        File.WriteAllText(encryptFilePath, encryptedText);
        Console.WriteLine($"\nEncrypted text in encrypt.txt:\n{encryptedText}");
    }

    static void DecryptFile(string key)
    {
        string encryptedText = File.ReadAllText(encryptFilePath);
        string decryptedText = Vigenere(encryptedText, key, false);
        File.WriteAllText(decryptFilePath, decryptedText);
        Console.WriteLine($"\nDecrypted text in decrypt.txt:\n{decryptedText}");
    }

    static string Vigenere(string text, string key, bool isEncrypt = true)
    {
        StringBuilder result = new StringBuilder();
        int keyIndex = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                char offset = char.IsUpper(text[i]) ? 'A' : 'a';
                int keyValue = key[keyIndex] - 'A';
                result.Append((char)((text[i] - offset + (isEncrypt ? keyValue : 26 - keyValue)) % 26 + offset));

                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                result.Append(text[i]);
            }
        }

        return result.ToString();
    }
}