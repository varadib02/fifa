using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fifa
{
    class Program
    {
        static void Main(string[] args)
        {
            //beolvasás
            List<csapat> csapatok = new List<csapat>();
            foreach (var sor in File.ReadAllLines("fifa.txt").Skip(1))
            {
                csapatok.Add(new csapat(sor));
            }

            //3.
            Console.WriteLine($"3. feladat: A világranglistán {csapatok.Count} csapat szerepel");

            //4.
            Console.WriteLine($"4. feladat: A csapatok átlagos pontszáma: {csapatok.Average(x => x.pont)} pont");

            //5.
            Console.WriteLine($"5. feladat: A legtöbbet javító csapat:");
            csapat legtöbbjav=csapatok.OrderBy(x => x.valtozas).Last();
            Console.WriteLine($"\tHelyezés: {legtöbbjav.helyezés}");
            Console.WriteLine($"\tCsapat: {legtöbbjav.csnev}");
            Console.WriteLine($"\tPontszám: {legtöbbjav.pont}");

            //6.
            Console.WriteLine($"6. feladat: A csapatok között {(csapatok.Any(x=>x.csnev == "Magyarország")? "van" : "nincs")}");

            //7
            Console.WriteLine($"7. feladat: Statisztika:");
            csapatok.GroupBy(x => x.valtozas).Select(g => new { valt = g.Key, db = g.Count() }).Where(x=>x.db>1).ToList().ForEach(x=>Console.WriteLine($"{x.valt} helyet vátozott: {x.db} csapat"));
        }
    }
}
