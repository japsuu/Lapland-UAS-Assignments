using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    private float health;

    private bool isPlayer;

    public bool IsPlayer
    {
        get
        {
            return this.isPlayer;
        }
    }


    public float Health { 
        get { 
            return this.health; 
        } 
    }

    void Awake()
    {
        this.health = DefaultValues.defaultHealth;
        this.isPlayer = true;
    }


    void Update()
    {
        
    }

    public void DoDamage(float damage)
    {
        this.health -= damage;

        if (this.health < DefaultValues.minHealthValue)
            this.health = DefaultValues.minHealthValue;
    }

    public void Heal(float heal)
    {
        this.health += heal;

        if (this.health > DefaultValues.maxHealthValue)
            this.health = DefaultValues.maxHealthValue;
    }

    public void Hide()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Show()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }


}