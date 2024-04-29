namespace GenTree
{
    internal class FamilyMember : Person, IMarried
    {
        private FamilyMember spouse = null!;
        public FamilyMember Mother { get; set; } = null!;
        public FamilyMember Father { get; set; } = null!;
        public List<FamilyMember> Childs { get; set; }
        public FamilyMember Spouse
        {
            get => spouse;
            set
            {

                if (value.personGender == this.personGender)
                {
                    throw new ArgumentException("Same-sex marriage is not permitted by law and is condemned by society.");
                }
                else
                {
                    spouse = value;
                }
            }
        }

        public FamilyMember(string name, string lastName, DateTime birthDay, Gender gender) : base(name, lastName, birthDay, gender)
        {
            Childs = new List<FamilyMember>();
        }

        public void SetParents(FamilyMember father, FamilyMember mother)
        {
            this.Father = father;
            this.Mother = mother;
        }

        public void AddChild(FamilyMember child)
        {
            Childs.Add(child);
        }

        public void RemoveChild(FamilyMember child)
        {
            Childs.Remove(child);
        }

        /// <summary>Метод выводит на экран семью</summary>
        public void PrintFamily()
        {
            Console.WriteLine(this.ToString());

            Console.WriteLine("Mother:");
            Console.WriteLine(Mother is null ? "None" : Mother.ToString());

            Console.WriteLine("Father:");
            Console.WriteLine(Father is null ? "None" : Father.ToString());

            PrintSibling(Childs);

            Console.WriteLine("Grandmothers and grandfathers:");

            if (Father is not null)
            {
                Console.WriteLine(Father.Mother is not null ? Father.Mother.ToString() : "None");
                Console.WriteLine(Father.Father is not null ? Father.Father.ToString() : "None");
            }

            if (Mother is not null)
            {
                Console.WriteLine(Mother.Mother is not null ? Mother.Mother.ToString() : "None");
                Console.WriteLine(Mother.Father is not null ? Mother.Father.ToString() : "None");
            }
        }

        public override string ToString()
        {
            return $"{personName}";
        }

        public static string PrintInfo(Person person)
        {
            return $"{person.personSurname} {person.personName}, пол - {person.personGender}, дата рождения {person.personBirthday}";
        }

        /// <summary>Метод выводит на экран генеологическое древо</summary>
        public static void PrintTree(FamilyMember person)
        {
            Console.WriteLine($"{person.personSurname}`s family tree:");
            PrintPerson(person);
        }

        private static void PrintPerson(FamilyMember person)
        {
            PrintSpouse(person);
            PrintChilds(person.Childs);
            Console.WriteLine();

            if (person.Childs.Count > 0)
            {
                foreach (FamilyMember child in person.Childs)
                {
                    if (child.personGender == Gender.male && child.Childs.Count > 0)
                    {
                        PrintPerson(child);
                    }
                }
            }
        }

        private static void PrintSibling(List<FamilyMember> persons, FamilyMember excludePerson = null!)
        {
            if (persons is not null && persons.Count > 0)
            {
                List<FamilyMember> brothers = persons.Where(x => x.personGender == Gender.male && x != excludePerson).ToList();
                List<FamilyMember> sisters = persons.Where(x => x.personGender == Gender.female && x != excludePerson).ToList();

                Console.WriteLine("Brothers:");

                if (brothers.Count > 0)
                {
                    foreach (FamilyMember child in brothers)
                    {
                        if (child.personGender == Gender.male && child != excludePerson)
                        {
                            Console.WriteLine(child.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine("Sisters:");

                if (sisters.Count > 0)
                {
                    foreach (FamilyMember child in sisters)
                    {
                        if (child.personGender == Gender.female && child != excludePerson)
                        {
                            Console.WriteLine(child.ToString());
                        }
                    }

                }
                else
                {
                    Console.WriteLine("None");
                }
            }
            else
            {
                Console.WriteLine("No brothers and sisters");
            }

        }

        private static void PrintChilds(List<FamilyMember> childs)
        {
            if (childs.Count > 0)
            {
                Console.Write("Kids: ");

                foreach (var child in childs)
                {
                    Console.Write($"{child} ");
                }

            }
        }

        private static void PrintSpouse(FamilyMember person)
        {
            string partner;

            if (person.Spouse is not null)
            {
                partner = person.Spouse.personGender == Gender.male ? $" and husband {person.Spouse}" : $" and wife {person.Spouse}";

            }
            else
            {
                partner = "";
            }

            Console.WriteLine($"{person}{partner}");
        }

        // Доработайте приложение генеалогического дерева таким образом чтобы программа
        // выводила на экран близких родственников(жену/мужа) и братьев/сестёр определённого человека.
        // Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.

        /// <summary>Метод выводит на экран близких родственников</summary>
        public static void PrintCloseRelatives(FamilyMember person)
        {
            Console.WriteLine($"{person}'s close relatives:");
            PrintSpouse(person);
            List<FamilyMember> sibling = [];

            if (person.Mother is not null)
            {
                sibling.AddRange(person.Mother.Childs);
            }

            if (person.Father is not null)
            {
                sibling = sibling.Union(person.Father.Childs).ToList();
            }

            if (sibling.Count > 0)
            {
                PrintSibling(sibling, person);
            }
            else
            {
                Console.WriteLine($"{person} do not has brothers and systers.");
            }
        }
    }
}