using System.Runtime.InteropServices.Marshalling;

public class SimpleGoal : AGoal
{
    private bool _complete;

    public SimpleGoal(string title, string desc, bool complete, int score) : base(title, desc)
    {
        _complete = complete;
        _score = score;
    }



    public override void Display()
    {
        string mark;
        if (_complete == true)
        {
            mark = "[x]";
        }
        else
        {
            mark = "[ ]";
        }
        Console.WriteLine($"{mark} {_title}: ({_desc})");

    }

    public override void Award()
    {
        //This award method needs to make it so that when a checklist goal is complete, that the program awards the user points and 
        //advanced the numberAwarded variable up one point. This needs to happen each time the checklist goal is done. s
        if (_complete != true)
        {
            int newScore;
            newScore = AGoal.GetCumulativeScore() + _score;
            AGoal.SetCumulativeScore(newScore);
            _complete = true;

        }


    }


    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"Simple Goal;{_title}, {_desc},{_score},{_complete},\n";

        return stringRepresentation;
    }


}