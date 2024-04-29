using System;
using System.Linq;

namespace GenTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamilyMember father = new FamilyMember("Салават", "Басиров", DateTime.Parse("06-10-1954"), Gender.male);
            FamilyMember mother = new FamilyMember("Лилия", "Басирова", DateTime.Parse("01-01-1953"), Gender.female);
            father.Spouse = mother;
            mother.Spouse = father;
            FamilyMember children = new FamilyMember("Раушания", "Басирова", DateTime.Parse("18-01-1982"), Gender.female);
            children.Father = father;
            children.Mother = mother;
            father.AddChild(children);
            mother.AddChild(children);
            children = new FamilyMember("Руслан", "Басиров", DateTime.Parse("02-11-1977"), Gender.male);
            children.Father = father;
            children.Mother = mother;
            father.AddChild(children);
            mother.AddChild(children);
            children = new FamilyMember("Ильгиз", "Басиров", DateTime.Parse("01-04-1987"), Gender.male);
            children.Father = father;
            children.Mother = mother;
            father.AddChild(children);
            mother.AddChild(children);

            var father2 = new FamilyMember("Хамит", "Басиров", DateTime.Parse("01/01/1930"), Gender.male);
            var mother2 = new FamilyMember("Миникамал", "Басирова", DateTime.Parse("01/01/1931"), Gender.female);
            mother2.Spouse = father2;
            father2.Spouse = mother2;
            father.Father = father2;
            father.Mother = mother2;
            mother2.AddChild(father);
            father2.AddChild(father);

            var father3 = children;
            var mother3 = new FamilyMember("Айгуль", "Басирова", DateTime.Now, Gender.female);
            father3.Spouse = mother;
            mother3.Spouse = father3;

            children = new FamilyMember("Ильдар", "Басиров", DateTime.Now, Gender.male);
            children.Father = father3;
            children.Mother = mother3;
            father3.AddChild(children);
            mother3.AddChild(children);

            children = new FamilyMember("Тимур", "Басиров", DateTime.Now, Gender.male);
            children.Father = father3;
            children.Mother = mother3;
            father3.AddChild(children);
            mother3.AddChild(children);

            FamilyMember.PrintCloseRelatives(father);

            Console.ReadKey(true);

        }
    }
}
