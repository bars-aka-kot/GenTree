namespace GenTree
{
    class Person
    {
        public string personName { get; set; }
        public string personSurname { get; set; }
        public Gender personGender { get; set; }
        public DateTime personBirthday { get; set; }

        public Person(string name, string surname, DateTime birthDay, Gender gender)
        {
            personName = name;
            personSurname = surname;
            personBirthday = birthDay;
            personGender = gender;
        }

    }
}
