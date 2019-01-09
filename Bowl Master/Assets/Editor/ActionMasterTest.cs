using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private readonly ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private readonly ActionMaster.Action reset = ActionMaster.Action.Reset;
    private readonly ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private readonly ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    private List<int> pinFalls;

    [SetUp]
    public void SetUp()
    {
        pinFalls = new List<int>();
    }

    /*Name convention: T##(METHOD_NAME)_(CONDITION)_(RETURN)*/
    [Test]
    public void T01Bowl_OneStrike_EndTurn()
    {
        pinFalls.Add(10);

        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl_Bowl8_Tidy()
    {
        pinFalls.Add(8);

        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl_Bowl15_Error()
    {
        pinFalls.Add(15);
        
        try
        {
            ActionMaster.NextAction(pinFalls);
        }
        catch (UnityException)
        {
            Assert.Pass();
        }
        Assert.Fail("Test should error, but did not happen");
    }

    [Test]
    public void T04Bowl_BowlSpare_EndTurn()
    {
        pinFalls.AddRange(new int[] {2, 8});
        
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T05Bowl_BowlTillOneToLastFrameButNoSpareOrStrike_EndGame()
    {
        for (int i = 0; i < 20; i++)
        {
            pinFalls.Add(1);
        }

        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T06Bowl_BowlTillOneToLastFrameAndGetSpare_Reset()
    {
        for (int i = 0; i < 19; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(9);

        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T07Bowl_BowlTillTwoToLastFrameAndGetStrike_Reset()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);

        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T08Bowl_BowlTillOneToLastFrameAndGetStrike_Reset()
    {
        for (int i = 0; i < 19; i++)
        {
            pinFalls.Add(0);
        }
        pinFalls.Add(10);

        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T09Bowl_BowlTillTwoToLastFrameGetStrikeThenGetSpareOrNormalBowl_ResetTidyEndGame()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }

        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));

        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));

        pinFalls.Add(1);
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T10Bowl_Bowl10OnSecondGetSpare_EndTurn()
    {
        pinFalls = new List<int>(new int[] {0, 10});

        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T11Bowl_BowlMoreThan10ForSumOfTwoFrames_Error()
    {
        pinFalls = new List<int>(new int[] { 8, 8 });
        try
        {
            ActionMaster.NextAction(pinFalls);
        }
        catch (UnityException)
        {
            Assert.Pass();
        }
        Assert.Fail("Test should error, but did not happen");
    }

    [Test]
    public void T12Bowl_Bowl22Times_Error()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }

        pinFalls.AddRange(new int[] {10, 10, 10, 10});

        try
        {
            ActionMaster.NextAction(pinFalls);
        }
        catch (UnityException)
        {
            Assert.Pass();
        }
        Assert.Fail("Test should error, but did not happen");
    }

    [Test]
    public void T13Bowl_BowlTillTwoToLastFrameGetStrikeThenStrikeThenStrike_ResetResetEndGame()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(0);
        }

        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));

        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));

        pinFalls.Add(10);
        Assert.AreEqual(endGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T14Bowl_BowlNormalThen10_Error()
    {
        pinFalls = new List<int>(new int[] { 1, 10 });
        try
        {
            ActionMaster.NextAction(pinFalls);
        }
        catch (UnityException)
        {
            Assert.Pass();
        }
        Assert.Fail("Test should error, but did not happen");
    }

    [Test]
    public void T15Bowl_BowlTillTwoToLastFrameGetMoreThan0ThenGet10_Error()
    {
        for (int i = 0; i < 19; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);

        try
        {
            ActionMaster.NextAction(pinFalls);
        }
        catch (UnityException)
        {
            Assert.Pass();
        }
        Assert.Fail("Test should error, but did not happen");
    }
}