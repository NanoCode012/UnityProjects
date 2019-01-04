using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private readonly ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private readonly ActionMaster.Action reset = ActionMaster.Action.Reset;
    private readonly ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private readonly ActionMaster.Action endGame = ActionMaster.Action.EndGame;

    private ActionMaster actionMaster;

    [SetUp]
    public void SetUp()
    {
        actionMaster = new ActionMaster();
    }

    /*Name convention: T##(METHOD_NAME)_(CONDITION)_(RETURN)*/
    [Test]
    public void T01Bowl_OneStrike_EndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl_Bowl8_Tidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03Bowl_Bowl15_Error()
    {
        try
        {
            actionMaster.Bowl(15);
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
        actionMaster.Bowl(2);
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }

    [Test]
    public void T05Bowl_BowlTillOneToLastFrameButNoSpareOrStrike_EndGame()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T06Bowl_BowlTillOneToLastFrameAndGetSpare_Reset()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(8));
    }

    [Test]
    public void T07Bowl_BowlTillTwoToLastFrameAndGetStrike_Reset()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T08Bowl_BowlTillOneToLastFrameAndGetStrike_Reset()
    {
        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T09Bowl_BowlTillTwoToLastFrameGetStrikeThenGetSpareOrNormalBowl_ResetTidyEndGame()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T10Bowl_Bowl10OnSecondGetSpare_EndTurn()
    {
        actionMaster.Bowl(0);
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T11Bowl_BowlMoreThan10ForSumOfTwoFrames_Error()
    {
        actionMaster.Bowl(8);
        try
        {
            actionMaster.Bowl(8);
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
            actionMaster.Bowl(2);
        }

        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        actionMaster.Bowl(10);

        try
        {
            actionMaster.Bowl(2);
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
            actionMaster.Bowl(2);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(reset, actionMaster.Bowl(10));
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }
}