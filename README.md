# lab7
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
