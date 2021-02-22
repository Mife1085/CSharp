using System;

namespace Translate
{

	class Programm
	{

		static void Main()
		{
			Console.WriteLine("1. Encrypt");
			Console.WriteLine("2. Decrypt");
			Console.Write("Choice: ");
			string choice = Console.ReadLine();

			Console.Write("Input text: ");
			string text = Console.ReadLine();

			if (choice == "1"){ Console.WriteLine(Encrypt(text)); }
			else if (choice == "2") { Console.WriteLine(Decrypt(text)); }
		}

		static string Encrypt(string text)
		{
			char[] textToChar = text.ToCharArray();
			int max = textToChar.Length;
			char[] secretChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*_+-/?.,".ToCharArray();

			Random random = new Random();
			int[] numbers = new int[max];
			for (int i=0; i<max; i++)
			{
				numbers[i] = random.Next(10, 76);
			}

			string secretText = "";
			for (int i=0; i<max; i++)
			{	
				if (i == max){ i=0; }
				secretText = secretText + textToChar[i].ToString() + secretChar[numbers[i]] + secretChar[numbers[i]-10];
			}
			return secretText;
		}

		static string Decrypt(string secretText)
			{
				char[] secretTextArray = secretText.ToCharArray();
				string text = "";
				for (int i=0; i<secretTextArray.Length; i+=3){
					text = text + secretTextArray[i].ToString(); 
				}
				return text;
			}
	}
}