using OOP_lab3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                ExtendedSpecifications elem1 = new ExtendedSpecifications();
                Console.WriteLine(elem1.ToShortString());

                elem1.Computer = Computer.Laptop;
                Console.WriteLine($"Значення індексатора для Computer.Laptop: {elem1[Computer.Laptop]}");

                elem1.Computer = Computer.PersonalComputer;
                Console.WriteLine($"Значення індексатора для Computer.PersonalComputer: {elem1[Computer.PersonalComputer]}");

                elem1.Computer = Computer.Tablet;
                Console.WriteLine($"Значення індексатора для Computer.Tablet: {elem1[Computer.Tablet]}");

                Person data = new Person("Xiaomi", 250);
                Specifications elem2 = new Specifications("Windows", 20, data);
                Console.WriteLine(elem2.ToString());

                ExtendedSpecifications elem3 = new ExtendedSpecifications("Планшет", Computer.Tablet, DateTime.Now, 1);
                Person data1 = new Person("Lenovo", 173);
                Specifications spec1 = new Specifications("Windows", 15.6, data1);
                Person data2 = new Person("Aser", 53);
                Specifications spec2 = new Specifications("Linux", 14, data2);
                Person data3 = new Person("Apple", 21);
                Specifications spec3 = new Specifications("Mac OS", -10, data3);
                elem3.AddSpecifications(spec1, spec2, spec3);
                Console.WriteLine(elem3.ToString());


                Console.WriteLine("\nРозмір масиву: 100:\n");
                TimeChecker(100);
                Console.WriteLine("\nРозмір масиву: 1000:\n");
                TimeChecker(1000);
                Console.WriteLine("\nРозмір масиву: 5000:\n");
               // TimeChecker(5000);

                Console.WriteLine();

                Settings settings1 = new Settings("Parameter", DateTime.Now, 1);
                Settings settings2 = new Settings("Parameter", DateTime.Now, 1);
                //settings2.Version = 10;++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

                // Перевірка на рівність об'єктів
                bool objectsAreEqual = settings1.Equals(settings2);
                Console.WriteLine($"Об'єкти settings1 і settings2 рівні: {objectsAreEqual}");

                // Перевірка на рівність посилань
                bool referencesAreEqual = ReferenceEquals(settings1, settings2);
                Console.WriteLine($"Посилання на settings1 і settings2 рівні: {referencesAreEqual}");

                // Виведення значень хеш-кодів об'єктів
                Console.WriteLine($"Хеш-код settings1: {settings1.GetHashCode()}");
                Console.WriteLine($"Хеш-код settings2: {settings2.GetHashCode()}");

                Console.WriteLine();

                ExtendedSpecifications extendedSpecs = new ExtendedSpecifications("Description", Computer.Laptop, DateTime.Now, 1);

                // Додавання елементів в список виробників деталей
                Person data4 = new Person("Lenovo", 173);
                Person data5 = new Person("Aser", 53);
                extendedSpecs.AddSettings(data4, data5);

                // Додавання елементів в список виробників комп’ютера
                Specifications spec4 = new Specifications("Windows", 15.6, data4);
                Specifications spec5 = new Specifications("Linux", 14, data5);
                extendedSpecs.AddspecificationsDetailsForPC(spec4, spec5);

                // Виведення даних об'єкта ExtendedSpecifications
                Console.WriteLine(extendedSpecs.To2String());



                // Отримання значення властивості типу Settings
                Settings settings5454 = extendedSpecs.GetSettings();
                Console.WriteLine(settings5454.ToString());

                Console.WriteLine();



                ExtendedSpecifications originalExtendedSpecs = new ExtendedSpecifications();

                // Створення глибокої копії за допомогою методу DeepCopy()
                ExtendedSpecifications copyExtendedSpecs = (ExtendedSpecifications)originalExtendedSpecs.DeepCopy();

                // Зміна даних в початковому об'єкті ExtendedSpecifications
                // Зміна даних у властивостях
                originalExtendedSpecs.Description = "Новий опис";
                originalExtendedSpecs.Computer = Computer.PersonalComputer;

                // Виведення даних копії та початкового об'єкта
                Console.WriteLine("Копія ExtendedSpecifications (без змін):");
                Console.WriteLine(copyExtendedSpecs.ToString());

                Console.WriteLine("\nПочатковий ExtendedSpecifications (зі змінами):");
                Console.WriteLine(originalExtendedSpecs.ToString());


                double thresholdRating = 55.0; // Поріг рейтингу для виведення

                Console.WriteLine($"Деталі з рейтингом більше {thresholdRating}:");

                // Використання оператора foreach для виведення деталей з рейтингом більше заданого значення
                foreach (var detail in extendedSpecs.GetDetailsWithRatingGreaterThan(thresholdRating))
                {
                    Console.WriteLine(detail.ToString());
                }

                ExtendedSpecifications extendedSpecs1 = new ExtendedSpecifications(/* параметри конструктора */);

                string searchString = "Lenovo"; // Замініть це на конкретний рядок, який ви шукаєте

                Console.WriteLine($"Деталі з назвою, що містить рядок '{searchString}':");

                // Використання оператора foreach для виведення деталей з назвою, що містить заданий рядок
                foreach (var detail in extendedSpecs.GetDetailsWithNameContaining(searchString))
                {
                    Console.WriteLine(detail.ToString());
                }

                TestCollections<Key, Value<Key>> testCollections = new TestCollections<Key, Value<Key>>(10);

                Key keyToFind = new Key(5);
                TimeSpan listSearchTime = testCollections.SearchListElementTime(keyToFind);
                Console.WriteLine($"Час пошуку елементу {keyToFind.Value} у списку keysList: {listSearchTime}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        public static void TimeChecker(int size)
        {
            //одновимірний
            Specifications[] oneArray = new Specifications[size];

                //прямокутний
                Specifications[,] rectangularArray = new Specifications[size, size];

                //ступінчастий
                Specifications[][] jaggedArray = new Specifications[size][];

            for (int i = 0; i < size; i++)
            {
                jaggedArray[i] = new Specifications[size];
            }

            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                oneArray[i] = new Specifications();
            }
            sw1.Stop();
            Console.WriteLine($"Час для одновимірного масиву: {sw1.ElapsedMilliseconds} мс");

            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    rectangularArray[i, j] = new Specifications();
                }
            }
            sw2.Stop();
            Console.WriteLine($"Час для двовимірного прямокутного масиву: {sw2.ElapsedMilliseconds} мс");

            var sw3 = Stopwatch.StartNew();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    jaggedArray[i][j] = new Specifications();
                }
            }
            sw3.Stop();
            Console.WriteLine($"Час для двовимірного ступінчастого масиву: {sw3.ElapsedMilliseconds} мс");
         }
    }
}

