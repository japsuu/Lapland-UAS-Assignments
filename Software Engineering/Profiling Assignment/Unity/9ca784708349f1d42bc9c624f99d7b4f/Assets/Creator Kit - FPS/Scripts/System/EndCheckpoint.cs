using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCheckpoint : MonoBehaviour
{

    public void Update()
    {
        #region
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        GameObject.Find("Character");
        #endregion
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Controller>() == null)
            return;
        
        
        GameSystem.Instance.StopTimer();
        GameSystem.Instance.FinishRun();
        Destroy(gameObject);
    }
}
