using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevRelSurveyLottery
{
	class Program
	{
		static void Main(string[] args)
		{
			//File
			//	.WriteAllLines("emailHashes", File
			//									.ReadAllLines("devrelemail.txt")
			//									.Distinct()
			//									.OrderBy(m => m)
			//									.Select(m => m.Substring(0, m.IndexOf('@')))
			//									.Select(m => GetHashString(m))
			//									.ToArray());

			var emailHashes = File.ReadAllLines("emailHashes");

			// Инициализируем Random датой публикации поста об опросе https://vk.com/wall-179458361_130
			var random = new Random(new DateTime(2019, 11, 15, 16, 58, 00).GetHashCode());

			for(int i = 0; i < 5; i++)
			{
				Console.WriteLine($"{emailHashes[random.Next(emailHashes.Length)]} получает лицензию JetBrains");
			}

			Console.WriteLine($"{emailHashes[random.Next(emailHashes.Length)]} получает билет на конференцию RndTechConf");
		}

		private static string GetHashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(inputString))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}

		private static byte[] GetHash(string inputString)
		{
			HashAlgorithm algorithm = SHA256.Create();
			return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}
	}
}
