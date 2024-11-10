using Lab5;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Clothes
    {
        private string name;
        private string brand;
        private Sizes size;
        private Materials material;
        private double deliveryprice;
        private double price;
        private double pricewithtax;
        private int amount;
        private static int counter;
        private static double taxRate = 0.12;
        private static int maxamount = 5000;
        public Clothes() //№1
        {
            counter++;
            Name = "Сукня";
            Brand = "Gepur";
            Size = Sizes.L;
            Material = Materials.Бавовна;
            DeliveryPrice = 1700;
            Price = 2500;
            CalculateTax();
            Amount = 100;
            ObjAvailable();
        }
        public Clothes(string name, string brand) : this(name, brand, Sizes.S, Materials.Шовк, 1000, 1500, 200) //№2
        {
        }
        public Clothes(string name, string brand, Sizes size, Materials material, double deliveryprice, double price, int amount) //№3
        {
            Name = name;
            Brand = brand;
            Size = size;
            Material = material;
            Price = price;
            CalculateTax();
            DeliveryPrice = deliveryprice;
            Amount = amount;
            ObjAvailable();
        }
        [JsonProperty(PropertyName = "ObjectName")]
        public string Name
        { get { return name; }
            set
            {
                if (value.Length < 4) throw new FormatException("Назва повинна містити не менше 4 букв!");
                if (string.IsNullOrWhiteSpace(value)) throw new FormatException("Назва не може бути порожньою або складатися тільки з пробілів!");
                string[] words = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    foreach (char c in word)
                    {
                        if (Char.IsDigit(c)) throw new FormatException("Не можна використовувати цифри в назві");
                        if (!Char.IsLetter(c) || c < 'А' || c > 'я') throw new FormatException("В назві використовуйте тільки букви кирилиці (від А до я)!");
                    }
                }
                name = value;
            }
        }

        [JsonProperty(PropertyName = "ObjectBrand")]
        public string Brand
        {
            get { return brand; }
            set
            {
                if (value.Length < 4) throw new FormatException("Бренд повинен містити не менше 4 букв!");
                if (string.IsNullOrWhiteSpace(value)) throw new FormatException("Бренд не може бути порожньою або складатися тільки з пробілів!");
                string[] words = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    foreach (char c in word)
                    {
                        if (Char.IsDigit(c)) throw new FormatException("Не можна використовувати цифри в бренді");
                        if (!Char.IsLetter(c) || c < 'A' || c > 'z') throw new FormatException("В бренді використовуйте тільки латинські букви (від А до z)!");
                    }
                }
                brand = value;
            }
        }


        public Sizes Size
        {
            get { return size; }
            set
            {
                if (!Enum.IsDefined(typeof(Sizes), value))
                {
                        throw new FormatException("Введений матеріал не знайдено в списку доступних варіантів (1 - XS, 2 - S, 3 - M, 4 - L, 5 - XL, 6 - XXL).");
                }
                
                size = value;
            }
        }


        public Materials Material
        {
            private get { return material; }
            set
            {

                if (!Enum.IsDefined(typeof(Materials), value))
                {
                    throw new FormatException("Введений матеріал не знайдено в списку доступних варіантів (1 - Бавовна, 2 - Шерсть, 3 - Шовк, 4 - Акрил).");
                }
                material = value;
            }
        }
        public double DeliveryPrice
        {
            get { return deliveryprice; }
            set
            {

                if (value <= 0)
                {
                    throw new FormatException("Ціна поставки має містити тільки числа більше 0!");
                }
                deliveryprice = value;
            }
        }


        public double Price
        {
            get { return price; }
            set
            {

                if (value <= 0)
                {
                    throw new FormatException("Ціна продажі має містити тільки числа більше 0!");
                }
                price = value;
            }
        }
        public int Amount
        {
            get { return amount; }
            set {

                if (maxamount < value || value < 0)
                {
                    throw new FormatException("Кількість об'єктів має міститит тільки числа від 0 до 5000!");
                }
                amount = value;
            }
        }
        [JsonIgnore]
        public bool Available { get; set; }
        [JsonIgnore]
        public double Rating { get; set; } = 0;
        [JsonIgnore]
        public double AllRatings { get; set; }
        [JsonIgnore]
        public int Reviews { get; set; }
        [JsonIgnore]
        public string Feedback
        {
            get
            {
                return $"{Rating:f1}" + "  Відгуки:  " + $"{Reviews}";
            }
        }
        public void CalculateRatings(int rating)
        {
           if(rating>0 && rating<6) AllRatings += rating;
        }
        public void ObjAvailable()
        {
            if (Amount == 0)
                Available = false;
            else Available = true;
        }
        public bool PurchaseAmount(int a)
        {
            if (Amount >= a && a>0)
            { Amount -= a; return true; }
            else return false;
        }
        public bool Sale(int act)
        {
            if (act > 0 && act < 100)
            {
                Price -= Price * act / 100; return true;
            }
            else return false;
        }

        public bool Delivery(int kolv)
        {
            if (Amount + kolv <= MaxAmount && kolv>0) { Amount = Amount + kolv; return true; }
            else return false;
        }
        public bool PurchaseAmount()
        {
            if (Amount >= 10)
            { Amount -= 10; return true; }
            else return false;
        }
        public void Sale()
        {
            Price -= Price * 0.2;
        }

        public bool Delivery()
        {
            if (Amount + 100 <= MaxAmount) { Amount = Amount + 100; return true; }
            else return false;
        }

        public static int Counter { get => counter; set { counter = value; }}
        

        public void CalculateTax()
        {
            PriceWithTax = Price * (1 + taxRate);
        }
        [JsonIgnore]
        public double PriceWithTax { get => pricewithtax; set { pricewithtax = value; } }
        static public int MaxAmount { get => maxamount; set {maxamount = value; } }


        static public double TaxRate
        {
            get { return taxRate; }
            set
            {
                if (1 < value || value < 0)
                {
                    throw new FormatException("Тільки числа від 0 до 1!");
                }
                taxRate = value;
            }

        }

        public static void BlackFriday(ref double price)
        {
           price -= price * 0.5;
        }

        public static bool GlobalDelivery(ref int kolv)
        {
            if (kolv < MaxAmount) {kolv += MaxAmount-kolv; return true; }
            else return false;
        }

        public static bool NewTax(double newtax)
        {
            if (newtax > 0 && newtax < 1) { TaxRate = newtax; return true; }
            else return false;
        }

        public static bool IncreaseMaxAmount(int newamount)
        {
            if (newamount >= MaxAmount && newamount > 0) { MaxAmount = newamount;  return true; }
            else { return false; }

        }

        public override string ToString()
        {
            return $"{Name};{Brand};{Size};{Material};{DeliveryPrice:f2};{Price:f2};{Amount}";
        }

        public static Clothes Parse(string s)
        {
            if (string.IsNullOrEmpty(s)) throw new FormatException("Пустий рядок.");
            if (!s.Contains(";")) throw new FormatException("Неправильний розділовий знак. Використовуйте крапку з комою.");
            string[] parts = s.Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 7) throw new FormatException("Недостатня кількість параметрів.");
            if (!Enum.TryParse(typeof(Sizes), parts[2], true, out var size) || !Enum.IsDefined(typeof(Sizes), size))
            {
                throw new FormatException("Розмір не знайдено в списку (1 - XS, 2 - S, 3 - M, 4 - L, 5 - XL, 6 - XXL).");
            }
            if (!Enum.TryParse(typeof(Materials), parts[3], true, out var material) || !Enum.IsDefined(typeof(Materials), material))
            {
                throw new FormatException("Матеріал не знайдено в списку(1 - Бавовна, 2 - Шерсть, 3 - Шовк, 4 - Акрил).");
            }
            if (!double.TryParse(parts[4], out double deliveryPrice) || deliveryPrice <= 0)
            {
                throw new FormatException("Невірно вказана ціна поставки використовуйте тільки числа.");
            }
            if (!double.TryParse(parts[5], out double price) || price <= 0)
            {
                throw new FormatException("Невірно вказана ціна використовуйте тільки числа.");
            }
            if (!int.TryParse(parts[6], out int amount) || amount < 0 || amount > maxamount)
            {
                throw new FormatException("Невірно вказана кількість тільки числа від 0 до 5000.");
            }
            Clothes clothes = new Clothes(
           parts[0],  
           parts[1], 
           (Sizes)Enum.Parse(typeof(Sizes), parts[2]), 
           (Materials)Enum.Parse(typeof(Materials), parts[3]), 
           double.Parse(parts[4]), 
           double.Parse(parts[5]),
           int.Parse(parts[6]));

            return clothes;
        }

        public static bool TryParse(string s, out Clothes clothes)
        {
            clothes = null;
            bool valid = false;
            try
            {
                clothes = Parse(s);
                valid = true;
                counter++;
            }catch (FormatException ex){ Console.WriteLine("Помилка. " + ex.Message); }
            catch (ArgumentException ex) { Console.WriteLine("Помилка. " + ex.Message); }
            catch (Exception ex) { Console.WriteLine("Помилка. " + ex.Message); }
            return valid;
        }
    }
}
//Add commit