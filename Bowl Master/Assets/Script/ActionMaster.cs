using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

    //private int[] bowls = new int[21];
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
            bowlNumber += 2;
            return Action.EndTurn;
        }

        //Mid frame
        if (bowlNumber % 2 == 0)
        {
            bowlNumber++;
            return Action.Tidy;
        }
        else //End frame
        {
            bowlNumber++;
            return Action.EndTurn;
        }
        

        throw new UnityException("No action returned");
    }
}
