using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    public static List<int> GetScoreFrames(List<int> rolls)
    {
        var scoreFrames = new List<int>();

        return scoreFrames;
    }

    public static List<int> GetScoreCumulative(List<int> rolls)
    {
        var scoreCumulative = new List<int>();

        var sum = 0;
        var scoreFrames = GetScoreFrames(rolls);

        foreach (var scoreFrame in scoreFrames)
        {
            sum += scoreFrame;
            scoreCumulative.Add(sum);
        }

        return scoreCumulative;
    }
	

}
