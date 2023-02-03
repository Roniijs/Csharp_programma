using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RN_API_universitates
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> SkoluNos = new List<string>();

            var links = "http://universities.hipolabs.com/search?name=latvia";
            var Klients = new HttpClient(); // Veidojam konekciju ar klientu
            var atbilde = await Klients.GetAsync(links); // Veicam konekcijas pieprasījumu
            var Dati = await atbilde.Content.ReadAsStringAsync();  // Saņemam datus

            
            var Uni = JsonSerializer.Deserialize<Universitates[]>(Dati);

            foreach (var Skola in Uni)
            {
                Console.Write(Skola.name+"\t\t");
                SkoluNos.Add(Skola.name);
                Console.WriteLine(Skola.web_pages[0]);
                Console.WriteLine(Skola.domains[0] + "\t\t");


            }

            Console.WriteLine();
            Console.WriteLine();
            SkoluNos.Reverse();
            foreach(var Meklesana in SkoluNos)
            {
                Console.WriteLine(Meklesana);
            }

            Console.WriteLine("Hello World!");
        }
    }
    class Universitates
    {
        public string country { get; set; }
        
        public string name { get; set; }

        public string[] web_pages { get; set; }

        public string[] domains { get; set; }
    }
}
