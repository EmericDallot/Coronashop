using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Manager;
using Model;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        [Obsolete]
        static void Main()
        {
            Masques m = new Masques("12345678", "ffp1", 1, 15, "masques", "fzkejlm jze fjkz", "France", "D:/Cham/Pictures/Annotation 2020-01-12 182529.png");
            Masques m2 = new Masques("12254638", "ffp1", 1, 15, "masques", "fzkejlm jze fjkz", "France", "D:/Cham/Pictures/Annotation 2020-01-12 182529.png");
            Dictionary<Produits, int> d = new Dictionary<Produits, int>();
            d.Add(m, 11);
            d.Add(m2, 15);

            foreach (Produits p in d.Keys)
            {
                Console.WriteLine(p.RefProduit + ": " + d[p]);
            }
            Console.WriteLine("-----------------------");
            d.Remove(m);
            foreach (Produits p in d.Keys)
            {
                Console.WriteLine(p.RefProduit + ": " + d[p]);
            }


            Console.ReadLine();
        }
    }
}
