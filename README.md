МІНІСТЕРСТВО ОСВІТИ І НАУКИ УКРАЇНИ
Національний аерокосмічний університет ім. М. Є. Жуковського
«Харківський авіаційний інститут»
факультет програмної інженерії та бізнесу
кафедра інженерії програмного забезпечення

**Практична робота (Practice-1)**
з дисципліни «Об’єктно-орієнтоване програмування»
назва дисципліни
на тему: «Використання Git і GitHub. Git flow»


Виконав: студент 2 курсу групи	 622п
напряму підготовки (спеціальності)
121 інженерія програмного забезпечення	
*(шифр і назва напряму підготовки (спеціальності))*
               Полетай М.В.
*(прізвище й ініціали студента)*
Прийняв: доц. каф. 603, к.т.н., доцент
               Шевченко І.В.
*(посада, науковий ступінь, прізвище й ініціали)*
Національна шкала:  	 Кількість балів:  	 Оцінка ECTS:  	

Харків – 2024


**ПОСТАНОВКА ЗАДАЧІ**
**Git:**
1.	Установити систему контролю версій Git (якщо не встановлена!).
2.	Створити локальний репозиторій під контролем Git.
3.	У гілку master (main) додати декілька комітів (не забуваємо про іменування 
комітів!).
4.	Для гілки master (main) вивести історію комітів.
5.	Продемонструвати переключення між комітами.
6.	Від гілки master (main) створити гілку develop.
7.	У гілку develop додати декілька комітів.
8.	Від гілки develop cтворити гілку my-feature.
9.	У гілку my-feature додати декілька комітів.
10.	Влити гілку my-feature у гілку develop.
11.	Видалити гілку my-feature.
12.	Для гілки develop вивести історію комітів.
13.	Влити гілку develop у гілку master (main).
14.	Видалити гілку develop.
15.	Для гілки master (main) вивести історію комітів.
**GitHub:**
1.	Створити обліковий запис для GitHub (якщо він відсутній!).
2.	Створити віддалений пустий репозиторій.
3.	Підключитися до віддаленого репозиторію.
4.	Відправити вміст локального репозиторію у віддалений репозиторій.
5.	Продемонструвати клонування віддаленого репозиторію.
6.	Створити коміти у склонованому репозиторію.
7.	Відправити вміст склонованого репозиторію у віддалений репозиторій.
8.	Продемонструвати витягування оновленого вмісту віддаленого репозиторію.
**Visual Studio:**
Виконуючи поточну практичну роботу:
-	додати створення локального і віддаленого репозиторію (файл 
Readme.md додаємо!);
-	зміни у коді фіксувати через створення комітів з логічними для 
виконаних змін назвами;
-	продемонструвати відправлення вмісту локального репозиторію у 
віддалений репозиторій;
-	у локальному або віддаленому репозиторію оформити Readme.md файл* (інформацію беремо із звіту до практичної роботи!), зафіксувати зміни створити відповідним комітом, синхронізувати локальний і віддалений репозиторії.

**ВИКОНАННЯ РОБОТИ**
**Git:**
1.	Установити систему контролю версій Git.
2.	Створити локальний репозиторій під контролем Git.
![ Створення локального репозиторію під контролем Git](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155126.jpg)
3.	У гілку master (main) додати декілька комітів (не забуваємо про іменування комітів!).
![ Додання комітів у гілку master (main)](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155153.jpg)
![ Додання комітів у гілку master (main)](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155232.jpg)
4.	Для гілки master (main) вивести історію комітів.
![ Історія комітів (гілка master (main)](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155236.jpg)
5.	Продемонструвати переключення між комітами.
![ Переключення між комітами](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155241.jpg)
6.	Від гілки master (main) створити гілку develop.
![ Створення гілки develop](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155244.jpg)
7.	У гілку develop додати декілька комітів.
 ![ Коміти у гілці develop](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155323.jpg)
8.	Від гілки develop cтворити гілку my-feature.
![ Створення гілки my-feature](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155326.jpg)
9.	У гілку my-feature додати декілька комітів.
![ Додавання комітів у гілку my-feature](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155329.jpg)
10.	Влити гілку my-feature у гілку develop.
![ Влиття гілки my-feature у гілку develop](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155412.jpg)
11.	Видалити гілку my-feature. 
 Видалення гілки my-feature
![ Видалення гілки my-feature](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155415.jpg)

12.	Для гілки develop вивести історію комітів.

![ Історія комітів гілки develop](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155419.jpg)

13.	Влити гілку develop у гілку master.

![ Влиття гілки develop у гілку master](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155422.jpg)

14.	Видалити гілку develop.

![ Видалення гілки develop](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155432.jpg)

15.	Для гілки master вивести історію комітів.
![ Історія комітів для гілки master (main)](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155442.jpg)
**GitHub:**
1.	Створити обліковий запис для GitHub (якщо він відсутній!).

2.	Створити віддалений пустий репозиторій.

![ Створення репозиторію](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155453.jpg)

3.	Підключитися до віддаленого репозиторію.

![ Підключення до локального репозиторію](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155505.jpg)

4.	Відправити вміст локального репозиторію у віддалений репозиторій.

![  Відправлення вмісту локального репозиторію у віддалений репозиторій](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155514.jpg)

5.	Продемонструвати клонування віддаленого репозиторію.

![ Клонування віддаленого репозиторію](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155524.jpg)

6.	Створити коміти у склонованому репозиторію.

![ Коміти у склонованому репозиторію](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155533.jpg)

7.	Відправити вміст склонованого репозиторію у віддалений репозиторій.

![ Відправлення вмісту склонованого репозиторію у віддалений репозиторій.](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155542.jpg)

8.	Продемонструвати витягування оновленого вмісту віддаленого репозиторію.

![ Витягування оновленого вмісту віддаленого репозиторію.](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155555.jpg)
**Visual Studio:**

Виконуючи поточну практичну роботу:

-додати створення локального і віддаленого репозиторію (файл Readme.md додаємо!);
![Створення локального і віддаленого репозиторію з Readme.md](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155606.jpg)

-зміни у коді фіксувати через створення комітів з логічними для виконаних змін назвами;

![ Зміни у коді фіксуються через створення комітів з логічними для виконаних змін назвами](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155616.jpg)

-продемонструвати відправлення вмісту локального репозиторію у віддалений репозиторій;

![ Відправлення вмісту локального репозиторію у віддалений репозиторій](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155625.jpg)

-у локальному або віддаленому репозиторію оформити Readme.md  файл* (інформацію беремо із звіту до практичної роботи!), зафіксувати зміни створити відповідним комітом, синхронізувати локальний і віддалений репозиторії.

![ Робота з файлом Readme.md](https://github.com/2Maksym2/lab7/blob/main/images/%D0%97%D0%BD%D1%96%D0%BC%D0%BE%D0%BA%20%D0%B5%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-11-11%20155636.jpg)
