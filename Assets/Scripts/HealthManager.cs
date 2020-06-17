using System;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    
    public int Health { get; private set;}

    public Action<int> OnTakeDamage;
    public Action OnDeath;

    void Start()
    {
        Health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        Health = Math.Max(Health - damage, 0);
        OnTakeDamage?.Invoke(damage);
        //Debug.Log("Damage taken: " + damage);
        if (IsDead())
        {
            OnDeath?.Invoke();
            //Debug.Log("Ded");
        }
    }

    public bool IsDead()
    {
        return Health == 0;
    }
}
