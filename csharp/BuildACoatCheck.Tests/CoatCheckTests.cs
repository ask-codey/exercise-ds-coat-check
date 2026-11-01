using System.Diagnostics;
using BuildACoatCheck;

namespace BuildACoatCheck.Tests;

// The tests for your coat check. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.

[TestClass]
public class CoatCheckTests
{
    [TestMethod]
    public void GetFindsTheCoatPutUnderAName()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        Assert.AreEqual("green raincoat", room.Get("Maya"), "Not yet: Maya's coat is the green raincoat.");
        Assert.IsNull(room.Get("Leo"), "Not yet: nobody checked in as Leo, so Get gives null.");
    }

    [TestMethod]
    public void PuttingTheSameNameAgainReplacesTheCoat()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        room.Put("Maya", "red scarf");
        Assert.AreEqual("red scarf", room.Get("Maya"), "Not yet: Maya's second coat replaces her first.");
        Assert.AreEqual(1, room.Count, "Not yet: Maya is one name, so Count is 1.");
    }

    [TestMethod]
    public void CountGoesUpWithEachNewName()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        room.Put("Leo", "denim jacket");
        room.Put("Priya", "red scarf");
        Assert.AreEqual(3, room.Count, "Not yet: three names are three coats.");
    }

    [TestMethod]
    public void NamesThatShareAHookAreBothFound()
    {
        CoatCheck room = new CoatCheck();
        Assert.AreEqual(room.HookFor("Maya"), room.HookFor("Zoe"), "Maya and Zoe should share a hook: don't change HookFor.");
        room.Put("Maya", "green raincoat");
        room.Put("Zoe", "yellow umbrella");
        Assert.AreEqual("green raincoat", room.Get("Maya"), "Not yet: Maya and Zoe share hook 0, and Maya's coat is still the green raincoat.");
        Assert.AreEqual("yellow umbrella", room.Get("Zoe"), "Not yet: Maya and Zoe share hook 0, and Zoe's coat is the yellow umbrella.");
    }

    [TestMethod]
    public void RemoveTakesOneCoatOffItsHook()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        room.Put("Zoe", "yellow umbrella");
        Assert.IsTrue(room.Remove("Maya"), "Not yet: Maya checked in, so Remove(\"Maya\") gives true.");
        Assert.IsNull(room.Get("Maya"), "Not yet: after Maya leaves, Get(\"Maya\") gives null.");
        Assert.AreEqual("yellow umbrella", room.Get("Zoe"), "Not yet: removing Maya leaves Zoe's coat on the same hook.");
        Assert.AreEqual(1, room.Count, "Not yet: after Maya leaves, one coat is left.");
        Assert.IsFalse(room.Remove("Maya"), "Not yet: Maya has already left, so a second Remove gives false.");
    }

    [TestMethod]
    public void LoadFactorIsCoatsDividedByHooks()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        room.Put("Leo", "denim jacket");
        Assert.AreEqual(0.5, room.LoadFactor(), 0.0001, "Not yet: 2 coats on 4 hooks is a load factor of 0.5.");
        room.Put("Priya", "red scarf");
        Assert.AreEqual(0.75, room.LoadFactor(), 0.0001, "Not yet: 3 coats on 4 hooks is a load factor of 0.75.");
    }

    [TestMethod]
    public void GrowsWhenMoreThanThreeQuartersFull()
    {
        CoatCheck room = new CoatCheck();
        room.Put("Maya", "green raincoat");
        room.Put("Leo", "denim jacket");
        room.Put("Priya", "red scarf");
        Assert.AreEqual(4, room.BucketCount, "Not yet: 3 coats on 4 hooks is exactly three-quarters full, so no resize yet.");
        room.Put("Zoe", "yellow umbrella");
        Assert.AreEqual(8, room.BucketCount, "Not yet: the 4th coat makes it more than three-quarters full, so the hooks double to 8.");
        Assert.AreEqual(0.5, room.LoadFactor(), 0.0001, "Not yet: 4 coats on 8 hooks is a load factor of 0.5.");
    }

    [TestMethod]
    public void EveryCoatIsFoundAfterManyResizes()
    {
        CoatCheck room = new CoatCheck();
        for (int i = 0; i < 1000; i++)
        {
            room.Put("Guest " + i, "Coat " + i);
        }
        Assert.AreEqual(1000, room.Count, "Not yet: 1,000 guests left 1,000 coats.");
        Assert.AreEqual(2048, room.BucketCount, "Not yet: doubling from 4 hooks whenever it's more than three-quarters full ends at 2,048 hooks for 1,000 coats.");
        for (int i = 0; i < 1000; i++)
        {
            Assert.AreEqual("Coat " + i, room.Get("Guest " + i), "Not yet: after resizing, every coat must be found again: Guest " + i + " has Coat " + i + ".");
        }
    }

    [TestMethod]
    public void ABusyNightStaysFast()
    {
        CoatCheck room = new CoatCheck();
        Stopwatch watch = Stopwatch.StartNew();
        for (int i = 0; i < 50000; i++)
        {
            room.Put("Guest " + i, "Coat " + i);
        }
        for (int i = 0; i < 50000; i++)
        {
            Assert.AreEqual("Coat " + i, room.Get("Guest " + i), "Not yet: on a busy night every coat must still be found: Guest " + i + " has Coat " + i + ".");
        }
        watch.Stop();
        Assert.IsTrue(watch.Elapsed.TotalSeconds < 2, "Not yet: 50,000 coats in and out took " + watch.Elapsed.TotalSeconds.ToString("0.0") + " seconds. When put and get each work on one hook, it takes well under one.");
    }
}
