using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    internal class Settings
    {
        protected string parameterName;
        protected DateTime releaseDate;
        protected int version;

        
        public Settings(string parameterName, DateTime releaseDate, int version)
        {
            this.parameterName = parameterName;
            this.releaseDate = releaseDate;
            this.version = version;
        }

        // Конструктор за умовчанням для ініціалізації полів класу Settings
        public Settings()
        {
            this.parameterName = "Default";
            this.releaseDate = DateTime.Now;
            this.version = 1;
        }

        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }

        public int Version
        {
            get { return version; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Значення версії повинно бути невід'ємним.");
                }
                version = value;
            }
        }

        // Віртуальний метод DeepCopy для створення глибокої копії об'єкта Settings
        public virtual object DeepCopy()
        {
            // Створення нового об'єкта Settings і передача значень полів в нього
            return new Settings(this.parameterName, this.releaseDate, this.version);
        }


        // Перевизначення методу ToString() для класу Settings
        public override string ToString()
        {
            return $"Назва параметру: {ParameterName}, Дата виходу деталі: {ReleaseDate}, Версія: {Version}";
        }

        // Перевизначення методу Equals для порівняння об'єктів типу Settings за їх даними
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Settings other = (Settings)obj;
            return parameterName == other.parameterName &&
                   releaseDate == other.releaseDate &&
                   version == other.version;
        }

        // Перевизначення операторів == та != для порівняння об'єктів типу Settings
        public static bool operator ==(Settings s1, Settings s2)
        {
            if (ReferenceEquals(s1, s2))
            {
                return true;
            }

            if (s1 is null || s2 is null)
            {
                return false;
            }

            return s1.Equals(s2);
        }

        public static bool operator !=(Settings s1, Settings s2)
        {
            return !(s1 == s2);
        }

        // Перевизначення методу GetHashCode для правильної реалізації хеш-коду
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + parameterName?.GetHashCode() ?? 0;
                hash = hash * 23 + releaseDate.GetHashCode();
                hash = hash * 23 + version.GetHashCode();
                return hash;
            }
        }

        
    }
}
