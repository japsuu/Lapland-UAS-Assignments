using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterBehaviourTests
    {
        // Tehtävät, Tee testit joilla testaa seuraavat asiat
        // 1. Pelaajalle tehdään 200f damage, health:in tulisi olla 0f
        // 2. Pelaajalle tehdään 0f damage, health:in tulisi olla 100f;
        // 3. Pelaajalle tehdään Damagea 60f, jonka jälkeen Pelaajaa parannetaan (heal) 50f,
        //    pelaajan healthin tulisi olla 90f
        // 4. Pelaajaa parannetaan (heal) 50f, pelaajan healtin tulisi olla 100f
        // 5. Testaa että toimiiko pelaajan liikuttaminen taaksepäin vector3(0,0,-1)
        // 6. Testaa jos pelaajan useGravity on asetettu true arvoon, onko pelaaja kahden sekunnin päästä
        //    tippunut 19.62 yksikköä
        // 7. Testaa onko pelaajan UseGravity oletuksena pois päältä(false)


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CharacterDefaultHealth()
        {
            GameObject gObject = new GameObject();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();

            Assert.AreEqual(100f, characterBehaviour.Health, "Default health value is not correct when character initialized");

            yield return null;
        }

        [UnityTest]
        public IEnumerator DoDamage()
        {
            GameObject gObject = new GameObject();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
            characterBehaviour.DoDamage(50f);

            Assert.AreEqual(50f, characterBehaviour.Health);

            yield return null;
        }


        [UnityTest]
        public IEnumerator IsPlayerByDefault()
        {
            GameObject gObject = new GameObject();
            CharacterBehaviour characterBehaviour = gObject.AddComponent<CharacterBehaviour>();
  

            Assert.IsTrue(characterBehaviour.IsPlayer);

            yield return null;
        }


        [UnityTest]
        public IEnumerator MoveChacterForward()
        {
            GameObject gObject = new GameObject();
            CharacterMoveBehaviour characterMoveBehaviour = gObject.AddComponent<CharacterMoveBehaviour>();
            characterMoveBehaviour.Move(new Vector3(0,0,1));

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(new Vector3(0, 0, 1), characterMoveBehaviour.gameObject.transform.position);

        }


        [UnityTest]
        public IEnumerator CharacterGravity()
        {
            GameObject gObject = new GameObject();
            CharacterMoveBehaviour characterMoveBehaviour = gObject.AddComponent<CharacterMoveBehaviour>();
            characterMoveBehaviour.UseGravity = true;

            yield return new WaitForSeconds(1.0f);
           
            Assert.Greater(System.Math.Round(DefaultValues.gravity/2+0.5f, 2), System.Math.Round(characterMoveBehaviour.gameObject.transform.position.y, 2));

            Assert.Less(System.Math.Round(DefaultValues.gravity / 2, 2), System.Math.Round(characterMoveBehaviour.gameObject.transform.position.y, 2));
        }
    }
}
