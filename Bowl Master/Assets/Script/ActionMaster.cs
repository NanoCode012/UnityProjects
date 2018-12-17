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

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10) throw new UnityException("Invalid pins");

        if (bowlNumber > 20) throw new UnityException("BowlNumber higher than 20");

        bowls[bowlNumber] = pins;

        Action retAction = Action.Null;//Set to  NULL. Will return this action

        if (bowlNumber >= 20)
        {
            bowlNumber++;
            retAction = Action.EndGame;
        }
        else if (pins == 10)
        {
            //Case: Reach till one/two to last frame and got strike
            if (bowlNumber == 18 || bowlNumber == 19)
            {
                bowlNumber++;
                retAction = Action.Reset;
            }
            else
            {
                //Case: Strike on mid frame
                if (bowlNumber % 2 == 0) bowlNumber += 2;
                //Case: Strike on end frame
                else bowlNumber++;

                retAction = Action.EndTurn;
            }
        }
        else
        {
            bowlNumber++;

            //Mid frame
            if (bowlNumber % 2 != 0) retAction = Action.Tidy;
            else //End frame
            {
                if (bowlNumber == 19 + 1)//19th frame + 1 from earlier
                {
                    //Case: Strike on two to last frame then normal bowl for 2 times
                    if (bowls[18] == 10) retAction = Action.Tidy;
                    //Case: Reach till one to last frame but no spare or strike
                    if (bowls[18] + pins < 10) retAction = Action.EndGame;
                    ////Case: Reach till one to last frame and got spare
                    if (bowls[18] + pins == 10) retAction = Action.Reset;
                }
                else
                {
                    if (bowls[bowlNumber - 2] + pins > 10) throw new UnityException("Mid frame and end frame pins' count exceed 10");

                    retAction = Action.EndTurn;
                }
            }
        }

        return retAction;
    }

    public int[] GetBowls() { return bowls; }
}
