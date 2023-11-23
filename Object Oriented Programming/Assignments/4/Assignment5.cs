namespace ObjectOrientedProgramming.Assignments._4;

/// <summary>
/// Luo uusi Opiskelija luokka ja määrittele luokalle tyypillisiä ominaisuuksia ja toimintoja.
/// Luo pääohjelma, jossa luot 3 eri opiskelijan tiedot.
/// Lisää opiskelijat listaan ja lopuksi tulosta opiskelijoiden tiedot käyttämällä haluamaasi toistorakennetta.
/// </summary>
public class Assignment5 : ISchoolAssignment
{
    public class Student
    {
        public string Name { get; private set; }
        public string StudentNumber { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Energy { get; private set; } = 100;

        public Student(string name, string studentNumber, int age, string address, string phoneNumber)
        {
            Name = name;
            StudentNumber = studentNumber;
            Age = age;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        
        public void Eat()
        {
            Console.WriteLine("Opiskelija syö.");
            Energy += 10;
        }
        
        public void Sleep()
        {
            Console.WriteLine("Opiskelija nukkuu.");
            Energy += 50;
        }
        
        public void Study()
        {
            Console.WriteLine("Opiskelija opiskelee.");
            Energy -= 20;
        }
        
        public void Party()
        {
            Console.WriteLine("Opiskelija juhlii.");
            Energy = 0;
        }

        public override string ToString()
        {
            return $"Nimi: {Name}\nOpiskelijanumero: {StudentNumber}\nIkä: {Age}\nOsoite: {Address}\nPuhelinnumero: {PhoneNumber}";
        }
    }
    
    
    public void Run(string[] args)
    {
        List<Student> students = new()
        {
            new Student("Matti Meikäläinen", "012345678", 20, "Mehiläisentie 10", "0401234567"),
            new Student("Pekka Pouta", "987654321", 28, "Sääasema 1", "0459876543"),
            new Student("Liisa Virtanen", "123456789", 19, "Koulutie 5", "0501234567")
        };

        foreach (Student student in students)
        {
            Console.WriteLine($"{student}\n");
        }
    }
}