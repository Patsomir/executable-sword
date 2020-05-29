using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAnimatorPropertyHandler : MonoBehaviour
{
    private Animator animator = null;
    private Shooter shooter = null;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    public void TriggerShoot()
    {
        animator.SetTrigger("Shoot");
    }

    private void OnEnable()
    {
        shooter.OnShoot += TriggerShoot;
    }

    private void OnDisable()
    {
        shooter.OnShoot -= TriggerShoot;
    }
}
