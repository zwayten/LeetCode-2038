using System;
using LeetCode_2038;
class Program
{

    public static bool AliceWon = false;
    public static bool BobWon = false;
    public static bool gop = true;

    static void Main() 
    {
        string colors = "AAABABB";
        WinnerOfGame(colors);
    }

    static void DisplayColors(string colors)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine(colors);
        Console.WriteLine("------------------------");
    }

    public static bool CheckNeighbors(int index, string colors)
    {
        if (colors[index] == colors[index - 1] && colors[index] == colors[index + 1]) {
            return true;
        }
        return false;
    }


    public static bool GameEnder(string colors)
    {
        string subStringA = "AAA";
        string subStringB = "BBB";

        int substrCountA = 0;
        int substrCountB = 0;
        return true;
    }

    public static void GameWinner(string colors)
    {
        string subStringA = "AAA";
        string subStringB = "BBB";

        AliceWon = colors.Contains(subStringA);
        BobWon = colors.Contains(subStringB);

        if(AliceWon && !BobWon || !AliceWon && BobWon) {
            gop = false;
        }

        
    }

    public static bool WinnerOfGame(string colors)
    {
        //gop: refers to game on progress

        
        //let's affect even numbers for alice's turn and odd numbers for Bob's turn
        int turn = 0;
        int index;


        DisplayColors(colors);

        while (gop)
        {

            GameWinner(colors);
            if (turn % 2 == 0)
            {
                Console.WriteLine("Alice's turn : choose an A index to remove (A)");
                index = Int32.Parse(Console.ReadLine());

                if (index > colors.Length - 1)
                {
                    Console.WriteLine("Out of bounds retry");
                }

                if (index == 0 || index == colors.Length - 1)
                {
                    Console.WriteLine("Cannot remove from edges");
                }

                if (index > 0 && index < colors.Length - 1)
                {
                    if (colors[index] != 'B')
                    {
                        if(CheckNeighbors(index, colors))
                        {
                            colors = colors.Remove(index, 1);
                            DisplayColors(colors);

                            turn++;
                        }

                        if(!CheckNeighbors(index, colors))
                        {
                            Console.WriteLine($"There is no Neighbors of type A for the index chosen : {colors[index-1]}{colors[index]}{colors[index + 1]} ");
                        }
                        
                    }
                    if (colors[index] == 'B')
                    {
                        Console.WriteLine("Alic must choose a A to remove not B");
                    }

                    
                }
                
            }

            if (turn % 2 != 0)
            {
                Console.WriteLine("Bob's turn : choose an A index to remove (B)");
                index = Int32.Parse(Console.ReadLine());
                
                if(index > colors.Length - 1)
                {
                    Console.WriteLine("Out of bounds retry");
                }
                
                if (index == 0 || index == colors.Length - 1)
                {
                    Console.WriteLine("Cannot remove from edges");
                }

                if (index > 0 && index < colors.Length - 1)
                {
                    if (colors[index] != 'A')
                    {
                        if(CheckNeighbors(index, colors))
                        {
                            colors = colors.Remove(index, 1);
                            DisplayColors(colors);

                            turn++;
                        }
                        if (!CheckNeighbors(index, colors))
                        {
                            Console.WriteLine($"There is no Neighbors of type B for the index chosen : {colors[index - 1]}{colors[index]}{colors[index + 1]} ");
                        }

                    }
                    if (colors[index] == 'A')
                    {
                        Console.WriteLine("Bob must choose a B to remove not A");
                    }
                }

                }
        }

        if (AliceWon && !BobWon)
        {
            Console.WriteLine("Alice won ");
        }
        if(!AliceWon && BobWon)
        {
            Console.WriteLine("Bob won ");
        }
        return true;
    }

}