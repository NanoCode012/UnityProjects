using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{

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
	
    public static List<int> GetScoreFrames(List<int> rolls)
    {
        var scoreFrames = new List<int>();
        int length = rolls.Count;

        for (var i = 0; i < length; i+=2)
        {
            if (rolls[i] == 10) 
            {
                if (i < length - 2)
                {
                    scoreFrames.Add(rolls[i] + rolls[i + 1] + rolls[i + 2]);
                    i--;
                }
            }
            else if (i < length - 1 && scoreFrames.Count <= 9)
            {
                int sum = rolls[i] + rolls[i + 1];
                if (sum == 10)
                {
                    if (i < length - 2) scoreFrames.Add(sum += rolls[i + 2]);
                }
                else scoreFrames.Add(sum);
            }
        }

        return scoreFrames;
    }

}
