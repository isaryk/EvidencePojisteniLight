using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EvidencePojisteniLight
{
	
	internal class Program

	{
		#region Variables
		public static Databaze databaze = new Databaze();
		public static List<Pojistenec> pojistenci = new List<Pojistenec>();
		public static int volbaOperace, vek, telefonniCislo;
		public static string hledaneJmeno, hledanePrijmeni;
		#endregion
		#region MyEntryPoint
		static void Main(string[] args)
		{
			
			bool pokracovat = true;

			while (pokracovat)
			{
				Console.Clear();
				Console.WriteLine("****************************");
				Console.WriteLine("Evidence pojištěných - light");
				Console.WriteLine("****************************");
				Console.WriteLine();
				Console.WriteLine("Zvolte akci:");
				Console.WriteLine("1 - Přidat nového pojištěnce");
				Console.WriteLine("2 - Vyhledat pojištěnce");
				Console.WriteLine("3 - Výpis všech pojištěnců");
				Console.WriteLine("4 - Uložit záznamy do souboru");
				Console.WriteLine("5 - Konec");

				//kontrolaVolby
				while (!int.TryParse(Console.ReadLine(), out volbaOperace))
				Console.WriteLine("Neplatná volba! Lze zadat jen číslo - zadejte, prosím, znovu!");
				
				switch (volbaOperace) {
				//Pridani do databaze
				case 1:	
						Console.WriteLine("Zadejte jméno pojištěného:");
						string jmeno = Console.ReadLine().Trim();
						Console.WriteLine("Zadejte příjmení pojištěného:");
						string prijmeni = Console.ReadLine().Trim();
						Console.WriteLine("Zadejte věk pojištěného:");

						while (!int.TryParse(Console.ReadLine(), out vek))
						Console.WriteLine("Neplatné zadání, zadejte prosím, znovu věk pojištěného!");

						Console.WriteLine("Zadejte telefonní číslo pojištěného:");
						while (!int.TryParse(Console.ReadLine(), out telefonniCislo))
						Console.WriteLine("Neplatné zadání, zadejte, prosím, znovu telefonní číslo pojištěného!");
				
						databaze.PridejPojistence(jmeno, prijmeni, vek, telefonniCislo);	
						break;
				//Vyhledavani v databazi
				case 2:
						Console.WriteLine("Zadejte jméno pojištěného:");
						hledaneJmeno = Console.ReadLine().Trim();
						Console.WriteLine("Zadejte příjmení pojištěného:");
						hledanePrijmeni = Console.ReadLine().Trim();
						Console.WriteLine();
				
						databaze.VyhledaniZaznamu(hledaneJmeno,hledanePrijmeni);	
						break;
				//Vypis vseho v databazi
				case 3:
						databaze.VypisZaznamu();					
						break;
				//Ulozeni databaze do textoveho souboru
				case 4:
						databaze.UlozitDatabazi();
						break;
				//Ukonci program
				case 5:
						pokracovat = false;
				break;
			}
			}
			// Pokud uzivatel zada cislo 5, je program ukoncen
			Environment.Exit(0);
		
		}
		#endregion

		




	

}
}
