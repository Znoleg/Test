using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    private bool invulnerable = false;
    public void TakeDamage(int damageValue)
    {
        if(invulnerable == false)
        {
            health -= damageValue;
            if (health < 0)
            {
                health = 0;
                Rip();
            }
            invulnerable = true;
            Invoke("StopInvulnerable", 1f);
        }
    }

    private void StopInvulnerable()
    {
        invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void Rip()
    {
        Debug.Log("R.I.P");
    }
}
