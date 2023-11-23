using System.Text;

namespace ObjectOrientedProgramming.Assignments._6;

/// <summary>
/// Tehtävänäsi on toteuttaa yksinkertainen kaupan logiikka.
/// Kaupassa pitää olla useampia tuotteita ( esim. 10kpl ) ja tuotteilla eri verokantoja.
/// Käyttäjällä pitää olla mahdollisuus ostaa 1 - 10 eri tuotetta.
/// Lopuksi tulostetaan kuitti, jossa näkyy kokonaishinta sekä eri verokannat eroteltuna.
/// Tee tuotteita 3 eri veroluokasta, voit käyttää vaikka luennolla käytyjä esim. yleinen 24 %, ruoka 14% ja kirja 10%.
///
/// Toteuta ohjelma noudattamaan olio-ohjelmoinnin periaatteita;
/// luokkia, kapselointia, periytymistä ja metodien ylikirjoittamista/peittämistä.
/// </summary>
public class Assignment1 : ISchoolAssignment
{
    private enum TaxType
    {
        Yleinen,    // 24%
        Ruoka,      // 14%
        Kirja       // 10%
    }


    private abstract class Product
    {
        private readonly string _name;
        
        protected readonly double Price;


        protected Product(string name, double price)
        {
            _name = name;
            Price = price;
        }


        public override string ToString()
        {
            return $"{_name,-12}";
        }


        public virtual double GetPrice() => Price;
        
        
        public string GetName() => _name;
    }


    private class TaxedProduct : Product
    {
        private readonly TaxType _taxType;


        public TaxedProduct(string name, double taxFreePrice, TaxType taxType) : base(name, taxFreePrice)
        {
            _taxType = taxType;
        }


        public override double GetPrice() => Price + CalculateTax();
        
        public double CalculateTax() => Price * GetTaxPercentage() / 100d;
        
        public double GetTaxFreePrice() => Price;


        private double GetTaxPercentage()
        {
            return _taxType switch
            {
                TaxType.Yleinen => 24,
                TaxType.Ruoka => 14,
                TaxType.Kirja => 10,
                _ => throw new ArgumentOutOfRangeException()
            };
        }


        public override string ToString()
        {
            return base.ToString() + $"\tALV-luokka: {_taxType,-8}\tVeroton: {Price.ToString("F2") + "€",-8}\tVero: {GetTaxPercentage().ToString("F2") + "%",-8}\tVerollinen: {GetPrice():F2}€";
        }
    }


    private class ShoppingCart
    {
        private readonly List<TaxedProduct> _products = new();

        private double TotalTaxFreePrice => _products.Sum(product => product.GetTaxFreePrice());
        private double TotalTax => _products.Sum(product => product.CalculateTax());
        private double TotalPrice => _products.Sum(product => product.GetPrice());
        
        
        public void Add(TaxedProduct product)
        {
            _products.Add(product);
        }
        
        
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("\nKuitti:");
            sb.AppendLine("Tuote\t\tALV-luokka\t\tVeroton hinta\t\tVero\t\tVerollinen hinta");
            sb.AppendLine("------------------------------------------------------------------------------------------------------");
            foreach (TaxedProduct product in _products)
            {
                sb.AppendLine(product.ToString());
            }
            sb.AppendLine("------------------------------------------------------------------------------------------------------");
            sb.AppendLine("Yhteensä:\tVeroton hinta\tVero\tVerollinen hinta");
            sb.AppendLine($"\t\t{TotalTaxFreePrice:F2}€\t\t{TotalTax:F2}€\t\t{TotalPrice:F2}€");
            return sb.ToString();
        }
    }
    

    private static readonly TaxedProduct[] AvailableProducts =
    {
        new("Maito", 1.25, TaxType.Ruoka),
        new("Leipä", 1.50, TaxType.Ruoka),
        new("Kirja", 3.50, TaxType.Kirja),
        new("Kynä", 1.00, TaxType.Yleinen),
        new("Muki", 2.00, TaxType.Yleinen),
        new("Paita", 10.00, TaxType.Yleinen),
        new("Housut", 20.00, TaxType.Yleinen),
        new("Puhelin", 120.00, TaxType.Yleinen),
        new("Tietokone", 500.00, TaxType.Yleinen),
        new("Näyttö", 200.00, TaxType.Yleinen)
    };
    
    
    public void Run(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        ShoppingCart shoppingCart = new();
        
        Console.WriteLine("Valitse tuote:");
        for (int i = 0; i < AvailableProducts.Length; i++)
        {
            Console.WriteLine($"{i + 1}:\t{AvailableProducts[i]}");
        }
            
        Console.WriteLine("0: Lopeta ostokset");
        
        while (true)
        {
            
            string? input = Console.ReadLine();
            if (input == "0")
            {
                break;
            }
            
            if (!int.TryParse(input, out int productIndex) || productIndex < 1 || productIndex > AvailableProducts.Length)
            {
                Console.WriteLine("Virheellinen syöte!");
                continue;
            }
            
            shoppingCart.Add(AvailableProducts[productIndex - 1]);
            Console.WriteLine($"Ostoskoriin lisättiin 1x {AvailableProducts[productIndex - 1].GetName()}");
        }
        
        Console.WriteLine(shoppingCart);
    }
}