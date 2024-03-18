using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class WeaponBehavior : MonoBehaviour
{
    public UnityAction OnM1;
    public UnityAction OnM2;
    public UnityAction OnZoom;
    public virtual void Equip()
    {
        gameObject.SetActive(true);
    }
    public virtual void Unequip()
    {
        gameObject.SetActive(false);
    }
}
