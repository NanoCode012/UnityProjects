using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    private readonly int[] bowls = new int[21];
    private int bowlNumber = 0;

    public enum Action
    {
        Null = 0,
        Tidy,
        Reset,
        EndTurn,
        EndGame
    };

    public Action Bowl(int pins)//todo change to private
    {
        if (pins < 0 || pins > 10) throw new UnityException("Invalid pins");

        if (bowlNumber > 20) throw new UnityException("BowlNumber higher than 20");

        bowls[bowlNumber] = pins;

        if (bowlNumber == 20)
        {
            bowlNumber++;
            return Action.EndGame;
        }

        if (pins == 10)
        {
            //Case: Reach till one/two to last frame and got strike
            if (bowlNumber == 18 || bowlNumber == 19)
            {
                if ((0 < bowls[18] && bowls[18] < 10) && (bowls[19] == 10)) throw new UnityException("Mid frame and end frame pins' count exceed 10");

                bowlNumber++;
                return Action.Reset;
            }
            
            //Case: Strike on mid frame
            if (bowlNumber % 2 == 0) bowlNumber += 2;
            //Case: Strike on end frame
            else
            {
                if (bowls[bowlNumber - 1] + bowls[bowlNumber] > 10) throw new UnityException("Mid frame and end frame pins' count exceed 10");

                bowlNumber++;
            }

            return Action.EndTurn;
        }

        if (bowlNumber == 19)//19th frame
        {
            bowlNumber++;
            //Case: Strike on two to last frame then normal bowl for 2 times
            if (bowls[18] == 10) return Action.Tidy;
            //Case: Reach till one to last frame but no spare or strike
            if (bowls[18] + bowls[19] < 10) return Action.EndGame;
            //Case: Reach till one to last frame and got spare
            if (bowls[18] + bowls[19] == 10) return Action.Reset;
        }

        //Mid frame
        if (bowlNumber % 2 == 0)
        {
            bowlNumber++;
            return Action.Tidy;
        }
        else
        {
            if (bowls[bowlNumber - 1] + bowls[bowlNumber] > 10) throw new UnityException("Mid frame and end frame pins' count exceed 10");

            //End frame
            bowlNumber++;
            return Action.EndTurn;
        }
    }

    public static Action NextAction(List<int> pinFalls)
    {
        var actionMaster = new ActionMaster();
        var length = pinFalls.Count;

        for (var i = 0; i < length - 1; i++)
        {
            actionMaster.Bowl(pinFalls[i]);
        }

        return actionMaster.Bowl(pinFalls[length - 1]);
    }
}
