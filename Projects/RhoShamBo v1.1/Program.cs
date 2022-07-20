using System;
using System.Collections.Generic;

// Step 1: Get Number of Players
// Step 2: Generate the player list
// Step 3: Pairing, Bye system.
// Step 4: Single-round gameplay
//         Create Method Fight(int a, int b)
//         Finding out that this isn't enough, creating another method Decision to decide the result of the fight, with prompted inputs from user. 
public class Program

{
    static void Main(string[] args)
    {
        int numberOfPlayers = -1;
        int byePlayer;
        List<int> currentRoundList = new List<int>();
        List<int> nextRoundList = new List<int>();
        Random rnd = new Random();
        int FightingPlayers;
        Console.WriteLine("WELCOME TO THE TOURNAMENT OF RHO SHAM BO");

        while (numberOfPlayers < 2)
        {
            var x = "";
            Console.WriteLine("Enter the number of players:"); //1. Asking for the number of players.
            x = Console.ReadLine();
            if (x == null) return;
            try
            {
                numberOfPlayers = Int32.Parse(x);
                //Console.WriteLine(numberOfPlayers);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid number of players");
            }
        }

        for (int i = 1; i <= numberOfPlayers; i++)
        {
            currentRoundList.Add(i); //this generates a list from 1 to numberOfPlayers to use for pairing.
        }

        while (currentRoundList.Count >= 2)
        {
            if (currentRoundList.Count % 2 == 1)
            {
                byePlayer = rnd.Next(0, currentRoundList.Count - 1);
                Console.WriteLine("Player" + currentRoundList[byePlayer] + " has a bye, moving onto next round");
                nextRoundList.Add(currentRoundList[byePlayer]);
                currentRoundList.RemoveAt(byePlayer);
            }


            FightingPlayers = currentRoundList.Count - currentRoundList.Count % 2;

            //add the bye player to the next round    
            // How the f do you pair?
            // Pair, then fight.

            for (int i = 0; i < FightingPlayers / 2; i++)
            {
                int playerA = currentRoundList[i];
                int playerB = currentRoundList[i + FightingPlayers / 2];
                int winner = Fight(playerA, playerB);
                nextRoundList.Add(winner);
                Console.WriteLine("Player" + winner + " wins the match!");
            }

            Console.WriteLine("The following players are moving onto the next round:");
            foreach (var p in nextRoundList)
            {
                Console.WriteLine("Player" + p);
            }

            //
            //Step 4: Single-round gameplay
            //Create Method Fight(int a, int b)



            //Step 5: Loop through until there is 1 player left in the list.
            //Game ends when currentRoundList.Count = 1
            //Declare that Round 1 is over and moving onto round 2.

            currentRoundList = nextRoundList;
            nextRoundList = new List<int>();

        }//END OF MAIN WHILE LOOP

        Console.WriteLine("THE WINNER OF RHO SHAM BO IS PLAYER" + currentRoundList[0]);
    }

    public static int Fight(int a, int b)
    {
        int count = 0;
        Console.WriteLine("Get ready to Rho Sham Bo, player " + a + " and player " + b + "!!!");
        while (Math.Abs(count) < 2)
        {
            // var choice1 = "";
            // while (choice1 == "")
            // {
            //     Console.WriteLine("Player " + a + ", please select: 1. Rock      2. Paper      3. Scissor");
            //     choice1 = Console.ReadLine();
            //     if (choice1 != "1" && choice1 != "2" && choice1 != "3")
            //     {
            //         Console.WriteLine("Invalid choice");
            //         choice1 = "";
            //     }
            // }

            System.Console.WriteLine("Player " + a + ", please select: 1. Rock      2. Paper      3. Scissor ");
            string? choice1 = "";
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                choice1 += key.KeyChar;
                if (choice1 != "1" && choice1 != "2" && choice1 != "3")
                {
                    Console.WriteLine("Invalid choice");
                    choice1 = "";
                }
            }
            // Console.WriteLine("choice1 = " + choice1);

            // var choice2 = "";

            // while (choice2 == "")
            // {
            //     Console.WriteLine("Player " + b + ", please select: 1. Rock      2. Paper      3. Scissor");
            //     choice2 = Console.ReadLine();
            //     if (choice2 != "1" && choice2 != "2" && choice2 != "3")
            //     {
            //         Console.WriteLine("Invalid choice");
            //         choice2 = "";
            //     }
            // }
            System.Console.WriteLine("Player " + b + ", please select: 1. Rock      2. Paper      3. Scissor ");
            string? choice2 = "";
            while (true)
            {
                var key1 = System.Console.ReadKey(true);
                if (key1.Key == ConsoleKey.Enter)
                    break;
                choice2 += key1.KeyChar;
                if (choice2 != "1" && choice2 != "2" && choice2 != "3")
                {
                    Console.WriteLine("Invalid choice");
                    choice2 = "";
                }
            }
            //Console.WriteLine("choice2 = " + choice2);

            count += Decision(choice1, choice2);
        }

        if (count == 2) return a;
        else return b;

    }

    public static int Decision(string choice1, string choice2)
    {
        if (choice1 == choice2)
        {
            Console.WriteLine("It's a draw!");
            return 0;
        }
        if ((choice1 == "1" && choice2 == "3") || (choice1 == "2" && choice2 == "1") || (choice1 == "3" && choice2 == "2"))
        {
            Console.WriteLine("The first player wins this round");
            return 1;
        }

        else
        {
            Console.WriteLine("The second player wins this round");
            return -1;
        }

    }


}