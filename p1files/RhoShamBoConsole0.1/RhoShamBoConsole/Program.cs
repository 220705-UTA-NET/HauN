using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        List<string> NamedList = new List<string>();
        Random rnd = new Random();
        int FightingPlayers;
        int originalNumberOfPlayers = 0;

        while (numberOfPlayers < 2)
        {
            var x = "";
            Console.WriteLine("WELCOME TO THE TOURNAMENT OF RHO SHAM BO");
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
             originalNumberOfPlayers = numberOfPlayers;
        }
        for (int i = 1; i <= numberOfPlayers; i++)
        {
            Console.WriteLine("Input the name of player" + i + ": ");
            string? name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty! Input your name once more");
                name = Console.ReadLine();
            }
            NamedList.Add(name);
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
                //Console.WriteLine("Player" + currentRoundList[byePlayer] + " has a bye, moving onto next round");
                  Console.WriteLine("Player " + currentRoundList[byePlayer] + ", " + NamedList[ currentRoundList[byePlayer] -1] + ", has a bye, moving onto next round");
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
                Console.WriteLine("Player" + winner + ", " + NamedList[winner-1] + " wins the match!");
            }

            Console.WriteLine("The following players are moving onto the next round:");
            foreach (var p in nextRoundList)
            {
                Console.WriteLine("Player" + p + ", " +NamedList[p-1]);
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

        //Console.WriteLine("The winner is player " + currentRoundList[0]);
        Console.WriteLine("The winner is player " + currentRoundList[0] + ", " + NamedList[currentRoundList[0]-1]);



        //your connection string 
        string connString = File.ReadAllText("C:/Users/Hau/source/repos/ConnectionStrings/FirstRevatureDB.txt");

        //create instanace of database connection
        SqlConnection conn = new SqlConnection(connString);
        try
        {
           // Console.WriteLine("Openning Connection ...");

            //open connection
            conn.Open();

          //  Console.WriteLine("Connection successful!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        string sqlQuery = "INSERT INTO RhoShamBo.Tourney (PlayerCount, Winner) VALUES (" +  originalNumberOfPlayers.ToString() + ", '" + NamedList[currentRoundList[0]-1].ToString() + "')" ;

        using (SqlCommand command = new SqlCommand(sqlQuery, conn)) //pass SQL query created above and connection
        {
            try
            {
                command.ExecuteNonQuery(); //execute the Query
                Console.WriteLine("Database Updated");
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }

    public static int Fight(int a, int b)
    {
        int count = 0;
        Console.WriteLine("Get ready to Rho Sham Bo, player " + a + " and player " + b + "!!!");
        while (Math.Abs(count) < 2)
        {
            var choice1 = "";
            while (choice1 == "")
            {
                Console.WriteLine("Player " + a + ", please select: 1. Rock      2. Paper      3. Scissor");
                choice1 = Console.ReadLine();
                if (choice1 != "1" && choice1 != "2" && choice1 != "3")
                {
                    Console.WriteLine("Invalid choice");
                    choice1 = "";
                }
            }

            var choice2 = "";

            while (choice2 == "")
            {
                Console.WriteLine("Player " + b + ", please select: 1. Rock      2. Paper      3. Scissor");
                choice2 = Console.ReadLine();
                if (choice2 != "1" && choice2 != "2" && choice2 != "3")
                {
                    Console.WriteLine("Invalid choice");
                    choice2 = "";
                }
            }

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
            return 1;
        }

        else return -1;

    }


}