using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterBehaviourTests
    {
        // 1. Pelaajalle tehdään 200f damage, health:in tulisi olla 0f
        [UnityTest]
        public IEnumerator DamageExceedsHealth_ShouldSetHealthToZero()
        {
            GameObject gObject = new();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
            characterBehaviour.DoDamage(200f);

            Assert.AreEqual(0f, characterBehaviour.Health);

            yield return null;
        }


        // 2. Pelaajalle tehdään 0f damage, health:in tulisi olla 100f;
        [UnityTest]
        public IEnumerator DamageIsZero_ShouldNotChangeHealth()
        {
            GameObject gObject = new();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
            characterBehaviour.DoDamage(0f);

            Assert.AreEqual(100f, characterBehaviour.Health);

            yield return null;
        }


        // 3. Pelaajalle tehdään Damagea 60f, jonka jälkeen Pelaajaa parannetaan (heal) 50f,
        //    pelaajan healthin tulisi olla 90f
        [UnityTest]
        public IEnumerator DamageAndHeal_ShouldCalculateHealthCorrectly()
        {
            GameObject gObject = new();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
            characterBehaviour.DoDamage(60f);
            characterBehaviour.Heal(50f);

            Assert.AreEqual(90f, characterBehaviour.Health);

            yield return null;
        }


        // 4. Pelaajaa parannetaan (heal) 50f, pelaajan healtin tulisi olla 100f
        [UnityTest]
        public IEnumerator HealExceedsDamage_ShouldSetHealthToMax()
        {
            GameObject gObject = new();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
            characterBehaviour.Heal(50f);

            Assert.AreEqual(100f, characterBehaviour.Health);

            yield return null;
        }


        // 5. Testaa että toimiiko pelaajan liikuttaminen taaksepäin vector3(0,0,-1)
        [UnityTest]
        public IEnumerator MoveCharacterBackward_ShouldUpdatePosition()
        {
            GameObject gObject = new();
            CharacterMoveBehaviour characterMoveBehaviour = gObject.AddComponent<CharacterMoveBehaviour>();
            characterMoveBehaviour.Move(new Vector3(0, 0, -1));

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(new Vector3(0, 0, -1), characterMoveBehaviour.gameObject.transform.position);
        }


        // 6. Testaa jos pelaajan useGravity on asetettu true arvoon, onko pelaaja kahden sekunnin päästä
        //    tippunut 19.62 yksikköä
        [UnityTest]
        public IEnumerator GravityEnabled_ShouldFallCorrectDistance()
        {
            GameObject gObject = new();
            CharacterMoveBehaviour characterMoveBehaviour = gObject.AddComponent<CharacterMoveBehaviour>();
            characterMoveBehaviour.UseGravity = true;

            yield return new WaitForSecondsRealtime(2.0f);
            yield return null;  // It takes Unity one frame to start applying gravity

            float positionY = characterMoveBehaviour.gameObject.transform.position.y;
            Debug.Log(positionY);
            Assert.AreEqual(-19.62d, System.Math.Round(positionY, 2));
        }


        // 7. Testaa onko pelaajan UseGravity oletuksena pois päältä(false)
        [UnityTest]
        public IEnumerator GravityDisabledByDefault_ShouldNotFall()
        {
            GameObject gObject = new();
            CharacterMoveBehaviour characterMoveBehaviour = gObject.AddComponent<CharacterMoveBehaviour>();

            yield return new WaitForSeconds(2.0f);

            Assert.AreEqual(0f, characterMoveBehaviour.gameObject.transform.position.y);
        }
    }
}