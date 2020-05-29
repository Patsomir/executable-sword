using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject[] swords = null;

    public Action OnShoot;

    public int CurrentSword { get; private set; } = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextSword()
    {
        CurrentSword += 1;
        CurrentSword %= swords.Length;
    }
    void PreviousSword()
    {
        CurrentSword += swords.Length - 1;
        CurrentSword %= swords.Length;
    }

    public void Shoot()
    {
        Instantiate(swords[CurrentSword], transform.position, transform.rotation);
        OnShoot?.Invoke();
    }
}
