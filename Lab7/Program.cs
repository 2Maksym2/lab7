using Lab5;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

Console.OutputEncoding = UTF8Encoding.UTF8;
static void AddEl(ref int i, List<Clothes> cloths)
{
    string name = null;
    string brand = null;
    Sizes size = default;
    Materials material = default;
    double price = 0, deliveryprice=0;
    int amount = 0, a=0;
    bool flag = false;
    do
    {
        Console.WriteLine("\nВиберіть конструктор для створення об'єкту: \n1)Конструктор №1 \n2)Конструктор №2 \n3)конструктор №3");
        if (int.TryParse(Console.ReadLine(), out a) && a > 0 && a < 4) flag = true;
        else
        {
            Console.WriteLine("Помилка. Введіть число від 1 до 3!");
        }
    } while (!flag);
    flag = false;
    switch (a)
    {
        case 1:
            Clothes c = new Clothes ();
            cloths.Add(c);
            i++;
            Console.WriteLine("Об'єкт додано.");
            break;
        case 2:
            c = new Clothes();
            do
            {
                Console.WriteLine("\nВведіть назву об'єкта:");
                try
                {
                    name = Console.ReadLine();
                    c.Name = name;
                    Console.WriteLine();
                    flag = true;
                }
                catch (OverflowException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
            } while (flag == false);
            flag = false;



            do
            {
                Console.WriteLine("Введіть назву бренду: ");
                try
                {
                    brand = Console.ReadLine();
                    Console.WriteLine();
                    c.Brand = brand;
                    flag = true;
                }
                catch (OverflowException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
            } while (flag == false);
            c = new Clothes(name, brand);
            cloths.Add(c);
            i++;
            Console.WriteLine("Об'єкт додано.");
            break;
        case 3:
            flag = false;
            do
            {
                Console.WriteLine("\nВиберіть спосіб для створення об'єкту: \n1)Введення всіх даних в рядок \n2)Введення всіх даних по черзі ");
                if (int.TryParse(Console.ReadLine(), out a) && a > 0 && a < 3) flag = true;
                else
                {
                    Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                }
            } while (!flag);
            switch (a)
            {
                case 1:
                    string str; flag = false;
                    do
                    {
                        Console.WriteLine("Введіть рядок: Назва;бренд;розмір;матеріал;ціну поставки;ціну продажі без податку;кількість на складі.");
                        str = Console.ReadLine();
                        Clothes newClothes;
                        if(Clothes.TryParse(str, out newClothes))
                        {
                            cloths.Add(newClothes);
                            i++;
                            Console.WriteLine($"Успішно створений об'єкт: {newClothes.ToString()}");
                            flag = true;
                        }
                    } while (!flag);
                    break;
                case 2:
                    c = new Clothes();
                    do
                    {
                        Console.WriteLine("Введіть назву об'єкта:");
                        try
                        {
                            name = Console.ReadLine();
                            c.Name = name;
                            Console.WriteLine();
                            flag = true;
                        }
                        catch (OverflowException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                        catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                    } while (flag == false);
                    flag = false;



                    do
                    {
                        Console.WriteLine("Введіть назву бренду: ");
                        try
                        {
                            brand = Console.ReadLine();
                            Console.WriteLine();
                                c.Brand = brand;
                            flag = true;
                        }
                        catch (OverflowException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                        catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                    } while (flag == false);
                    flag = false;

                    do
                    {
                        try
                        {
                            Console.WriteLine("Введіть розмір об'єкту (1 - XS, 2 - S, 3 - M, 4 - L, 5 - XL, 6 - XXL):");

                            if (!Enum.TryParse<Sizes>(Console.ReadLine(), true, out size))
                            {
                                throw new FormatException("Введений розмір не знайдено в списку доступних варіантів.");
                            }
                            if (int.TryParse(size.ToString(), out int number))
                            {
                                throw new FormatException("Введений матеріал не знайдено в списку доступних варіантів.");
                            }
                            Console.WriteLine();
                            c.Size = size;
                            flag = true;
                        }
                        catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                    } while (flag == false);
                    flag = false;


                    do
                    {
                        try
                        {
                            Console.WriteLine("Введіть матеріал з якого створений об'єкт (1 - Бавовна, 2 - Шерсть, 3 - Шовк, 4 - Акрил):");
                            if (!Enum.TryParse<Materials>(Console.ReadLine(), true, out material))
                            {
                                throw new FormatException("Введений розмір не знайдено в списку доступних варіантів.");
                            }
                            if (int.TryParse(material.ToString(), out int number))
                            {
                                throw new FormatException("Введений матеріал не знайдено в списку доступних варіантів.");
                            }
                            Console.WriteLine();
                            c.Material = material;
                            flag = true;
                        }
                        catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                    } while (flag == false);
                    flag = false;

                    do
                    {
                        try
                        {
                            Console.WriteLine("Введіть ціну поставки об'єкта (грн): ");
                            if (!double.TryParse(Console.ReadLine(), out deliveryprice))
                            {
                                throw new FormatException("Тільки цифри");
                            }
                            c.DeliveryPrice = deliveryprice;
                            Console.WriteLine();
                            flag = true;
                        }
                        catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                    } while (flag == false);
                    flag = false;

                    do
                    {
                        try
                        {
                            Console.WriteLine("Введіть ціну продажі об'єкта без податку(грн): ");
                            if (!double.TryParse(Console.ReadLine(), out price))
                            {
                                throw new FormatException("Тільки цифри");
                            }
                            c.Price = price;
                            Console.WriteLine();
                            flag = true;
                        }
                        catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                    } while (flag == false);
                    flag = false;

                    do
                    {
                        try
                        {
                            Console.WriteLine("Скільки об'єктів є в наявності(максимум:5000): ");
                            if (!int.TryParse(Console.ReadLine(), out amount))
                            {
                                throw new FormatException("Тільки цифри");
                            }
                            Console.WriteLine();
                            c.Amount = amount;
                            c = new Clothes(name, brand, size, material, deliveryprice, price, amount);
                            cloths.Add(c);
                            flag = true;
                        }
                        catch (FormatException ex) { Console.WriteLine("Помилка. " + ex.Message); }
                    } while (flag == false);
                    i++;
                    Console.WriteLine("Об'єкт додано.");
                    break;            
            } break;
    }
}

static void Purchase(List<Clothes> cloths)
{
    bool flag = false;
    int s = -1;
    do
    {
        do
        {
            try
            {
                Console.WriteLine("\nВведіть номер об'єкту, який хочете придбати або 0 для повернення до меню:");
                if (!int.TryParse(Console.ReadLine(), out s) || s < 0)
                {
                    throw new FormatException("Тільки цифри від 0!");
                }
                else if (s == 0) return;
                Console.WriteLine();
                flag = true;
            }
            catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
        } while (flag == false);
        flag = false;

        int i = -1;
        for (int j = 0; j < cloths.Count; j++)
        {
            if (cloths[j] != null && j + 1 == s)
            {
                i = j;
                break;
            }
        }
        flag = false;

        if (i != -1)
        {
            double prvprice = cloths[i].Price;
            int prvamount = cloths[i].Amount;
            Console.WriteLine("Вибраний об'єкт:");
            Info(cloths,i);
            if (cloths[i].Amount <= 0)
            {
                Console.WriteLine("\nОб'єкт недоступний!");
            }
            else
            {
                flag = true;
                int rating = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("\nЧи є знижка на цей продукт yes/no");
                        string str = Console.ReadLine().Trim().ToLower();
                        if (str == "yes")
                        {
                            int act = 0;
                            bool l = false, c=true;
                            do
                            {
                                Console.WriteLine("\nВиберіть один із методів: \n1)Стандартна знижка(20%) \n2)Введення знижки вручну");
                                if (int.TryParse(Console.ReadLine(), out int k) && k > 0 && k < 3) ;
                                else
                                {
                                    Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                                }
                                switch (k)
                                {
                                    case 1:
                                        cloths[i].Sale();
                                        c = false;
                                        break;
                                    case 2:
                                        do
                                        {
                                            try
                                            {
                                                Console.WriteLine("\nВведіть знижку в %");
                                                if (!int.TryParse(Console.ReadLine(), out act) || act <= 0 || act > 100)
                                                {
                                                    throw new FormatException("Тільки числа від 0 до 100!");
                                                }
                                                Console.WriteLine();
                                                l = true;
                                            }
                                            catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                                        } while (l == false);
                                        cloths[i].Sale(act);
                                        Console.WriteLine($"Оновлена ціна: {cloths[i].Price:f1}");
                                        c = false;
                                        break;
                                }
                            } while (c);
                                c = true; l = true;
                                do
                                {
                                    Console.WriteLine("\nВиберіть метод введення кількості: \n1)Стандартна кількість(10) \n2)Введення кількості вручну");
                                    if (int.TryParse(Console.ReadLine(), out int k) && k > 0 && k < 3) ;
                                    else
                                    {
                                        Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                                    }
                                switch (k)
                                {
                                    case 1:
                                        try
                                        {

                                            double endprice = 10 * cloths[i].Price;
                                            if (!cloths[i].PurchaseAmount())
                                            {
                                                throw new Exception("Недостатня кількість об'єктів");
                                            }
                                            endprice = 10 * cloths[i].Price;
                                            Console.WriteLine($"\nКінцева ціна: {endprice}");
                                        }
                                        catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                                        catch (Exception ex) { Console.WriteLine(ex.Message); c = true; break; }
                                        c = false;
                                        break;
                                    case 2:
                                        do
                                        {
                                            try
                                            {
                                                Console.WriteLine("\nВведіть кількість об'єктів що хочете придбати: ");
                                                int a = 0;
                                                if (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                                                {
                                                    throw new FormatException("Тільки числа більше 0!");
                                                }
                                                if (!cloths[i].PurchaseAmount(a))
                                                {
                                                    throw new Exception("Недостатня кількість об'єктів");
                                                }
                                                else l = true;
                                                double endprice = a * cloths[i].Price;
                                                Console.WriteLine($"\nКінцева ціна: {endprice}");
                                            }
                                            catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                                            catch (Exception ex) { Console.WriteLine(ex.Message); l = false; }
                                        } while (!l);
                                            c = false;
                                            break;
                                    }
                                } while (c);

                            bool end = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\nЗавершити покупку?(Yes/Cancel)");
                                    string purch = Console.ReadLine().Trim().ToLower();
                                    if (purch == "yes")
                                    {
                                        cloths[i].ObjAvailable();
                                        Console.WriteLine("\nПридбаний об'єкт:");
                                        Info(cloths, i);
                                        do
                                        {
                                            Console.WriteLine("\nОцініть придбаний об'єкт від 1 до 5");
                                            if (!int.TryParse(Console.ReadLine(), out rating) || rating > 5 || rating < 1)
                                            {
                                                throw new FormatException("Тільки цифри від 1 до 5!");
                                            }
                                            cloths[i].Price = prvprice;
                                            cloths[i].Reviews += 1;
                                            cloths[i].CalculateRatings(rating);
                                            cloths[i].Rating = cloths[i].AllRatings /cloths[i].Reviews;
                                            end = true;
                                        } while (!end);

                                    }
                                    else if (purch == "cancel")
                                    {
                                        cloths[i].Amount = prvamount;
                                        cloths[i].Price = prvprice;
                                        cloths[i].ObjAvailable();
                                        return;
                                    }
                                    else
                                    {
                                        throw new FormatException(" Тільки Yes/Cancel.");
                                    }
                                    flag = true;
                                }
                                catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                            } while (end == false);

                        }
                        else if (str == "no")
                        {
                            bool end = false, l =false, c = true; ;
                            do
                            {
                                do
                                {
                                    Console.WriteLine("\nВиберіть метод введення кількості: \n1)Стандартна кількість(10) \n2)Введення кількості вручну");
                                    if (int.TryParse(Console.ReadLine(), out int k) && k > 0 && k < 3) ;
                                    else
                                    {
                                        Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                                    }
                                    switch (k)
                                    {
                                        case 1:
                                                try
                                                {

                                                    double endprice = 10 * cloths[i].Price;
                                                    if (!cloths[i].PurchaseAmount())
                                                    {
                                                        throw new Exception("Недостатня кількість об'єктів");
                                                    }
                                                    else
                                                        l = true;
                                                    endprice = 10 * cloths[i].Price;
                                                    Console.WriteLine($"\nКінцева ціна: {endprice}");
                                                }
                                                catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                                                catch (Exception ex) { Console.WriteLine(ex.Message); c = true; break; }
                                            c = false;
                                            break;
                                        case 2:
                                            do
                                            {
                                                try
                                                {
                                                    Console.WriteLine("\nВведіть кількість об'єктів що хочете придбати: ");
                                                    int a = 0;
                                                    if (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                                                    {
                                                        throw new FormatException("Тільки числа більше 0!");
                                                    }
                                                    if (!cloths[i].PurchaseAmount(a))
                                                    {
                                                        throw new Exception("Недостатня кількість об'єктів");
                                                    }
                                                    else
                                                        l = true;
                                                    double endprice = a * cloths[i].Price;
                                                    Console.WriteLine($"\nКінцева ціна: {endprice}");
                                                }
                                                catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                                                catch (Exception ex) { Console.WriteLine(ex.Message); l = false; }
                                            } while (!l);
                                            c = false;
                                            break;
                                    }
                                } while (c);




                                try
                                {
                                    Console.WriteLine("\nЗавершити покупку?(Yes/Cancel)");
                                    string purch = Console.ReadLine().Trim().ToLower();
                                    if (purch == "yes")
                                    {
                                        cloths[i].ObjAvailable();
                                        Console.WriteLine("\nПридбаний об'єкт:");
                                        Info(cloths, i);

                                        do
                                        {
                                      
                                            Console.WriteLine("\nОцініть придбаний об'єкт від 1 до 5");                               
                                            if (!int.TryParse(Console.ReadLine(), out rating) || rating > 5 || rating < 1)
                                        {
                                            throw new FormatException("Тільки цифри від 1 до 5!");
                                        }
                                            cloths[i].Price = prvprice;                                 
                                            cloths[i].Reviews += 1;
                                            cloths[i].CalculateRatings(rating);
                                            cloths[i].Rating = cloths[i].AllRatings / cloths[i].Reviews;
                                            end = true;                                  
                                        } while (!end) ;


                                }
                                    else if (purch == "cancel")
                                    {
                                        cloths[i].Amount = prvamount;
                                        cloths[i].Price = prvprice;
                                        cloths[i].ObjAvailable();
                                        return;
                                    }
                                    else
                                    {
                                        throw new FormatException(" Тільки Yes/Cancel.");
                                    }
                                    flag = true;
                                }
                                catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }

                            } while (end == false);
                        }
                        else
                        {
                            flag = false;
                            throw new FormatException(" Тільки Yes/No.");
                        }

                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                } while (flag == false);
            }
        }

        else
        {
            Console.WriteLine("Об'єкт не знайдено.");
        }
    } while (flag == false);

}


static void Deliveryclothes(List<Clothes> cloths)
{
    int s = -1;
    bool flag = false, l = false;
   
        do
        {
            try
            {
                Console.WriteLine("\nВведіть номер об'єкту, на який ви хочете замовити поставку або 0 для повернення до меню: ");
                if (!int.TryParse(Console.ReadLine(), out s) || s < 0)
                {
                    throw new FormatException("Тільки цифри більше 0!");
                }
                else if (s == 0) return;
                Console.WriteLine();
                flag = true;
            }
            catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
        } while (!flag);

        int i = -1;
        for (int j = 0; j < cloths.Count; j++)
        {
            if (cloths[j] != null && j + 1 == s)
            {
                i = j;
                break;
            }
        }
        int b = 0; flag = false;

    if (i != -1)
    {
        Console.WriteLine("Вибраний об'єкт:");
        Info(cloths, i);
        int kolv = 0;
        do
        {
            Console.WriteLine("\nВиберіть спосіб поставки: \n1)Стандартна поставка \n2)Введення поставки вручну ");
            if (int.TryParse(Console.ReadLine(), out b) && b > 0 && b < 3) flag = true;
            else
            {
                Console.WriteLine("Помилка. Введіть число від 1 до 2!");
            }
        } while (!flag);
        flag = false;
        switch (b)
        {
            case 1:
                if (!cloths[i].Delivery()) Console.WriteLine($"На складі достатня кількість об'єктів!");
                else
                {
                    Console.WriteLine($"Оновлена кількість товару: {cloths[i].Amount}");
                    Console.WriteLine($"\nЦіна поставки {100 * cloths[i].DeliveryPrice} ");
                }
                break;
          
            case 2:
                do
                {
                    try
                    {
                        Console.WriteLine("\nЯку кількість об'єктів хочете замовити:");
                        if (!int.TryParse(Console.ReadLine(), out kolv) || kolv <= 0)
                        {
                            throw new FormatException("Тільки цифри більше 0!");
                        }
                        if (Clothes.MaxAmount >= kolv + cloths[i].Amount)
                        {
                            Console.WriteLine($"\nДоставлено {kolv} об'єктів.");
                            Console.WriteLine($"\nЦіна поставки {kolv * cloths[i].DeliveryPrice} ");
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            Console.WriteLine("Недостатньо місця на складі!");
                        }
                        Console.WriteLine();                     
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                } while (!flag);

                flag = false;
                while (!flag) 
                {
                    try
                    {
                        Console.WriteLine("\nЧи є брак(yes/no):");
                        string str = Console.ReadLine().Trim().ToLower();
                        if (str == "yes")
                        {
                            int defect = 0;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("\nВведіть кількість браку: ");
                                    if (!int.TryParse(Console.ReadLine(), out defect) || defect <= 0)
                                    {
                                        throw new FormatException("Тільки числа більше 0!");
                                    }
                                    else if (defect > kolv) throw new FormatException("Браку більше ніж продуктів!");
                                    Console.WriteLine();
                                    l = true;
                                }
                                catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                            } while (l == false);

                            kolv = kolv - defect;
                            cloths[i].Delivery(kolv);
                            Console.WriteLine($"Оновлена кількість товару: {cloths[i].Amount}");
                            cloths[i].ObjAvailable();
                            flag = true;
                        }
                        else if (str == "no")
                        {
                            cloths[i].Delivery(kolv);
                            Console.WriteLine($"Оновлена кількість товару: {cloths[i].Amount}");
                            cloths[i].ObjAvailable();
                            flag = true;
                        }
                        else
                        {
                            throw new FormatException("Тільки yes/no");
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
                } 
                break;

        }
    }
    else
    {
        Console.WriteLine("Об'єкт не знайдено");
    }
       
    
}

static void NameFindEl(List<Clothes> cloths, int reviews)
{
    string search = null;
    do
    {
        Console.WriteLine("\nВведіть ім'я для пошуку або 0 для повернення в меню:");
        search = Console.ReadLine();
        if (IsClothesFind(search, cloths)) Console.WriteLine("Об'єкт знайдено:");
        Clothes? std = cloths.Find(s => s.Name == search);
        if (std != null)
        {
            Console.WriteLine($"\nНазва: {std.Name}");
            Console.WriteLine($"Бренд: {std.Brand}");
            Console.WriteLine($"Розмір: {std.Size}");
            Console.WriteLine($"Ціна: {std.PriceWithTax:f1}");
            Console.WriteLine($"Оцінка: {std.Feedback}");
            Console.WriteLine($"Кількість у продажі: {std.Amount}");
            Console.WriteLine($"Чи доступний до продажі: {std.Available}");
            return;
        }
        else if (search != "0")
        {
            Console.WriteLine("Об'єкт не знайдено.");
            return;
        }
    } while (search != "0");
}

static void BrandFindEl(List<Clothes> cloths, int reviews)
{
    string search = null;
    do
    {
        Console.WriteLine("\nВведіть бренд для пошуку або 0 для повернення в меню:");
        search = Console.ReadLine();
        Clothes? std = cloths.Find(s => s.Brand == search);
        if (std != null)
        {
            Console.WriteLine($"\nНазва: {std.Name}");
            Console.WriteLine($"Бренд: {std.Brand}");
            Console.WriteLine($"Розмір: {std.Size}");
            Console.WriteLine($"Ціна: {std.PriceWithTax:f1}");
            Console.WriteLine($"Оцінка: {std.Feedback}");
            Console.WriteLine($"Кількість у продажі: {std.Amount}");
            Console.WriteLine($"Чи доступний до продажі: {std.Available}");
            return;
        }
        else if (search != "0")
        {
            Console.WriteLine("Об'єкт не знайдено.");
            return;
        }
    } while (search != "0");
}

static void IndexDelEl(ref int i, ref List<Clothes> cloths, int reviews)
{
    int s = -1; bool flag = false;
    do
    {
        try
        {
            Console.WriteLine("\nВведіть номер продукту, який хочете видалити:");
            if (!int.TryParse(Console.ReadLine(), out s) || s <= 0)
            {
                throw new FormatException("Тільки цифри більше 0!");
            }

            Console.WriteLine();
            flag = true;
        }
        catch (FormatException ex) { Console.WriteLine("Помилка: " + ex.Message); }
    } while (flag == false);
    s--;
    flag = false;

    if (s >= 0 && s < cloths.Count && cloths[s] != null)
    {
        Console.WriteLine("Видалений об'єкт:");
        Info(cloths, s);
        cloths.RemoveAt(s);
        i--;
        Clothes.Counter -= 1;
    }
    else
    {
        Console.WriteLine("Об'єкт не знайдено.");
    }
}

static void NameDelEl(ref int i, ref List<Clothes> cloths, int reviews)
{
    int index = -1;
    string search = null;
    Console.WriteLine("\nВведіть назву продукту, який хочете видалити або 0 для повернення в меню:");
    search = Console.ReadLine();
    index = IndexToDelete(search, cloths);
    if (index!=-1)
    {
        Console.WriteLine("Видалений об'єкт:");
        Info(cloths, index);
        cloths.RemoveAt(index);
        i--;
        Clothes.Counter -= 1;
    }
    else if (search != "0")
    {
        Console.WriteLine("Об'єкт не знайдено.");
    }
}

static void Info(List<Clothes> cloths, int i)
{
    Console.WriteLine($"\nНазва: {cloths[i].Name}");
    Console.WriteLine($"Бренд: {cloths[i].Brand}");
    Console.WriteLine($"Розмір: {cloths[i].Size}");
    Console.WriteLine($"Ціна: {cloths[i].PriceWithTax:f1}");
    Console.WriteLine($"Оцінка: {cloths[i].Feedback}");
    Console.WriteLine($"Кількість у продажі: {cloths[i].Amount}");
    Console.WriteLine($"Чи доступний до продажі: {cloths[i].Available}");

}

static void NewTax(List<Clothes> cloths)
{
    double a = 0;
    bool b = true;
    do
    {
        Console.WriteLine("Введіть новий податок (від 0 до 1): ");
        if (double.TryParse(Console.ReadLine(), out a))
        {
            if (!Clothes.NewTax(a)) Console.WriteLine("Тільки від 0 до 1!");
            else b = false;
        }
        else
        {
            Console.WriteLine("Помилка. Введіть число!");
        }
    } while (b);
    
}
static void NewMaxAmount()
{
    int am = 0;
    bool b = true;
    do
    {
        Console.WriteLine($"Введіть новий об'єм складу більший за {Clothes.MaxAmount}: ");
        if (int.TryParse(Console.ReadLine(), out am))
        {
            if (!Clothes.IncreaseMaxAmount(am)) Console.WriteLine("Помилка. Новий об'єм складу не може бути меншим за попередній!");
            else
            {
                Console.WriteLine($"Оновлений об'єм складу: {Clothes.MaxAmount} ");
                b = false;
            }

        }
        else
        {
            Console.WriteLine("Помилка. Введіть число!");
        }
    } while (b);

}
static bool IsClothesFind(string name, List<Clothes> cloths)
{
        return cloths.Exists(c => c.Name == name);
}
static int IndexToDelete(string search, List<Clothes> cloths)
{
   return cloths.FindIndex(s => s.Name == search);
}
void SaveToFileCSV(List<Clothes> cloths, string path)
{
    List<string> lines = new();
    foreach (Clothes item in cloths)
    {
        lines.Add(item.ToString());
    }
    try
    {
        File.WriteAllLines(path, lines, Encoding.UTF8);
        Console.WriteLine($"Перевірте файв в {Path.GetFullPath(path)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
//method save
List<Clothes> ReadFromFileCSV(string path, int N)
{
    List<Clothes> clots = new List<Clothes>();
    try
    {
        List<string> lines = new();
        lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            foreach (string item in lines)
            {
            bool res = Clothes.TryParse(item, out Clothes? c);
            if (res) clots.Add(c);
            }

    }
    catch (IOException)
    {
        Console.WriteLine("Помилка читання файлу");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return clots;
}
//read
void SaveToFileJson(List<Clothes> cloths, string path)
{
    try
    {
        string jsonstring = "";
        foreach (Clothes item in cloths)
        {
            jsonstring += JsonConvert.SerializeObject(item);
            jsonstring += "\n";
        }
        File.WriteAllText(path, jsonstring, Encoding.UTF8);
        Console.WriteLine($"Перевірте файв в {Path.GetFullPath(path)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
//save
List<Clothes> ReadFromFileJson(string path)
{
    List<Clothes> clots = new();
    try
    {
        List<string> lines = new();
        lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            foreach (string item in lines)
            {

            Clothes cloth = JsonConvert.DeserializeObject<Clothes>(item);
                if (cloth != null)
                clots.Add(cloth);
            }

    }
    catch (IOException)
    {
        Console.WriteLine("Помилка читання файлу");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return clots;
}

int N, reviews = 0;
bool start = false, end=false;
while (true)
    {
        Console.WriteLine("Введіть кількість предметів (тільки цифри):");
        if (int.TryParse(Console.ReadLine(), out N) && N > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("Помилка. Введіть число більше 0!");
        }
    }
int a, i = 0;
List<Clothes> cloths = new();
do
{
    Console.WriteLine("\nМеню: \n 1) Додати предмет; \n 2) Вивести список предметів; \n 3) Знайти предмет; \n 4) Видалити предмет; \n 5) Демонстрація поведінки \n 6) Демонстрація роботи static методів \n 7)Зберегти колекцію об'єктів у файл \n 8)Зчитати колекцію об'єктів з файлу \n 9)Очистити колекцію об'єктів \n 0) Вийти;");
    if (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.WriteLine("Помилка. Введіть коректне число!");
    }
    else
    {
        switch (a)
        {
            case 0:
                end = true;
                break;

            case 1:
                if (i < N)
                {
                    AddEl(ref i, cloths);
                }
                else Console.WriteLine("Максиммальна кількість об'єктів.");
                break;



            case 2:
                bool flag = false;
                Console.WriteLine($"\nУсього об'єктів: {Clothes.Counter}");
                foreach (var item in cloths)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"\nНазва: {item.Name}");
                        Console.WriteLine($"Бренд: {item.Brand}");
                        Console.WriteLine($"Розмір: {item.Size}");
                        Console.WriteLine($"Ціна: {item.PriceWithTax:f1}");
                        Console.WriteLine($"Оцінка: {item.Feedback}");
                        Console.WriteLine($"Кількість у продажі:  {item.Amount}");
                        Console.WriteLine($"Чи доступний до продажі: {item.Available}");
                        Console.WriteLine();
                        flag = true;
                    }

                }
                if (flag == false) Console.WriteLine("Об'єктів немає.");
                break;

            case 3:
                int b;
                do
                {
                    flag = false;
                    Console.WriteLine("Шукати одяг: 1) За назвою; 2) За брендом;");
                    if (int.TryParse(Console.ReadLine(), out b) && b > 0 && b < 3) ;

                    else
                    {
                        Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                    }

                    switch (b)
                    {
                        case 1:
                            NameFindEl(cloths, reviews);
                            flag = true;
                            break;
                        case 2:
                            BrandFindEl(cloths, reviews);
                            flag = true;
                            break;
                    }
                } while (!flag);
                break;



            case 4:
                int c;
                do
                {
                    flag = false;
                    Console.WriteLine("Видалити продукт: 1) По номеру; 2) За ім'ям; ");
                    if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                    else
                    {
                        Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                    }
                    switch (c)
                    {
                        case 1:
                            IndexDelEl(ref i, ref cloths, reviews);
                            flag = true;
                            break;
                        case 2:
                            NameDelEl(ref i, ref cloths, reviews);
                            flag = true;
                            break;
                    }
                } while (!flag);
                break;


            case 5:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1) Придбати об'єкт \n2) Замовити поставку об'єктів ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                        }
                        switch (c)
                        {
                            case 1:
                                bool l = false;
                                int num = 1;
                                foreach (var item in cloths)
                                {
                                    if (item != null)
                                    {

                                        Console.WriteLine($"\n{num}) Назва: {item.Name}");
                                        Console.WriteLine($"Бренд: {item.Brand}");
                                        Console.WriteLine($"Розмір: {item.Size}");
                                        Console.WriteLine($"Ціна: {item.PriceWithTax:f2}");
                                        Console.WriteLine($"Оцінка: {item.Feedback}");
                                        Console.WriteLine($"Кількість у продажі: {item.Amount}");
                                        Console.WriteLine($"Чи доступний до продажі: {item.Available}");
                                        l = true;
                                        num++;
                                    }
                                }
                                if (l == false)
                                {
                                    Console.WriteLine("Об'єктів немає.");
                                    flag = true;
                                }
                                else
                                {
                                    Purchase(cloths);
                                    flag = true;
                                }
                                break;
                            case 2:
                                l = false;
                                num = 1;
                                foreach (var item in cloths)
                                {
                                    if (item != null)
                                    {

                                        Console.WriteLine($"\n{num}) Назва: {item.Name}");
                                        Console.WriteLine($"Бренд: {item.Brand}");
                                        Console.WriteLine($"Розмір: {item.Size}");
                                        Console.WriteLine($"Ціна: {item.PriceWithTax:f1}");
                                        Console.WriteLine($"Оцінка: {item.Feedback}");
                                        Console.WriteLine($"Кількість у продажі: {item.Amount}");
                                        Console.WriteLine($"Чи доступний до продажі: {item.Available}");
                                        l = true;
                                        num++;
                                    }
                                }
                                if (l == false)
                                {
                                    Console.WriteLine("Об'єктів немає.");
                                    flag = true;
                                }
                                else
                                {
                                    Deliveryclothes(cloths);
                                    flag = true;
                                }
                                break;
                        };
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка:  " + ex.Message); }
                } while (!flag); break;


            case 6:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1) Оновити податок на покупку товару \n2) Збільшити об'єм складу для товарів \n3) Чорна п'ятниця \n4) Оптова поставка всіх товарів ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 5) ;
                        else
                        {
                            Console.WriteLine("Помилка. Введіть число від 1 до 4!");
                        }
                        switch (c)
                        {
                            case 1:
                                if (start == false)
                                {
                                    NewTax(cloths);
                                    foreach (var item in cloths)
                                    {
                                        if (item != null) item.CalculateTax();
                                    }
                                }
                                else Console.WriteLine("Під час Чорної п'ятниці оновлення відсотку податків неможливе!");
                                flag = true;
                                break;
                            case 2:
                                NewMaxAmount();
                                flag = true;
                                break;
                            case 3:
                                if (start == true)
                                {
                                    foreach (var item in cloths)
                                        if (item != null) { item.CalculateTax(); }
                                    Console.WriteLine("Чорна п'ятниця закінчилась ціни оновлено!");
                                    start = false;
                                }
                                else
                                {
                                    foreach (var item in cloths)
                                    {
                                        if (item != null)
                                        {
                                            double price = item.PriceWithTax;
                                            Clothes.BlackFriday(ref price);
                                            item.PriceWithTax = price;
                                        }
                                    }
                                    Console.WriteLine("Чорна п'ятниця почалась знижку в 50% на все застосовано!"); start = true;
                                }
                                flag = true;
                                break;
                            case 4:
                                foreach (var item in cloths)
                                    if (item != null)
                                    {
                                        int amount = item.Amount;
                                        if (Clothes.GlobalDelivery(ref amount)) item.Amount = amount;
                                        else Console.WriteLine($"Об'єкт {item.Name} має достатню кількість на складі!");
                                        item.ObjAvailable();
                                    }
                                Console.WriteLine($"Кількість об'єктів оновлено!");
                                flag = true;
                                break;
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка:  " + ex.Message); }
                } while (!flag); break;

            case 7:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1)Зберегти у файл csv \n2)Зберегти у файл json ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                        }
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("\nВведіть назву файлу (*.csv): ");
                                string? path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    SaveToFileCSV(cloths, path);
                                    flag = true;
                                    break;
                                }
                                else throw new FormatException("Ім'я файлу не може бути порожнім!");
                            case 2:
                                Console.WriteLine("\nВведіть назву файлу (*.json): ");
                                path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    SaveToFileJson(cloths, path);
                                    flag = true;
                                    break;
                                }
                                else throw new FormatException("Ім'я файлу не може бути порожнім!");
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка:  " + ex.Message); }
                } while (!flag); break;

            case 8:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1)Зчитати данні з файлу csv \n2)Зчитати данні з файлу json ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("Помилка. Введіть число від 1 до 2!");
                        }
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("\nВведіть назву файлу для зчитування (*.csv): ");
                                string? path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    List<Clothes> read_cloths = ReadFromFileCSV(path, N);
                                    Console.WriteLine("\nЗнайдені об`єкти: \n");
                                    foreach(var item in read_cloths)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    int availableSpace = N - cloths.Count;

                                    if (availableSpace > 0)
                                    {
                                        int itemsToAdd = Math.Min(availableSpace, read_cloths.Count);
                                        cloths.AddRange(read_cloths.GetRange(0, itemsToAdd));
                                    }
                                    flag = true;
                                    break;
                                }
                                else throw new FormatException("Ім'я файлу не може бути порожнім!");
                            case 2:
                                Console.WriteLine("\nВведіть назву файлу для зчитування (*.json): ");
                                path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    List<Clothes> read_cloths = ReadFromFileJson(path);
                                    Console.WriteLine("\nЗнайдені об`єкти: \n");
                                    foreach (Clothes item in read_cloths)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    cloths.AddRange(read_cloths);
                                    flag = true;
                                    break;

                                }
                                else throw new FormatException("Ім'я файлу не може бути порожнім!");
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("Помилка:  " + ex.Message); }
                } while (!flag); break;

            case 9: cloths.Clear();
                Console.WriteLine("Колекцію очищено");
                Clothes.Counter = 0;
                i = 0;
                break;

            default:
                Console.WriteLine("Помилка. Введіть число від 0 до 9.");
                break;
        }
    }
} while (!end);
