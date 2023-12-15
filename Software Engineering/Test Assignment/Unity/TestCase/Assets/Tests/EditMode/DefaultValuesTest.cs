using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DefaultValuesTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestDefaultHealthValue()
        {
            Assert.AreEqual(100f, DefaultValues.defaultHealth, "DefaultValues Class not match to requiments, default health value is incorrect");
        }

    }
}
