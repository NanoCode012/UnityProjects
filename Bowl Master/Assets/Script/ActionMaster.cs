using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

    private readonly int[] bowls = new int[21];
    private int bowlNumber = 0;

    public enum Action
    {
        Tidy,
        Reset,
        EndTurn,
        EndGame
    };

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10) throw new UnityException("Invalid pins");

        if (pins == 10)
        {
            bowls[bowlNumber] = pins;

            //Case: Reach till one to last frame and got strike
            if (bowlNumber == 18 || bowlNumber == 19)
            {
                bowlNumber++;
                return Action.Reset;
            }

            bowlNumber += 2;
            return Action.EndTurn;
        }

        //Mid frame
        if (bowlNumber % 2 == 0)
        {
            bowls[bowlNumber] = pins;
            bowlNumber++;
            return Action.Tidy;
        }
        else if (bowlNumber % 2 != 0)//End frame
        {
            bowls[bowlNumber] = pins;
            bowlNumber++;

            if (bowlNumber == 20)
            {
                //Case: Reach till one to last frame but no spare or strike
                if (bowls[bowlNumber - 2] + pins < 10) return Action.EndGame;
                ////Case: Reach till one to last frame and got spare
                else if (bowls[bowlNumber - 2] + pins == 10) return Action.Reset;
            }

            return Action.EndTurn;
        }
        

        throw new UnityException("No action returned");
    }
}
