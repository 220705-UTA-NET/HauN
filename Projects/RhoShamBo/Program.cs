using System;
using System.Collections.Generic;
public class Program

{

    static void Main(string[] args)
    {
        // Step 1: Get Number of Players


        int numberOfPlayers = -1;
        int byePlayer;
        List<int> PlayerList = new List<int>();
        List<int> NextRoundList = new List<int>();
        Random rnd = new Random();
        int FightingPlayers;

        while (numberOfPlayers < 2)
        {
            Console.WriteLine("Enter the number of players:");
            string x = Console.ReadLine();
            try
            {
                numberOfPlayers = Int32.Parse(x);
                Console.WriteLine(numberOfPlayers);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Invalid number of players");
            }
        }

        //Step 2: Generate the player list

        for (int i = 1; i <= numberOfPlayers; i++)
        {
            PlayerList.Add(i);
        }
        //this generates a list from 1 to numberOfPlayers to use for pairing.

        //Step 3: Pairing, Bye system.
        //I want to do something here, what is it that I want to do? I want to now randomly take a member and add them to NextRoundList
        byePlayer = rnd.Next(1, numberOfPlayers+1);
        if (PlayerList.Count()%2 ==1)
        {
           NextRoundList.Add(byePlayer);
        }
        FightingPlayers = PlayerList.Count() - PlayerList.Count()%2;

        //add the bye player to the next round    
        // How the f do you pair?
        // Pair, then fight.
        // This is not correct, but just writing dirty code.

        for (int i = 0; i< FightingPlayers; i += 2)
        {
         NextRoundList.Add(Fight(PlayerList.ElementAt(i), PlayerList.ElementAt(i + (FightingPlayers/2))));
        }

        //
        //Step 4: Single-round gameplay
        //Create Method Fight(int a, int b)

    

        //Step 5: Loop through until there is 1 player left in the list.
        //Declare that Round 1 is over and moving onto round 2.


    }
       public static int Fight(int a, int b)
       {

        Console.WriteLine("Welcome to Rho Sham Bo, player " + a + " and player " + b);
        Console.WriteLine("Player " + a + ", please select:");
        
        return a;

       }



}