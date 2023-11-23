namespace ObjectOrientedProgramming.Assignments._5;

/// <summary>
/// Luo Person, Student, ExchangeStudent ja Teacher luokat.
/// 
/// Jokaiselle henkilölle pitää pystyä antamaan nimi ja ikä.
/// 
/// Opettajalle pitää pystyä antamaan palkkatiedot.
/// 
/// Vaihto-opiskelijalle ja Opiskelijalle pitää pystyä antamaan koulutusohjelma tieto.
/// 
/// Luo pääohjelmassa 1 kpl Student, ExchangeStudent ja Teacher luokista jokaisesta olio ja tallenna olioon esimerkki tietoja.
/// Voit keksiä tiedot itse, kunhan ne ovat tarkoituksenmukaisia.
/// 
/// Käytä periytymisen ominaisuuksia hyväksi toteutuksessa.
///
/// Lisää toString() metodi jonka avulla pääohjelmassa tulostaa konsoliin olioon tallennetut tiedot.
/// </summary>
public class Assignment2 : ISchoolAssignment
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public override string ToString()
        {
            return $"{GetType().Name} '{Name}'\t Age: {Age}";
        }
    }
    
    
    public class Teacher : Person
    {
        public int Salary { get; set; }

        public Teacher(string name, int age, int salary) : base(name, age)
        {
            Salary = salary;
        }
        
        
        public override string ToString()
        {
            return $"{base.ToString()}, Salary: {Salary}";
        }
    }
    
    
    public class Student : Person
    {
        public string Program { get; set; }

        public Student(string name, int age, string program) : base(name, age)
        {
            Program = program;
        }
        
        
        public override string ToString()
        {
            return $"{base.ToString()}, Program: {Program}";
        }
    }
    
    
    public class ExchangeStudent : Student
    {
        public string HomeCountry { get; set; }

        public ExchangeStudent(string name, int age, string program, string homeCountry) : base(name, age, program)
        {
            HomeCountry = homeCountry;
        }
        
        
        public override string ToString()
        {
            return $"{base.ToString()}, HomeCountry: {HomeCountry}";
        }
    }
    
    
    public void Run(string[] args)
    {
        Person person = new("Matti Meikäläinen", 30);
        Student student = new("Maisa Mallikas", 20, "Ohjelmistotekniikka");
        ExchangeStudent exchangeStudent = new("John Doe", 25, "Ohjelmistotekniikka", "USA");
        Teacher teacher = new("Pekka Poutasää", 42, 3200);
        
        Console.WriteLine(person);
        Console.WriteLine(student);
        Console.WriteLine(exchangeStudent);
        Console.WriteLine(teacher);
    }
}