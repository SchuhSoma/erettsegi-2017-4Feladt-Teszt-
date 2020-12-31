using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchuhS_Info_Erettsegi_Emelt2017
{
    class Program
    {
        static List<Tesztverseny> TesztversenyList;
        static string KeresettValasz;
        static string HelyesValasz = "BCCCDBBBBCDAAA";
        static List<int> PontszamokList;
        static Dictionary<string, int> AzonositoPontszamDict;
        static Dictionary<string, int> RendezettDict;
        static void Main(string[] args)
        {
            Feladat1Beolvasa(); Console.WriteLine("\n--------------------------------------\n");
            Feladat2VersenyzokSZama(); Console.WriteLine("\n--------------------------------------\n");
            Feladat3Kereses(); Console.WriteLine("\n--------------------------------------\n");
            Feladat5(); Console.WriteLine("\n--------------------------------------\n");
            Feladat6Pontszam(); Console.WriteLine("\n--------------------------------------\n");
            Feladat7();
            Console.ReadKey();
        }

        private static void Feladat7()
        {
            Console.WriteLine("7.Feladat: A legtöbb pontot elérő trió");
            RendezettDict = new Dictionary<string, int>();
            foreach (var p in PontszamokList)                
            {
                foreach (var a in AzonositoPontszamDict)
                {
                    if (a.Value == p)
                    {
                        //Console.WriteLine("{0,-6} : {1}", a.Key, a.Value);
                        if(!RendezettDict.ContainsKey(a.Key))
                        {
                            RendezettDict.Add(a.Key, a.Value);
                        }
                    }
                }               
            }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t{0,-6} : {1}", RendezettDict.ElementAt(i).Key,RendezettDict.ElementAt(i).Value);
            }
        }

        private static void Feladat6Pontszam()
        {
            Console.WriteLine("6.Feladat: Pontszámok");
            var sr=new StreamWriter(@"pontok.txt",false,Encoding.UTF8);
            int dbEllenoriz = 0;
            PontszamokList = new List<int>();
            AzonositoPontszamDict = new Dictionary<string, int>();
            foreach (var t in TesztversenyList)
            {
                int Pontszam = 0;
                for (int i = 0; i <=4; i++)
                {
                    if (t.Valasz[i]==HelyesValasz[i])
                    { Pontszam = Pontszam + 3; }
                }
                for (int j = 5; j <=9; j++)
                {
                    if (t.Valasz[j] == HelyesValasz[j])
                    { Pontszam = Pontszam + 4; }
                }
                for (int k = 10; k <= 12; k++)
                {
                    if (t.Valasz[k] == HelyesValasz[k])
                    { Pontszam = Pontszam + 5; }
                }
                if (t.Valasz[13] == HelyesValasz[13])
                { Pontszam = Pontszam + 6; }
                dbEllenoriz++;
                //Console.WriteLine("\t{0,-6} : {1}", t.Aonosito,Pontszam);
                sr.WriteLine("\t{0,-6} : {1}", t.Aonosito, Pontszam);
                if(!PontszamokList.Contains(Pontszam))
                { PontszamokList.Add(Pontszam); }
                if(!AzonositoPontszamDict.ContainsKey(t.Aonosito))
                {
                    AzonositoPontszamDict.Add(t.Aonosito, Pontszam);
                }
               
            }
            sr.Close();
            if(dbEllenoriz==TesztversenyList.Count)
            { Console.WriteLine("\tSikeres kiírás"); }
            else
            { Console.WriteLine("\tSikertelen munkamenet ellenőrizd"); }
            PontszamokList.Sort();
            PontszamokList.Reverse();
            foreach (var p in PontszamokList)
            {
                //Console.WriteLine("{0}", p);
            }
            
        }

        private static void Feladat5()
        {
            Console.WriteLine("5.Feladat : Kérje be egy feladat sorszámát, majd határozza meg, hogy hány versenyző adott a feladatra "+ 
                                "helyes megoldást, és ez a versenyzők hány százaléka!");
            Console.Write("\tKérem adja meg a feladat sorszámát (1-14 között): ");
            int Sorszam = int.Parse(Console.ReadLine())-1;
            int dbHelyes = 0;
            for (int i = 0; i < TesztversenyList.Count; i++)
            {
                if(TesztversenyList[i].Valasz[Sorszam]==HelyesValasz[Sorszam])
                { dbHelyes++; }
            }
            double ValaszArany = ((double)dbHelyes / TesztversenyList.Count)*100;
            Console.WriteLine("\tHElyes válaszok száma : {0}", dbHelyes);
            Console.WriteLine("\tHelyes válaszok aránya: {0:0.00} %", ValaszArany);
            

           

        }

        private static void Feladat3Kereses()
        {
            Console.WriteLine("3.Feladat: Kérje be egy versenyző azonosítóját, és jelenítse meg a mintának megfelelően a hozzá eltárolt válaszokat");
            Console.Write("Kérem adjon meg egy azonosítót: ");
            string KeresettAzon = Console.ReadLine().ToLower().Replace(" ", "");
            int szamlalo = 0;
            while(szamlalo!=TesztversenyList.Count && KeresettAzon!=TesztversenyList[szamlalo].Aonosito.ToLower().Replace(" ", ""))
            {
                szamlalo++;
            }
            if(szamlalo==TesztversenyList.Count)
            {
                Console.WriteLine("\tSajnos nincs ilyen azonosító a listában");
            }
            else
            {
                KeresettValasz = TesztversenyList[szamlalo].Valasz;
                Console.WriteLine("\tA keresett azonosító: {0} -> Válaszai : {1} ", TesztversenyList[szamlalo].Aonosito, TesztversenyList[szamlalo].Valasz);
                Console.WriteLine("\n--------------------------------------\n");
                Feladat4();                
            }
        }
        private static void Feladat4()
        {
            Console.WriteLine("Feladat 4 : Válasz ellenőrzés");
           
            Console.WriteLine("\tA helyes válaszok a tesztre : {0}", HelyesValasz);
            Console.WriteLine("{0}",KeresettValasz);
            for (int i = 0; i < HelyesValasz.Length; i++)
            {
              if(HelyesValasz[i]==KeresettValasz[i])
              {
                  Console.Write("+");
              }
              else
              {
                  Console.Write(" ");
              }              
            }
        }

        private static void Feladat2VersenyzokSZama()
        {
            Console.WriteLine("2.Feladat: hány versenyző vett részt a tesztversenyen");
            Console.WriteLine("\tVersenyzők száma: {0}", TesztversenyList.Count);
        }

        private static void Feladat1Beolvasa()
        {
            Console.WriteLine("1.Feladat: Olvassa be és tárolja el a valaszok.txt szöveges állomány adatait! ");
            TesztversenyList = new List<Tesztverseny>();
            var sr = new StreamReader(@"valaszok.txt", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                TesztversenyList.Add(new Tesztverseny(sr.ReadLine()));
                db++;
            }
            sr.Close();
            if(db>0)
            {
                Console.WriteLine("\tSikeres beolvasás");
                Console.WriteLine("\tBeolvasott sorok száma: {0}",db);
            }
            else
            { 
                Console.WriteLine("\tSikertelen beolvasás");            
            }
        }
    }
}
