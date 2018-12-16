using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActionMasterTest
{
    private readonly ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private readonly ActionMaster.Action tidy = ActionMaster.Action.Tidy;

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
        catch(UnityException)
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
}