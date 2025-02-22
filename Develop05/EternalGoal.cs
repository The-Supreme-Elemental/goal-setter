public class EternalGoal : AGoal
{
    private long _numberAwarded;

    public EternalGoal(string title, string desc, long numberAwarded, int score) : base(title, desc)
    {
        _numberAwarded = numberAwarded;
        _score = score;
    }


    public override void Award()
    {
        //This award method needs to make it so that when a checklist goal is complete, that the program awards the user points and 
        //advanced the numberAwarded variable up one point. This needs to happen each time the checklist goal is done. s
        int newScore;


        _numberAwarded++;
        newScore = AGoal.GetCumulativeScore() + _score;
        AGoal.SetCumulativeScore(newScore);


    }

    public override void Display()
    {
        string mark = "[ ]";
        Console.WriteLine($"{mark} {_title}: ({_desc})");

    }

    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"Eternal Goal;{_title},{_desc},{_score},{_numberAwarded},\n";

        return stringRepresentation;
    }
}

