using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_lab3
{
    public enum Computer
    {
        Laptop,
        PersonalComputer,
        Tablet
    }
    class Person
    {

        public string data;
        public double raiting;
        public Person(string data, double raiting)
        {
            this.data = data;
            this.raiting = raiting;

        }
        public override string ToString()
        {
            return $"{data} \nРейтинг - {raiting}";
        }

        // Перевизначення методу Equals для порівняння об'єктів типу Person
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person other = (Person)obj;
            return this.data == other.data && this.raiting.Equals(other.raiting);
        }

        // Перевизначення оператора == для порівняння об'єктів типу Person
        public static bool operator ==(Person person1, Person person2)
        {
            if (ReferenceEquals(person1, person2))
                return true;

            if (person1 is null || person2 is null)
                return false;

            return person1.Equals(person2);
        }

        // Перевизначення оператора != для порівняння об'єктів типу Person
        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }

        // Перевизначення методу GetHashCode для коректної генерації хеш-коду
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + data.GetHashCode();
                hash = hash * 23 + raiting.GetHashCode();
                return hash;
            }
        }

        // Визначення методу DeepCopy для створення глибокої копії об'єкта Person
        public virtual object DeepCopy()
        {
            return new Person(this.data, this.raiting); // Передаємо дані в новий об'єкт
        }

    }


    internal class Specifications: IRateAndCopy
    {
        string os;
        double screen_size;
        public Person data;

        // Реалізація властивості Rating з інтерфейсу IRateAndCopy
        public double Rating
        {
            get { return data.raiting; }
        }
        public Specifications(string os, double screen_size, Person data)
        {
            this.os = os;
            this.screen_size = screen_size;
            this.data = data;
        }

        public Specifications()
        {
            os = "Windows";
            screen_size = 1;
            data = new Person("Default", 300);
        }

        public override string ToString()
        {
            return $"\nНазва - {this.os}\nДіагональ - {this.screen_size}\nДані - {data.ToString()}\n";
        }

        // Визначення методу DeepCopy для створення глибокої копії об'єкта Specifications
        public virtual object DeepCopy()
        {
            Person newData = new Person(data.data, data.raiting);
            return new Specifications(this.os, this.screen_size, newData);
        }
    }
}
