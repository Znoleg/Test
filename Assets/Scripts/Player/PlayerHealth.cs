using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHaveHealth
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    [SerializeField] private HealthBar _healthBar;
    
    private bool invulnerable = false;

    private void Start()
    {
        _health = _maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }

    public void TakeDamage(int damageValue)
    {
        int oldHealth = _health;

        if (invulnerable == false)
        {
            _health -= damageValue;
            if (_health < 0)
            {
                _health = 0;
                Rip();
            }
            invulnerable = true;
            Invoke("StopInvulnerable", 1f);
        }
        int newHealth = _health;

        // _healthBar.SetHealth(_health);

        _healthBar.SetHealthMoveTowards(oldHealth, newHealth);
    }

    private void StopInvulnerable()
    {
        invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if(_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        _healthBar.SetHealth(_health);
    }

    private void Rip()
    {
        Debug.Log("R.I.P");
    }

   
}
