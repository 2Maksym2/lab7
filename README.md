# lab7
int N, reviews = 0;
bool start = false, end=false;
while (true)
    {
        Console.WriteLine("������ ������� �������� (����� �����):");
        if (int.TryParse(Console.ReadLine(), out N) && N > 0)
        {
            break;
        }
        else
        {
            Console.WriteLine("�������. ������ ����� ����� 0!");
        }
    }
int a, i = 0;
List<Clothes> cloths = new();
do
{
    Console.WriteLine("\n����: \n 1) ������ �������; \n 2) ������� ������ ��������; \n 3) ������ �������; \n 4) �������� �������; \n 5) ������������ �������� \n 6) ������������ ������ static ������ \n 7)�������� �������� ��'���� � ���� \n 8)������� �������� ��'���� � ����� \n 9)�������� �������� ��'���� \n 0) �����;");
    if (!int.TryParse(Console.ReadLine(), out a))
    {
        Console.WriteLine("�������. ������ �������� �����!");
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
                else Console.WriteLine("������������ ������� ��'����.");
                break;



            case 2:
                bool flag = false;
                Console.WriteLine($"\n������ ��'����: {Clothes.Counter}");
                foreach (var item in cloths)
                {
                    if (item != null)
                    {
                        Console.WriteLine($"\n�����: {item.Name}");
                        Console.WriteLine($"�����: {item.Brand}");
                        Console.WriteLine($"�����: {item.Size}");
                        Console.WriteLine($"ֳ��: {item.PriceWithTax:f1}");
                        Console.WriteLine($"������: {item.Feedback}");
                        Console.WriteLine($"ʳ������ � ������:  {item.Amount}");
                        Console.WriteLine($"�� ��������� �� ������: {item.Available}");
                        Console.WriteLine();
                        flag = true;
                    }

                }
                if (flag == false) Console.WriteLine("��'���� ����.");
                break;

            case 3:
                int b;
                do
                {
                    flag = false;
                    Console.WriteLine("������ ����: 1) �� ������; 2) �� �������;");
                    if (int.TryParse(Console.ReadLine(), out b) && b > 0 && b < 3) ;

                    else
                    {
                        Console.WriteLine("�������. ������ ����� �� 1 �� 2!");
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
                    Console.WriteLine("�������� �������: 1) �� ������; 2) �� ��'��; ");
                    if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                    else
                    {
                        Console.WriteLine("�������. ������ ����� �� 1 �� 2!");
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
                        Console.WriteLine("\n1) �������� ��'��� \n2) �������� �������� ��'���� ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("�������. ������ ����� �� 1 �� 2!");
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

                                        Console.WriteLine($"\n{num}) �����: {item.Name}");
                                        Console.WriteLine($"�����: {item.Brand}");
                                        Console.WriteLine($"�����: {item.Size}");
                                        Console.WriteLine($"ֳ��: {item.PriceWithTax:f2}");
                                        Console.WriteLine($"������: {item.Feedback}");
                                        Console.WriteLine($"ʳ������ � ������: {item.Amount}");
                                        Console.WriteLine($"�� ��������� �� ������: {item.Available}");
                                        l = true;
                                        num++;
                                    }
                                }
                                if (l == false)
                                {
                                    Console.WriteLine("��'���� ����.");
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

                                        Console.WriteLine($"\n{num}) �����: {item.Name}");
                                        Console.WriteLine($"�����: {item.Brand}");
                                        Console.WriteLine($"�����: {item.Size}");
                                        Console.WriteLine($"ֳ��: {item.PriceWithTax:f1}");
                                        Console.WriteLine($"������: {item.Feedback}");
                                        Console.WriteLine($"ʳ������ � ������: {item.Amount}");
                                        Console.WriteLine($"�� ��������� �� ������: {item.Available}");
                                        l = true;
                                        num++;
                                    }
                                }
                                if (l == false)
                                {
                                    Console.WriteLine("��'���� ����.");
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
                    catch (FormatException ex) { Console.WriteLine("�������:  " + ex.Message); }
                } while (!flag); break;


            case 6:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1) ������� ������� �� ������� ������ \n2) �������� ��'�� ������ ��� ������ \n3) ����� �'������ \n4) ������ �������� ��� ������ ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 5) ;
                        else
                        {
                            Console.WriteLine("�������. ������ ����� �� 1 �� 4!");
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
                                else Console.WriteLine("ϳ� ��� ����� �'������ ��������� ������� ������� ���������!");
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
                                    Console.WriteLine("����� �'������ ���������� ���� ��������!");
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
                                    Console.WriteLine("����� �'������ �������� ������ � 50% �� ��� �����������!"); start = true;
                                }
                                flag = true;
                                break;
                            case 4:
                                foreach (var item in cloths)
                                    if (item != null)
                                    {
                                        int amount = item.Amount;
                                        if (Clothes.GlobalDelivery(ref amount)) item.Amount = amount;
                                        else Console.WriteLine($"��'��� {item.Name} �� �������� ������� �� �����!");
                                        item.ObjAvailable();
                                    }
                                Console.WriteLine($"ʳ������ ��'���� ��������!");
                                flag = true;
                                break;
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("�������:  " + ex.Message); }
                } while (!flag); break;

            case 7:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1)�������� � ���� csv \n2)�������� � ���� json ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("�������. ������ ����� �� 1 �� 2!");
                        }
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("\n������ ����� ����� (*.csv): ");
                                string? path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    SaveToFileCSV(cloths, path);
                                    flag = true;
                                    break;
                                }
                                else throw new FormatException("��'� ����� �� ���� ���� �������!");
                            case 2:
                                Console.WriteLine("\n������ ����� ����� (*.json): ");
                                path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    SaveToFileJson(cloths, path);
                                    flag = true;
                                    break;
                                }
                                else throw new FormatException("��'� ����� �� ���� ���� �������!");
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("�������:  " + ex.Message); }
                } while (!flag); break;

            case 8:
                flag = false;
                do
                {
                    try
                    {
                        Console.WriteLine("\n1)������� ���� � ����� csv \n2)������� ���� � ����� json ");
                        if (int.TryParse(Console.ReadLine(), out c) && c > 0 && c < 3) ;
                        else
                        {
                            Console.WriteLine("�������. ������ ����� �� 1 �� 2!");
                        }
                        switch (c)
                        {
                            case 1:
                                Console.WriteLine("\n������ ����� ����� ��� ���������� (*.csv): ");
                                string? path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    List<Clothes> read_cloths = ReadFromFileCSV(path, N);
                                    Console.WriteLine("\n������� ��`����: \n");
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
                                else throw new FormatException("��'� ����� �� ���� ���� �������!");
                            case 2:
                                Console.WriteLine("\n������ ����� ����� ��� ���������� (*.json): ");
                                path = Console.ReadLine();
                                if (!string.IsNullOrEmpty(path))
                                {
                                    List<Clothes> read_cloths = ReadFromFileJson(path);
                                    Console.WriteLine("\n������� ��`����: \n");
                                    foreach (Clothes item in read_cloths)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    cloths.AddRange(read_cloths);
                                    flag = true;
                                    break;

                                }
                                else throw new FormatException("��'� ����� �� ���� ���� �������!");
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("�������:  " + ex.Message); }
                } while (!flag); break;

            case 9: cloths.Clear();
                Console.WriteLine("�������� �������");
                Clothes.Counter = 0;
                i = 0;
                break;

            default:
                Console.WriteLine("�������. ������ ����� �� 0 �� 9.");
                break;
        }
    }
} while (!end);
