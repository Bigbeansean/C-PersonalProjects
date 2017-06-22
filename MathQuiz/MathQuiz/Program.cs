using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz
{
    class Program
    {
        static int score;
        static int highScoreInt;
        static string finalScore;
        static string highScore;
        static string[] victoryWords = new string[] { "Ride On", "Go Hard", "wahiio", "ahh woowoo", "YES", "oh YES", "Woo" };
        static int victoryWord;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            while(Addition() == true)
            {
                victoryWord = rnd.Next(0, victoryWords.Length);
                Console.WriteLine(victoryWords[victoryWord]);
                Console.WriteLine("");
                score += 1;
            }
            highScore = File.ReadAllText(@"highscore.txt");
            highScoreInt = int.Parse(highScore);

            if (score > highScoreInt)
            {
                finalScore = score.ToString();

                // Write the string to a file.
                StreamWriter file = new StreamWriter("highscore.txt");
                file.WriteLine(finalScore);

                file.Close();
            }
           
            // Compose a string that consists of three lines.
            //string lines = "First line.\r\nSecond line.\r\nThird line.";         

            Console.WriteLine("You Lose:");
            Console.WriteLine("Final Score: {0}", score);

            highScore = File.ReadAllText(@"highscore.txt");
            Console.WriteLine("The Highscore is : {0}", highScore);

            Console.ReadLine();
        }

        static bool Addition()
        {
            int left = rnd.Next(1, 9);
            int right = rnd.Next(1, 9);

            Console.WriteLine(left + " * " + right);
            int answer = left * right;

            string userAnswerString = Console.ReadLine();
            int userAnswerInt = int.Parse(userAnswerString);

            if (userAnswerInt == answer)
                return true;
            else
                return false;
        }
    }
}
