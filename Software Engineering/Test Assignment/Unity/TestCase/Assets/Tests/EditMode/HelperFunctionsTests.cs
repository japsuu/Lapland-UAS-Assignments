using NUnit.Framework;

namespace Tests
{
    public class HelperFunctionsTests
    {
        // 1. Testaa jos nopeus on nolla, että range on nolla
        [Test]
        public void ComputeRange_ReturnsZero_WhenSpeedIsZero()
        {
            HelperFunctions hf = new HelperFunctions();
            float range = hf.ComputeRange(0, 25);
            Assert.AreEqual(0, range);
        }

        
        // 2. testaa jos kulma on nolla, että range on nolla
        [Test]
        public void ComputeRange_ReturnsZero_WhenAngleIsZero()
        {
            HelperFunctions hf = new HelperFunctions();
            float range = hf.ComputeRange(600, 0);
            Assert.AreEqual(0, range);
        }

        
        // 3. testaa että heittoliikkeen lentoaika pelaa, jos nopeus on nolla
        [Test]
        public void FlyTime_ReturnsZero_WhenSpeedIsZero()
        {
            HelperFunctions hf = new HelperFunctions();
            float time = hf.FlyTime(0, 25);
            Assert.AreEqual(0, time);
        }

        
        // 3. testaa että heittoliikkeen lentoaika pelaa, jos kulma on nolla
        [Test]
        public void FlyTime_ReturnsZero_WhenAngleIsZero()
        {
            HelperFunctions hf = new HelperFunctions();
            float time = hf.FlyTime(600, 0);
            Assert.AreEqual(0, time);
        }

        
        // 3. testaa että heittoliikkeen lentoaika pelaa muilla arvoilla. https://fi.wikipedia.org/wiki/Heittoliike
        [Test]
        public void FlyTime_ReturnsExpectedValue_WithGivenParameters()
        {
            HelperFunctions hf = new HelperFunctions();
            float time = hf.FlyTime(600, 25);
            Assert.AreEqual(51.70, System.Math.Round(time, 2));
        }
    }
}
