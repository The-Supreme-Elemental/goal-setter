using System.ComponentModel.DataAnnotations;
using System.Security;

public abstract class AGoal
{
    protected string _title;
    protected string _desc;
    protected int _score;
    private static int _cumulativeScore;


    public AGoal(string title, string desc)
    {
        _title = title;
        _desc = desc;
    }

    public static int GetCumulativeScore()
    {
        return _cumulativeScore;
    }

    public static void SetCumulativeScore(int cumulativeScore)
    {
        _cumulativeScore = cumulativeScore;
    }
    
    public abstract void Award();

    public abstract void Display();
    public abstract string GetStringRepresentation();

}