using System;
using System.Collections.Generic;

namespace Vigenere
{
	class Program
	{
		static void Main(string[] args)
		{
			var key = "inconstitucionalicimamente";
			var word = "A Invasão vai acontecer à noite, Conforme o esperado na região sul da base. Comunique a todos Imediatamente!";
			Console.WriteLine(vigenere.Encode(key, word));

			Console.WriteLine(vigenere.Decode(key, vigenere.Encode(key, word)));
		}
	}
}
