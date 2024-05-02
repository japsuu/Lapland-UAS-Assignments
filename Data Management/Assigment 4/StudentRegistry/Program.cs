using MySqlConnector; // Using ADO.NET (System.Data.SqlClient) to interact with the database.

namespace StudentRegistry;

/*
    Toteuta tehtävässä annetun tietokannan päälle ohjelma, joka toteuttaa alla pyydetyt toiminnot.
    Tässä tehtävässä käytettävä tietokantarakenne ja data on sama kuin tehtävässä 2, joten voit käyttää sen kaaviota apuna.
    1. Opiskelijan lisääminen tietokantaan käyttäjän syötteen perusteella. Kysy tarvittavat tiedot ja lisää opiskelija tietokantaan. Tulosta onnistuneen lisäämisen jälkeen lisätyn opiskelijan ID
    2. Opiskelijan haku etunimellä ja sukunimellä käyttäjän syötteen perusteella
        a. Tulosta opiskelijan tiedot (nimi, id, kurssisuoritukset)
        b. Tulosta opiskelijan tietojen alle, kurssisuoritukset.
        c. Näytä: kurssin nimi, arvosana, suorituspäivä ja opettaja
    3. Opiskelijan poistaminen tietokannasta
        a. Voi tehdä ID:n perusteella
        b. Poista myös opiskelijan mahdolliset suoritukset
    4. Anna opiskelijan tiedoissa mahdollisuus lisätä kurssisuoritus tietokantaan
        a. Riittää että käyttäjältä kysytään kurssin koodi (ID) ja arvosana sekä opiskelijan tunniste. Jos opiskelijan tiedot ovat avoinna (tehtävän kohta 2), voidaan hyödyntää suoraan ruudulla näkyvän opiskelijan tunnistetta. Voidaan tehdä myös kokonaan omana toimintona.
            i. Käytä tätä hetkeä suorittamisajankohtana (now)
            ii. Tässä voi olla hyödyllistä tulostaa käyttäjälle esim. saatavilla olevien kurssien ja opettajien nimet käytettävyyden helpottamiseksi.
        b. Jos opiskelijalla on olemassa oleva suoritus, päivitä se uusilla tiedoilla sekä tämän hetken aikaleimalla.
    5. Toteuta kaikki kyselyt siten, että SQL-injektiot eivät ole mahdollisia ja jaa koodi omiin operaatiokohtaisiin funktioihinsa luettavuuden parantamiseksi
    6. Rakenna valikko, jossa käyttäjä voi valita haluamansa toimenpiteen.
    7. Anna käyttäjälle mahdollisuus tallentaa muutokset (esim. lopettamisen yhteydessä) ja perua tehdyt muutokset transaktioiden avulla.

    Arviointiperusteet:
    - Opiskelijan lisääminen (1p)
    - Opiskelijan haku ja opiskelijan tietojen näyttö (2p)
    - Opiskelijan poistaminen (1p)
    - Kurssisuorituksen lisääminen (2p)
    - Transaktiot (2p)
    - Koodin siisteys ja laatu, kyselyiden suorituksen turvallisuus, virheenkäsittely (2p)
*/

/// <summary>
/// Represents a transaction to be executed on the database.
/// </summary>
public class Transaction
{
    public string CommandText { get; set; }
    public List<MySqlParameter> Parameters { get; set; }


    public Transaction(string commandText, List<MySqlParameter> parameters)
    {
        CommandText = commandText;
        Parameters = parameters;
    }
}

internal static class Program
{
    private const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=tehtava2;Uid=root;Pwd=;";
    
    // Used to store transactions to be executed on the database.
    private static readonly Queue<Transaction> TransactionQueue = new();

    
    private static void Main(string[] args) => DisplayMenu();


    /// <summary>
    /// Enters a blocking loop to display the menu and handle user input.
    /// </summary>
    private static void DisplayMenu()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Lisää opiskelija");
            Console.WriteLine("2. Hae opiskelija");
            Console.WriteLine("3. Poista opiskelija");
            Console.WriteLine("4. Lisää kurssisuoritus opiskelijalle");
            Console.WriteLine("5. Tallenna kaikki muutokset");
            Console.WriteLine("6. Lopeta");
            Console.WriteLine("Valitse toiminto (1-5): ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    SearchStudent();
                    break;
                case "3":
                    DeleteStudent();
                    break;
                case "4":
                    AddCourseCompletion();
                    break;
                case "5":
                    CommitAllTransactions();
                    break;
                case "6":
                    HandleUncommittedTransactions();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Virheellinen valinta. Yritä uudelleen.");
                    break;
            }
        }

        Console.WriteLine("Paina mitä tahansa näppäintä lopettaaksesi...");
        Console.ReadKey();
    }


    /// <summary>
    /// Adds a student to the database.
    /// </summary>
    private static void AddStudent()
    {
        const string queryString = "INSERT INTO students (first_name, last_name, location) VALUES (@firstName, @lastName, @location); SELECT LAST_INSERT_ID();";
        
        Console.WriteLine("Syötä opiskelijan etunimi:");
        string? firstName = Console.ReadLine();

        Console.WriteLine("Syötä opiskelijan sukunimi:");
        string? lastName = Console.ReadLine();

        Console.WriteLine("Syötä opiskelijan sijainti:");
        string? location = Console.ReadLine();

        List<MySqlParameter> parameters = new()
        {
            new MySqlParameter("@firstName", firstName),
            new MySqlParameter("@lastName", lastName),
            new MySqlParameter("@location", location)
        };

        Transaction transaction = new(queryString, parameters);
        TransactionQueue.Enqueue(transaction);

        Console.WriteLine("Opiskelija lisätty jonoon. Muutokset tietokantaan tehdään ohjelman lopussa.");
    }


    /// <summary>
    /// Prints information about a student and their grades.
    /// </summary>
    private static void SearchStudent()
    {
        const string studentsQueryString = "SELECT * FROM students WHERE first_name = @firstName AND last_name = @lastName";
        const string gradesQueryString = "SELECT course.name, grades.grade, grades.completion_date, teachers.first_name, teachers.last_name FROM grades JOIN course ON grades.course_id = course.course_id JOIN teachers ON course.teacher = teachers.teacher_id WHERE grades.student_id = @studentId";
        
        Console.WriteLine("Syötä opiskelijan etunimi:");
        string? queryFirstName = Console.ReadLine();

        Console.WriteLine("Syötä opiskelijan sukunimi:");
        string? queryLastName = Console.ReadLine();

        using MySqlConnection connection = new(CONNECTION_STRING);
        connection.Open();

        using MySqlCommand studentCommand = new(studentsQueryString, connection);
        studentCommand.Parameters.AddWithValue("@firstName", queryFirstName);
        studentCommand.Parameters.AddWithValue("@lastName", queryLastName);

        // Execute the query to find the student
        using MySqlDataReader reader = studentCommand.ExecuteReader();
        if (reader.Read())
        {
            // Read the student's information
            object firstName = reader["first_name"];
            object lastName = reader["last_name"];
            object id = reader["id"];
            
            // Print the student's information
            Console.WriteLine("\n----------");
            Console.WriteLine("Opiskelijan tiedot:");
            Console.WriteLine($"Nimi: {firstName} {lastName}");
            Console.WriteLine($"ID: {id}");
            reader.Close();

            // Execute the query to find the student's grades
            using MySqlCommand gradesCommand = new(gradesQueryString, connection);
            gradesCommand.Parameters.AddWithValue("@studentId", id);

            // Read and print the student's grades
            using MySqlDataReader gradesReader = gradesCommand.ExecuteReader();
            Console.WriteLine("Kurssisuoritukset:");
            while (gradesReader.Read())
                Console.WriteLine(
                    $"\t{gradesReader["name"]} ({gradesReader["grade"]}/5) - {gradesReader["completion_date"]:yyyy-MM-dd} - {gradesReader["first_name"]} {gradesReader["last_name"]}");
        }
        else
            Console.WriteLine("Opiskelijaa ei löytynyt.");

        Console.WriteLine("----------\n");
    }


    /// <summary>
    /// Removes a student from the database.
    /// </summary>
    private static void DeleteStudent()
    {
        const string queryString = "DELETE FROM students WHERE id = @studentId";
        
        Console.WriteLine("Syötä poistettavan opiskelijan ID:");
        string? studentId = Console.ReadLine();
        
        List<MySqlParameter> parameters = new()
        {
            new MySqlParameter("@studentId", studentId)
        };

        Transaction transaction = new(queryString, parameters);
        TransactionQueue.Enqueue(transaction);

        Console.WriteLine("Opiskelija lisätty poistojonoon. Muutokset tietokantaan tehdään ohjelman lopussa.");
    }


    /// <summary>
    /// Adds a course completion to the database.
    /// </summary>
    private static void AddCourseCompletion()
    {
        const string queryString = "INSERT INTO grades (student_id, course_id, grade, completion_date) VALUES (@studentId, @courseId, @grade, @completionDate)";
        
        Console.WriteLine("Syötä opiskelijan ID:");
        string? studentId = Console.ReadLine();

        Console.WriteLine("Syötä kurssin koodi:");
        string? courseId = Console.ReadLine();

        Console.WriteLine("Syötä arvosana:");
        string? grade = Console.ReadLine();

        Console.WriteLine("Syötä suorituspäivämäärä (muodossa YYYY-MM-DD):");
        string? completionDate = Console.ReadLine();

        List<MySqlParameter> parameters = new()
        {
            new MySqlParameter("@studentId", studentId),
            new MySqlParameter("@courseId", courseId),
            new MySqlParameter("@grade", grade),
            new MySqlParameter("@completionDate", completionDate)
        };

        Transaction transaction = new(queryString, parameters);
        TransactionQueue.Enqueue(transaction);

        Console.WriteLine("Kurssisuoritus lisätty jonoon. Muutokset tietokantaan tehdään ohjelman lopussa.");
    }


    /// <summary>
    /// Prompts the user to save uncommitted transactions before exiting the program.
    /// </summary>
    private static void HandleUncommittedTransactions()
    {
        // Check if there are uncommitted transactions
        if (TransactionQueue.Count <= 0)
            return;

        // Prompt the user if they want to save the changes
        Console.WriteLine("\nHaluatko tallentaa muutokset ennen poistumista? (K/e)");
        bool shouldSave = Console.ReadLine()?.ToLower() != "e";

        if (!shouldSave)
            return;

        CommitAllTransactions();
        Console.WriteLine("Muutokset tallennettu.");
    }


    /// <summary>
    /// Commits all transactions in the <see cref="TransactionQueue"/>.
    /// </summary>
    private static void CommitAllTransactions()
    {
        using MySqlConnection connection = new(CONNECTION_STRING);
        connection.Open();

        while (TransactionQueue.Count > 0)
        {
            Transaction transactionToExecute = TransactionQueue.Dequeue();

            try
            {
                using MySqlCommand command = new(transactionToExecute.CommandText, connection);
                command.Parameters.AddRange(transactionToExecute.Parameters.ToArray());
                int rowsAffected = command.ExecuteNonQuery();

                Console.WriteLine($"Suoritettu transaktio: {transactionToExecute.CommandText}. Muutettu rivejä: {rowsAffected}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Virhe transaktiossa: {transactionToExecute.CommandText}. Virhe: {e.Message}");
            }
        }
    }
}