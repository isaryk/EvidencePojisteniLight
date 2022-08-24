using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniLight
{
	internal class Databaze
	{
		private List<Pojistenec>pojistenci;

		public Databaze()

		{
			pojistenci = new List<Pojistenec>();
			
		}
		/// <summary>
		/// Prida zaznam do databaze
		/// </summary>
		public void PridejPojistence(string jmeno, string prijmeni, int vek, int telefonniCislo)
		{	
			Pojistenec novyPojistenec = new Pojistenec(jmeno, prijmeni, vek, telefonniCislo);
			pojistenci.Add(novyPojistenec);
		}
		/// <summary>
		/// Vypise vsechny pojistene osoby
		/// </summary>
		public void VypisZaznamu ()
		{
			Console.WriteLine();
			Console.WriteLine("Výpis pojištěných osob:");
			Console.WriteLine();

			if (pojistenci.Count > 0)
			{
				foreach (var pojistenec in pojistenci)
				{
					Console.WriteLine(pojistenec);
				}
			}

			else
			{
				Console.WriteLine("Databáze neobsahuje žádný záznam!");
			}
			Console.WriteLine();
			Console.WriteLine("Pokračuj libovolnou klávesou...");
			Console.ReadKey();
		}
		/// <summary>
		/// Vyhledava zaznam v databazi dle zadaneho jmena a prijmeni
		/// </summary>
		public void VyhledaniZaznamu (string hledaneJmeno, string hledanePrijmeni)
		{ 	
			var seznamNalezenychZaznamu = pojistenci.Where(p => p.VratJmeno().ToLower().Equals(hledaneJmeno.ToLower()) && p.VratPrijmeni().ToLower().Equals(hledanePrijmeni.ToLower())).ToList();

			if (DotazNaExistenciZaznamu(hledaneJmeno,hledanePrijmeni))
			{
				Console.WriteLine("Nalezené záznamy:");
				foreach (var nalezenec in seznamNalezenychZaznamu)
				{
						Console.WriteLine(nalezenec);
				}
}
			else
			{
				Console.WriteLine("Zadané jméno <{0} {1}> není v databázi pojištěných!", hledaneJmeno, hledanePrijmeni);
			}

				Console.WriteLine("Pokračuj libovolnou klávesou...");
				Console.ReadKey();
		}
		/// <summary>
		/// Ulozi aktualni data do textoveho souboru
		/// </summary>
		public void UlozitDatabazi()
		{
			using (TextWriter tw = new StreamWriter("DatabazePojistencuLight.txt"))
			{
				try
				{
					foreach (var zaznam in pojistenci)
						tw.WriteLine(zaznam);
				}
				catch (Exception)
				{
					Console.WriteLine("Nepodařilo se uložit data!");
				}
			}
		}
		/// <summary>
		/// Vyhledava zaznamy dle jmena a prijmeni. Pokud nalezne vice zaznamu, tak vypise vse
		/// </summary>
		public void VypisVsechZaznamu()
		{
			Console.WriteLine();
			Console.WriteLine("Výpis pojištěných osob:");
			Console.WriteLine();

			if (pojistenci.Count > 0)
			{
				foreach (var pojistenec in pojistenci)
				{
					Console.WriteLine(pojistenec);
				}
			}
			else
			{
			Console.WriteLine("Databáze neobsahuje žádný záznam!");
			}
			Console.WriteLine();
			Console.WriteLine("Pokračuj libovolnou klávesou...");
			Console.ReadKey();
		}

		public bool DotazNaExistenciZaznamu (string hledaneJmeno, string hledanePrijmeni)
		{
			bool dotazNaExistenciZaznamu = pojistenci.Exists(p => p.VratJmeno().ToLower().Equals(hledaneJmeno.ToLower()) && p.VratPrijmeni().ToLower().Equals(hledanePrijmeni.ToLower()));
		
			if (dotazNaExistenciZaznamu)
			{
			return true;
			}
			return false;
			
		}
	}
}
