namespace ObjectOrientedProgramming.Assignments._7;

/// <summary>
/// Tehtävänäsi on toteuttaa luokkarakenne jolla testataan abstraktien metodien toimivuutta.
///
/// Luo seuraavat luokat DrawObject, Triangle ja Box.
/// DrawObject on Triangle ja Box luokkien kantaluokka.
/// Määritä DrawObject luokkaan draw niminen abstrakti metodi jonka toteutat alla olevalla tavalla periviin luokkiin.
///
/// Pääohjelmassa luo sekä Trianglesta, että Box:sta olio ja kutsu olioiden draw metodia. 
/// </summary>
public class Assignment2 : ISchoolAssignment
{
    private abstract class DrawableObject
    {
        public abstract void Draw();
    }


    private class Triangle : DrawableObject
    {
        public override void Draw()
        {
            int starCount = 1;
            int spaceCount = 6;
            // Draw an ascii-triangle
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine(new string(' ', spaceCount) + new string('*', starCount));
                starCount += 2;
                spaceCount--;
            }
        }
    }


    private class Box : DrawableObject
    {
        private const string END_LINE       = "* * * * * * * *";
        private const string MIDDLE_LINE    = "*             *";
        
        public override void Draw()
        {
            // Draw an ascii-box
            Console.WriteLine(END_LINE);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(MIDDLE_LINE);
            }
            Console.WriteLine(END_LINE);
        }
    }
    
    
    public void Run(string[] args)
    {
        DrawableObject triangle = new Triangle();
        DrawableObject box = new Box();
        
        Console.WriteLine("Triangle -luokan Draw() -metodi:");
        triangle.Draw();
        Console.WriteLine();
        Console.WriteLine("Box -luokan Draw() -metodi:");
        box.Draw();
    }
}