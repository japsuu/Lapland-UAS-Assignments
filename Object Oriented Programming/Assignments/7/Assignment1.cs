namespace ObjectOrientedProgramming.Assignments._7;

/// <summary>
/// Tehtävänäsi on toteuttaa luokkarakenne jolla testataan abstraktien metodien toimivuutta.
/// 
/// Luo abstrakti luokka Person jolle määrität
/// - metodi move, määrittele metodi abstraktiksi
/// - jäsenmuuttujat Name ja Age
///
/// Luo luokka Adult
/// - Määritä luokka perimään Person luokan
/// - Toteuta metodi move niin, että konsoliin tulostetaan “Liikkumis muotoni on käveleminen”
///
/// Luo luokka Baby
/// - Määritä luokka perimään Person luokan
/// - Toteuta metodi move niin, että konsoliin tulostetaan “Liikkumis muotoni on konttaaminen”

/// </summary>
public class Assignment1 : ISchoolAssignment
{
    public abstract class Person
    {
        public readonly string Name;
        public readonly int Age;


        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public abstract void Move();


        public sealed override string ToString() => $"Olen {Name} ({Age}v)";
    }


    public class Adult : Person
    {
        public Adult(string name, int age) : base(name, age) { }
        
        
        public override void Move()
        {
            Console.WriteLine("Liikkumismuotoni on käveleminen");
        }
    }
    
    
    public class Baby : Person
    {
        public Baby(string name, int age) : base(name, age) { }
        
        
        public override void Move()
        {
            Console.WriteLine("Liikkumismuotoni on konttaaminen");
        }
    }


    public void Run(string[] args)
    {
        Adult adult = new Adult("Janipetteri", 24);
        Baby baby = new Baby("Byää wää", 1);
        
        Console.WriteLine(adult);
        adult.Move();
        
        Console.WriteLine(baby);
        baby.Move();
    }
}