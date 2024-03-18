using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponBehavior
{
    private void Awake()
    {
        OnM1 += Ming;
        OnM2 += Ming2;
    }
    public virtual void Shoot()
    {

    }
    private void Ming()
    {
        print("ÀÀ¿ì¿£!!!");

    }
    private void Ming2()
    {
        print("¾¾¹ß!!!");
    }
}