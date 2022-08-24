using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencePojisteniLight
{
	internal class Pojistenec
	{	
		private string Jmeno { get;set; }
		private string Prijmeni { get; set; }
		private int Vek { get; set; }
		private int TelefonniCislo { get; set; }	

		/// <summary>
		/// Vytvori noveho pojistence
		/// </summary>
		/// <param name="jmeno"></param>
		/// <param name="prijmeni"></param>
		/// <param name="vek"></param>
		/// <param name="cisloTelefonu"></param>
		/// 
		public Pojistenec(string jmeno, string prijmeni, int vek, int telefonniCislo)
		{
			this.Jmeno = jmeno;
			this.Prijmeni = prijmeni;
			this.Vek = vek;
			this.TelefonniCislo = telefonniCislo;
		}
		public string VratJmeno()
		{
			return Jmeno;	
		}
		public string VratPrijmeni()
		{
			return Prijmeni;
		}
		public int VratVek()
		{
			return Vek;
		}
		public int VratTelefonniCislo()
		{
			return TelefonniCislo;
		}
		public override string ToString()
		{
			return string.Format("{0}	{1}	{2}	{3}",Jmeno,Prijmeni,Vek,TelefonniCislo);	
		}
	}
}
