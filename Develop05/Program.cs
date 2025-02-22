using System;
using System.Data.Common;

class Program
{
    static void Main(string[] args)
    {

        List<AGoal> aGoals = new List<AGoal>();
        // ChecklistGoal checklistGoal = new ChecklistGoal("quote", "Temple quote", 10, 50, 3);

        AGoal.GetCumulativeScore();
        string userInput = "";

        // Console.WriteLine("Menu Options:");
        // Console.WriteLine("1. Create New Goal\n2.List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
        // string userInput = Console.ReadLine();
        while (userInput != "6")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine("The types of goals are: \n1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                string userInput2 = Console.ReadLine();
                if (userInput2 == "1" || userInput2 == "2" || userInput2 == "3")
                {
                    Console.Write("What is the name of your goal? ");
                    string title = Console.ReadLine();

                    Console.Write("What is a short description of your goal? ");
                    string desc = Console.ReadLine();

                    Console.Write("What is the number of points associated with your goal? ");
                    int score = int.Parse(Console.ReadLine());

                    if (userInput2 == "1")
                    {
                        SimpleGoal simpleGoal = new SimpleGoal(title, desc, false, score);
                        aGoals.Add(simpleGoal);
                    }
                    else if (userInput2 == "2")
                    {
                        EternalGoal eternalGoal = new EternalGoal(title, desc, 0, score);
                        aGoals.Add(eternalGoal);
                    }
                    else if (userInput2 == "3")
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int bonusThreshold = int.Parse(Console.ReadLine());

                        Console.Write("What is the bonus for completing it that many times? ");
                        int bonusScore = int.Parse(Console.ReadLine());
                        ChecklistGoal checklistGoal = new ChecklistGoal(title, desc, score, bonusScore, bonusThreshold, 0);
                        aGoals.Add(checklistGoal);
                    }
                }

            }

            if (userInput == "2")
            {
                Console.WriteLine($"You have earned {AGoal.GetCumulativeScore()} point(s) so far. Nice job!");

                foreach (AGoal aGoal in aGoals)
                {
                    aGoal.Display();
                }
            }
            if (userInput == "3")
            {
                Console.WriteLine("What is the filename of the goal file?");
                string fileName = Console.ReadLine();
                using (StreamWriter outputFile = new StreamWriter(fileName))
                {
                    outputFile.WriteLine($"{AGoal.GetCumulativeScore()}");
                    foreach (AGoal aGoal in aGoals)
                    {
                        string s = aGoal.GetStringRepresentation();
                        outputFile.Write($"{aGoal.GetStringRepresentation()}");

                    }
                }
            }

            if (userInput == "4")
            {
                aGoals = new List<AGoal>();

                Console.WriteLine("What file name would you like to load?");
                string fileName = Console.ReadLine();

                string[] lines = System.IO.File.ReadAllLines(fileName);

                bool firstFlag = true;
                foreach (string line in lines)
                {
                    if (firstFlag)
                    {
                        AGoal.SetCumulativeScore(int.Parse(line));
                        firstFlag = false;
                        continue;
                    }
                    string[] typeParts = line.Split(";");
                    string[] parts = typeParts[1].Split(",");
                    if (typeParts[0] == "Simple Goal")
                    {
                        string title = parts[0];
                        string description = parts[1];
                        string score = parts[2];
                        string complete = parts[3];

                        bool completeBool;
                        if (complete == "true")
                        {
                            completeBool = true;
                        }
                        else
                        {
                            completeBool = false;
                        }
                        int scoreInt = int.Parse(score);


                        AGoal aGoal = new SimpleGoal(title, description, completeBool, scoreInt);
                        aGoals.Add(aGoal);
                    }
                    if (typeParts[0] == "Eternal Goal")
                    {
                        string title = parts[0];
                        string description = parts[1];
                        string score = parts[2];
                        string numberAwarded = parts[3];

                        int scoreInt = int.Parse(score);
                        int numberAwardedInt = int.Parse(numberAwarded);

                        AGoal aGoal = new EternalGoal(title, description, numberAwardedInt, scoreInt);
                        aGoals.Add(aGoal);
                    }
                    if (typeParts[0] == "Checklist Goal")
                    {
                        string title = parts[0];
                        string description = parts[1];
                        string score = parts[2];
                        string bonusScore = parts[3];
                        string bonusThreshold = parts[4];
                        string numberAwarded = parts[5];
                        string complete = parts[6];

                        int scoreInt = int.Parse(score);
                        int bonusScoreInt = int.Parse(bonusScore);
                        int bonusThresholdInt = int.Parse(bonusThreshold);
                        int numberAwardedInt = int.Parse(numberAwarded);




                        AGoal aGoal = new ChecklistGoal(title, description, scoreInt, bonusScoreInt, bonusThresholdInt, numberAwardedInt);
                        aGoals.Add(aGoal);
                    }

                }
            }
            if (userInput == "5")
            {
                int counter = 0;
                foreach (AGoal aGoal in aGoals)
                {
                    counter++;
                    Console.Write($"{counter};");
                    aGoal.Display();
                }

                Console.Write("What goal do you want? ");
                int goalnumber = int.Parse(Console.ReadLine());
                aGoals[goalnumber - 1].Award();
            }

            // checklistGoal.Award();
            // checklistGoal.Display();
            // Console.WriteLine(AGoal.GetCumulativeScore());
        }




    }
}