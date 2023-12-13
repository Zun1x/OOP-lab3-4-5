using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    internal class ExtendedSpecifications: Settings, IRateAndCopy
    {
        private string description;
        private Specifications specifications;
        private DateTime release_date;
        private int release_version;
        private Specifications[] name;
        private Computer computer;
        private Computer computerType;
        private ArrayList manufacturersList = new ArrayList();
        private ArrayList computerDetails = new ArrayList();
        protected Settings settings;
        private List<double> detailsRatings = new List<double>(); 


        public ExtendedSpecifications(string description, Computer computer, DateTime release_date, int release_version)
        {
            this.description = description;
            this.computer = computer;
            this.release_date = release_date;
            this.release_version = release_version;
            settings = new Settings(description, release_date, release_version);
        }

        public ExtendedSpecifications()
        {
            description = "Ноутбук";
            computer = Computer.Laptop;
            release_date = DateTime.Now;
            release_version = 1;
            name = new Specifications[0];
            base.ParameterName = "DefaultParameter";
            base.ReleaseDate = DateTime.Now;
            base.Version = 1;
        }


        // Конструктор з параметрами для ініціалізації полів класу
        public ExtendedSpecifications(string parameterName, DateTime releaseDate, int version, Computer computerType)
        {
            // Ініціалізація полів з базового класу Settings через виклик його конструктора з параметрами
            base.ParameterName = parameterName;
            base.ReleaseDate = releaseDate;
            base.Version = version;

            // Ініціалізація нового поля computerType
            this.ComputerType = computerType;
        }


        // Конструктор класу з урахуванням нового поля
        public ExtendedSpecifications(string parameterName, DateTime releaseDate, int version)
            : base(parameterName, releaseDate, version)
        {
            manufacturersList = new ArrayList();
        }


        // Закрите поле та властивість для доступу до типу комп'ютера
        protected Computer ComputerType
        {
            get { return computerType; }
            set { computerType = value; }
        }

        // Властивість для доступу до списку виробників
        public ArrayList ManufacturersList
        {
            get { return manufacturersList; }
            set { manufacturersList = value; }
        }

        // Властивість для доступу до списку деталей в комп’ютері
        public ArrayList ComputerDetails
        {
            get { return computerDetails; }
            set { computerDetails = value; }
        }


        public string Description
        {
            get { return description; }
            set { description = value; }
        } 
        
        public Computer Computer
        {
            get { return computer; }
            set { computer = value; }
        }
        
        public DateTime Release_date
        {
            get { return release_date; }
            set { release_date = value; }
        }

        public int ReleaseVersion
        {
            get { return release_version; }
            set { release_version = value; }
        }

        public Specifications[] Name
        {
            get { return name; } 
            set { name = value; }
        }

        public bool this[Computer index]
        {
            get
            {
                return Computer == index;
            }
        }

        public Settings GetSettings()
        {
            return settings;
        }


        // Додавання виробників до списку
        public void AddManufacturer(Specifications manufacturer)
        {
            manufacturersList.Add(manufacturer);
        }

        // Метод для додавання елементів в список деталей
        public void AddSettings(params Person[] settings)
        {
            foreach (var setting in settings)
            {
                computerDetails.Add(setting);
            }
        }
        public void AddSpecifications(params Specifications[] Spec)
        {
            int oldLength = Spec.Length;
            Array.Resize(ref name, oldLength + Spec.Length);
            for (int i = 0; i < Spec.Length; i++)
            {
                name[oldLength + i] = Spec[i];
            }
        }

        public double Rating
        {
            get { return Averageraiting; }
        }

        public double Averageraiting
        {
            get
            {
                if (name.Length == 0)
                    return 0;

                double sum = 0;

                foreach (Specifications specification in name)
                {
                    sum += specification.data.raiting;
                }

                return sum / name.Length;
            }
        }


        public double AverageRatingDetails
        {
            get
            {
                if (manufacturersList.Count == 0)
                {
                    return 0; // Повернення 0 у випадку порожнього списку
                }

                double totalRating = 0;
                foreach (Specifications manufacturer in manufacturersList)
                {
                    totalRating += manufacturer.data.raiting;
                }

                return totalRating / manufacturersList.Count; // Повернення середнього значення
            }
        }

        // Метод для додавання елементів в список деталей в комп’ютері
        public void AddspecificationsDetailsForPC(params Specifications[] specs)
        {
            foreach (var spec in specs)
            {
                ManufacturersList.Add(spec);
            }
        }


        // Властивість типу Settings
        public Settings BaseSettings
        {
            get
            {
                return new Settings
                {
                    ParameterName = this.ParameterName,
                    ReleaseDate = this.ReleaseDate,
                    Version = this.Version,
                };
            }
            set
            {
                this.ParameterName = value.ParameterName;
                this.ReleaseDate = value.ReleaseDate;
                this.Version = value.Version;
            }
        }

        public override object DeepCopy()
        {
            Specifications[] copiedSpecifications = new Specifications[this.Name.Length];
            for (int i = 0; i < this.Name.Length; i++)
            {
                copiedSpecifications[i] = (Specifications)this.Name[i].DeepCopy();
            }

            return new ExtendedSpecifications(this.Description, this.Computer, this.Release_date, this.ReleaseVersion)
            {
                Name = copiedSpecifications
            };

            ExtendedSpecifications copiedSpecs = new ExtendedSpecifications
            {
                // Копіюємо значення базового класу
                ParameterName = this.ParameterName,
                ReleaseDate = this.ReleaseDate,
                Version = this.Version,
                ComputerType = this.ComputerType
            };

            // Копіюємо ArrayList з деталями комп'ютера
            foreach (var detail in this.ComputerDetails)
            {
                copiedSpecs.ComputerDetails.Add(detail);
            }

            return copiedSpecs;
            return this.DeepCopy();
        }


        // Метод, який повертає ітератор
        public IEnumerable<Person> GetDetailsWithRatingGreaterThan(double value)
        {
            foreach (Person detail in computerDetails)
            {
                if (detail.raiting > value)
                {
                    yield return detail;
                }
            }
        }


        // Ітератор з параметром типу string
        public IEnumerable<Person> GetDetailsWithNameContaining(string searchString)
        {
            foreach (Person detail in computerDetails)
            {
                if (detail.data.Contains(searchString))
                {
                    yield return detail;
                }
            }
        }



        public override string ToString()
        {
            return $"\nОпис техніки: {description}, \nТип ПК: {computer}, \nДата виходу гаджета: {release_date}, \nВерсія випуску: {release_version}, \nЧисленість: {name.Length/2}";
        }

        public virtual string ToShortString()
        {
            return $"\nОпис техніки: {description}, \nТип ПК: {computer}, \nДата виходу гаджета: {release_date}, \nВерсія випуску: {release_version}, \nСереднє значення рейтингу виробників: {Averageraiting}";
        }


        // Перевантаження методу ToString для виводу всіх полів класу
        public string To2String()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Назва параметру: {ParameterName}");
            sb.AppendLine($"Дата релізу: {ReleaseDate}");
            sb.AppendLine($"Версія: {Version}");
            sb.AppendLine($"Тип комп'ютера: {ComputerType}");

            sb.AppendLine("Manufacturers:");
            foreach (var manufacturer in ManufacturersList)
            {
                sb.AppendLine(manufacturer.ToString());
            }

            return sb.ToString();
        }


        // Віртуальний метод для формування короткого рядка зі значеннями полів
        public virtual string To2ShortString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Назва параметру: {ParameterName}");
            sb.AppendLine($"Дата релізу: {ReleaseDate}");
            sb.AppendLine($"Версія: {Version}");
            sb.AppendLine($"Тип комп'ютера: {ComputerType}");
            sb.AppendLine($"Середній рейтинг: {AverageRatingDetails}");

            return sb.ToString();
        }
    }
}
