using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Investec_Candidate_Assessment
{
    class Program
    {
        public class Globals
        {
            public static string userSentence;
            public static int sentenceLenght;
            public static string duplicate;
            public static string vowels;
            public static int numNonVowels;
            public static int numVowels;
            public static string userSelection;
            public static int Q1;
            public static int Q2;
            public static int Q3;
        }

        static void Main(string[] args)
        {
            //Get input from user and store in variables
            Console.WriteLine("Enter text to be analysed");
            Globals.userSentence = Console.ReadLine().ToLower();
            Globals.sentenceLenght = Globals.userSentence.Length;
            Globals.duplicate = "";
            Globals.vowels = "";
            Globals.numVowels = 0;
            Console.WriteLine("Enter which operations to do on the supplied text, ‘1’ for a duplicate character check, ‘2’ to count the number of vowels, ‘3’ to check if there are more vowels or non vowels, or any combination of ‘1’, ‘2’ and ‘3’ to perform multiple checks.");
            Globals.userSelection = Console.ReadLine();



            //if statement to validate user input
            if (Globals.userSelection == "1")
            {
                myQuestion1();
            }

            if (Globals.userSelection == "2")
            {
                myQuestion2();
            }

            if (Globals.userSelection == "3")
            {
                myQuestion3();
            }

            if (Globals.userSelection == "12" || Globals.userSelection == "21")
            {
                myQuestion1();
                myQuestion2();
            }

            if (Globals.userSelection == "23" || Globals.userSelection == "32")
            {
                myQuestion2();
                myQuestion3();
            }

            if (Globals.userSelection == "13" || Globals.userSelection == "13")
            {
                myQuestion1();
                myQuestion3();
            }

            if (Globals.userSelection == "123" || Globals.userSelection == "321" || Globals.userSelection == "132" || Globals.userSelection == "231" || Globals.userSelection == "213")
            {
                myQuestion1();
                myQuestion2();
                myQuestion3();
            }



        }



        public static void myQuestion1()
        {
            //for statment to compare letters in the sentence
            for (int i = 0; i < Globals.sentenceLenght; i++)
            {
                for (int j = i + 1; j <= Globals.sentenceLenght - 1; j++)
                {
                    if (Globals.userSentence[i] == Globals.userSentence[j])
                    {
                        Globals.duplicate = Globals.duplicate + Globals.userSentence[i];
                        Globals.Q1++;
                    }
                }
            }

            //remove duplicates and white spaces from string
            string trimString = "";
            var uniqueQ1 = new HashSet<char>(Globals.duplicate);
            foreach (char c in uniqueQ1)
                trimString = trimString + c;
            trimString = trimString.Replace(" ", String.Empty);
            Console.WriteLine(trimString);


            //check if there are no duplicates
            if (Globals.duplicate == "")
            {
                Console.WriteLine("No duplicates were found");
            }
        }

        public static void myQuestion2()
        {
            //for statment to search for vowels
            for (int i = 0; i < Globals.sentenceLenght; i++)
            {
                if (Globals.userSentence[i] == 'a' || Globals.userSentence[i] == 'e' || Globals.userSentence[i] == 'i' || Globals.userSentence[i] == 'o' || Globals.userSentence[i] == 'u')
                {
                    Globals.vowels = Globals.vowels + Globals.userSentence[i];
                }
            }

            //remove duplicate vowels
            var uniqueQ2 = new HashSet<char>(Globals.vowels);
            foreach (char c in uniqueQ2)
                Globals.numVowels++;
            if (Globals.numVowels > 1)
            {
                Console.WriteLine("The number of unique vowels is " + Convert.ToString(Globals.numVowels));
            }
            else
            {
                Console.WriteLine("No vowels were found");
            }
        }

        public static void myQuestion3()
        {
            Globals.numVowels = 0;
            Globals.numNonVowels = 0;
            //remove white spaces
            string trimSentence = Globals.userSentence.Replace(" ", String.Empty);
            //for statement to count vowels
            for (int i = 0; i < trimSentence.Length; i++)
            {
                if (Globals.userSentence[i] == 'a' || Globals.userSentence[i] == 'e' || Globals.userSentence[i] == 'i' || Globals.userSentence[i] == 'o' || Globals.userSentence[i] == 'u')
                {
                    Globals.vowels = Globals.vowels + Globals.userSentence[i];
                    Globals.numVowels++;
                }
                else
                {
                    Globals.numNonVowels++;
                }
            }

            //if statment to check if vowels are more/less than non vowels


            if (Globals.numVowels > Globals.numNonVowels)
            {
                Console.WriteLine("The text has more vowels than non vowels");
            }
            if (Globals.numVowels < Globals.numNonVowels)
            {
                Console.WriteLine("the text has more non vowals than vowels");
            }
            if (Globals.numVowels == Globals.numNonVowels)
            {
                Console.WriteLine("The text has an equal amount of vowels and non vowels");
            }


        }
    }
}


