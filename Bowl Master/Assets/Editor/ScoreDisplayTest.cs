using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest{


    //[Test]
    //public void T01One()
    //{
    //    int[] rolls = { 1 };
    //    string rollString = "1";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T02Strike()
    //{
    //    int[] rolls = { 10 };
    //    string rollString = "X-";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T03StrikeThenOne()
    //{
    //    int[] rolls = { 10, 1 };
    //    string rollString = "X-1";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T04Spare()
    //{
    //    int[] rolls = { 8, 2 };
    //    string rollString = "8/";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T05SpareThenOne()
    //{
    //    int[] rolls = { 8, 2, 1 };
    //    string rollString = "8/1";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T06FullGameOf1s()
    //{
    //    IEnumerable<int> enumerable = from num in Enumerable.Range(0, 20) select 1;
    //    int[] rolls = enumerable.ToArray<int>();
    //    string rollString = "11111111111111111111";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T07FullStrikes()
    //{
    //    IEnumerable<int> enumerable = from num in Enumerable.Range(0, 12) select 10;
    //    int[] rolls = enumerable.ToArray<int>();
    //    string rollString = "X-X-X-X-X-X-X-X-X-XXX";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T08FullSpares()
    //{
    //    IEnumerable<int> enumerable = from num in Enumerable.Range(0, 20) select 5;
    //    int[] rolls = enumerable.ToArray<int>();
    //    string rollString = "5/5/5/5/5/5/5/5/5/5/";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T09NormalThenSpareStrike()
    //{
    //    IEnumerable<int> enumerable = from num in Enumerable.Range(0, 20) select 5;
    //    List<int> rollsList = enumerable.ToList<int>();
    //    rollsList.Add(10);
    //    int[] rolls = rollsList.ToArray();

    //    string rollString = "5/5/5/5/5/5/5/5/5/5/X";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T10NormalThenStrikeAnd6()
    //{
    //    IEnumerable<int> enumerable = from num in Enumerable.Range(0, 10) select 10;
    //    List<int> rollsList = enumerable.ToList<int>();
    //    rollsList.Add(6);
    //    int[] rolls = rollsList.ToArray();

    //    string rollString = "X-X-X-X-X-X-X-X-X-X6";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    //[Test]
    //public void T11ZeroFive()
    //{
    //    int[] rolls = { 0, 5 };
    //    string rollString = "-5";
    //    Assert.AreEqual(rollString, ScoreDisplay.FormatRolls(rolls.ToList()));
    //}

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string rollsString = "1";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02BowlX()
    {
        int[] rolls = { 10 };
        string rollsString = "X "; // Remember the space
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T03Bowl19()
    {
        int[] rolls = { 1, 9 };
        string rollsString = "1/"; // Remember the space
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04BowlStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1 };
        string rollsString = "111111111111111111X11"; // Remember the space
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T05Bowl0()
    {
        int[] rolls = { 0 };
        string rollsString = "-"; // Remember the space
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T06Bowl0ThenSpare()
    {
        int[] rolls = { 0, 10 };
        string rollsString = "-/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }




    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG01GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        string rollsString = "X 9/9/9/9/7-9-X 8/8/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG02GoldenCopyB2of3()
    {
        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
        string rollsString = "8/819/718/9/9/X X 71";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        string rollsString = "X X 9-X 7/X 8163629/X";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG04GoldenCopyC1of3()
    {
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        string rollsString = "72X X X X 7/X X 9/XX9";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG05GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        string rollsString = "X X X X 9-X X X X X9/";
        Assert.AreEqual(rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
}
