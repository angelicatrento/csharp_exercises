using System;

namespace GuessTheNumber
{
    class Guess
    {
        /*
            simulate the roll of 2 6-sided dice
            prompt the players for a whole number between 2 and 12.
            do the proper input validation
            clear the console
            display the result of the 2 dice
            display the total result
            display the bet
            display the final result (you win/lose) 
        */
        const int MinBet = 2;
        const int MaxBet = 12;
        const int MinDieBoundaries = 1;
        const int MaxDieBoundaries = 7;

        static void Main(string[] args)
        {
            Console.Title = "Guess the number";
            Random randomNumber = new Random();
            
            // Get random number - simulate a die of 6 faces
            int bet;
            int firstDie; 
            int secondDie;
            string betInput;
            bool wannaContinue = true;

            while(wannaContinue)
            {
                //initialize random variables
                firstDie = randomNumber.Next(MinDieBoundaries, MaxDieBoundaries); 
                secondDie = randomNumber.Next(MinDieBoundaries, MaxDieBoundaries);

                
                do
                {
                    // Prompt user for bet
                    Console.WriteLine("Please place a bet from {0} to {1} inclusive", MinBet, MaxBet);

                    betInput = Console.ReadLine();

                    // invalid bet
                    if (!int.TryParse(betInput, out bet))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("That's not an integer number!\n", MinBet, MaxBet);
                    }
                    else if (bet < MinBet || bet > MaxBet)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Number is out of range\n");
                        bet = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                while (bet == 0);

                //VALID BET
                Console.Clear();
                Console.WriteLine("Dice values: {0} and {1}", firstDie, secondDie);
                Console.WriteLine("Total: {0}", firstDie + secondDie);
                Console.WriteLine("Your Bet: {0}", bet);
                Console.WriteLine("You {0}", bet == (firstDie + secondDie) ? "WIN " : "LOSE");

                Console.WriteLine("Would you like to play again? (Y|N)");
                betInput = Console.ReadLine().ToUpper();
                // wannaContinue? wannaContinue = true : wannaContinue = false;
                //(betInput != "Y") ? betInput = "bla" : betInput = "bla";

                if(betInput.ToUpper() != "Y")
                {
                    Console.WriteLine("\nAlright then. See you later");
                    wannaContinue = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Cool! Let's play again\n");
                }

            }

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey(); 
        }
    }
}
