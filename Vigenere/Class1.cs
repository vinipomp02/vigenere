using System;
using System.Collections.Generic;
using System.Text;

namespace Vigenere
{
    class vigenere
    {
		public static string codifica(char[] key, char[] word, Action<int[]> res)
		{
			List<char> list = new List<char>();
			char[] resp;
			/*Loop para transformar Char em Ascii e fazer a conversão*/
			int j = 0;
			for (int i = 0; i < word.Length; i++)
			{
				/*Copia Chars que não são letras ou acentos*/
				if (!Char.IsLetter(word[i]) || (int)(Char.ToUpper(word[i])) > 90 || (int)(Char.ToUpper(word[i])) < 65)
				{
					list.Add(word[i]);
				}
				else
				{
					/*Verifica e Transforma em Uppercase*/
					bool up = Char.IsUpper(word[i]);
					word[i] = Char.ToUpper(word[i]);
					/* Char Para ascii*/
					int chave = (int)key[j];
					int pal = (int)word[i];
					int resultado = 0;
					int[] valores = { chave, pal, resultado };
					/*Chama a Função baseada no que necessita*/
					res(valores);
					/*Ascii para Char e Adiciona na Lista*/
					if (!up)
					{
						/*Volta os Caracteres para LowerCase se necessario*/
						list.Add(Char.ToLower(((char)valores[2])));
					}
					else
					{
						list.Add((char)valores[2]);
					}

					j++;
				}
			}

			/*Transformar A Lista em Array*/
			resp = list.ToArray();
			/*Array para String*/
			string s = new string(resp);
			return s;
		}

		/*Transforma cada Char em Ascii e Codifica */
		public static void resEncode(int[] valores)
		{
			/*Codificando */
			valores[2] = valores[0] - 65 + valores[1] - 65;
			if (valores[2] > 25)
			{
				valores[2] -= 26;
			}

			valores[2] += 65;
		}

		public static void resDecode(int[] valores)
		{
			/*Codificando */
			valores[2] = (valores[1] - 65) - (valores[0] - 65);
			if (valores[2] < 0)
			{
				valores[2] += 26;
			}

			valores[2] += 65;
		}

		public static char[] igualaTamanhoChave(string key, string word)
		{
			/*Inicializa Arrays*/
			char[] chave;
			chave = key.ToUpper().ToCharArray();
			/*Verifica se a Palavra é maior que a chave*/
			if (word.Length > chave.Length)
			{
				int i = 0;
				/*Loop para aumentar a Chave para o tamanho da Palavra*/
				while (word.Length != chave.Length)
				{
					List<char> list = new List<char>(chave);
					list.Add(chave[i]);
					chave = list.ToArray();
					i++;
				}
			}

			return chave;
		}

		/*Codifica para Vigenere*/
		public static string Encode(string key, string word)
		{
			/*Retorna o Vigenere com a Palavra/Chave do Tamanho igual*/
			return codifica(igualaTamanhoChave(key, word), word.ToCharArray(), resEncode);
		}

		public static string Decode(string key, string word)
		{
			/*Retorna o Vigenere com a Palavra/Chave do Tamanho igual*/
			return codifica(igualaTamanhoChave(key, word), word.ToCharArray(), resDecode);
		}
	}
}
