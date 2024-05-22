using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TestTools;

public class SimpleTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void SimpleTestsSimplePasses()
    {

        string username = "User123";
        Assert.That(username, Does.StartWith("U"));
        Assert.That(username, Does.EndWith("3"));

        var list = new List<int> { 1, 2, 3, 4, 5 };
        Assert.That(list, Contains.Item(3));
        Assert.That(list, Is.All.Positive);
        Assert.That(list, Has.Exactly(2).LessThan(3));
        Assert.That(list, Is.Ordered);
        Assert.That(list, Is.Unique);
        Assert.That(list, Has.Exactly(3).Matches<int>(x => x % 2 != 0));

    }
}
