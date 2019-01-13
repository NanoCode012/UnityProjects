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
        var length = rolls.Count;

        for (var i = 0; i < length - 1 && scoreFrames.Count <= 9; i+=2)//Need next roll value available and limit scoreFrames' count to 10
        {
            var sum = rolls[i] + rolls[i + 1];
            if (sum >= 10)//Strike or spare then add the next roll value if available
            {
                if (i < length - 2) scoreFrames.Add(sum + rolls[i + 2]);
                if (rolls[i] == 10) i--; //Strike frame only has one roll
            }
            else scoreFrames.Add(sum);
        }

        return scoreFrames;
    }

}
