using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Text.Json;

    HttpResponseMessage odpowiedz = await new HttpClient().GetAsync("https://api.nbp.pl/api/exchangerates/rates/a/usd/");
    Kurs? kurs = JsonSerializer.Deserialize<Kurs>(await odpowiedz.Content.ReadAsStringAsync());

    Console.WriteLine("podaj kwote jaką chcesz przewalutować: ");
    string input = Console.ReadLine();

    if (decimal.TryParse(input, out decimal wPLN))
     {
            decimal wUSD = wPLN / kurs.rates[0].mid;
            Console.WriteLine($"{wPLN} PLN to {wUSD:F2} USD ({kurs:F2})");
      }
     else 
      {
            Console.WriteLine("zle");
      }

    public class Kurs
    {
        public string code { get; set; }
        public string currency { get; set; }
        public List<KursRates> rates { get; set; }
        public string table { get; set; }
    }

    public class KursRates
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public decimal mid { get; set; }
    }


