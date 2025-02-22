using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Quic;

public class ChecklistGoal : AGoal
{
    private bool _complete;
    private int _bonusThreshold; //Number of times activity needs to be completed before bonus
    private int _bonusScore;
    private int _numberAwarded; //Number of times out of _bonusThreshold

    public ChecklistGoal(string title, string desc, int score, int bonusScore, int bonusThreshold, int numberAwarded) : base(title, desc)
    {
        _score = score;
        _bonusScore = bonusScore;
        _bonusThreshold = bonusThreshold;
        if (bonusThreshold > numberAwarded)
        {
            _complete = false;
        } else {
            _complete = true;
        }

        _numberAwarded = numberAwarded;
    }

    public override void Award()
    {
        //This award method needs to make it so that when a checklist goal is complete, that the program awards the user points and 
        //advanced the numberAwarded variable up one point. This needs to happen each time the checklist goal is done. s
        int newScore;

        _complete = false;
        _numberAwarded++;
        if (_numberAwarded >= _bonusThreshold)
        {
            _complete = true;
            if (_numberAwarded == _bonusThreshold)
            {
                newScore = AGoal.GetCumulativeScore() + _bonusScore;
                AGoal.SetCumulativeScore(newScore);
            }
        }
        newScore = AGoal.GetCumulativeScore() + _score;
        AGoal.SetCumulativeScore(newScore);


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
        Console.WriteLine($"{mark} {_title}: ({_desc}) Completed {_numberAwarded}/{_bonusThreshold}");

    }

    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"Checklist Goal;{_title},{_desc},{_score},{_bonusScore},{_bonusThreshold},{_numberAwarded},{_complete},\n";

        return stringRepresentation;
    }
}