namespace GenTree
{
    internal class Functions
    {
        static void PrintInfo(Person person)
        {
            string Info = $"{person.personSurname} {person.personName}, пол - {person.personGender}, дата рождения {person.personBirthday}";
            Console.WriteLine(Info);
        }
    }
}
