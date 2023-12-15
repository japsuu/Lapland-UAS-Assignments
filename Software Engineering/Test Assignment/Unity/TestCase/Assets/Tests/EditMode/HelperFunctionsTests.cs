using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HelperFunctionsTests
    {
        // Tehtävät, Tee testit joilla testaa seuraavat asiat
        // 1. Testaa jos nopeus on nolla, että range on nolla
        // 2. testaa jos kulma on nolla, että range on nolla
        // 3. testaa että heittoliikkeen lentoaika (FlyTime funktio,
        //    HelperFunctions luokka) pelaa, jos nopeus on nolla, tai
        //    kulma on nolla, sekä jollakin muilla arvoilla. https://fi.wikipedia.org/wiki/Heittoliike


        // A Test behaves as an ordinary method
        [Test]
        public void TestRange()
        {
            HelperFunctions hf = new HelperFunctions();

            float range =  hf.ComputeRange(600, 25);

            Assert.AreEqual(28111.72, System.Math.Round(range,2));
        }


    }
}
