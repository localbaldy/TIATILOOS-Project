using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int CurrentHP;
    public int MaxHP;
    public int Damage;

    public int GetCurrentHP()
    {
        return CurrentHP;

    }

    public int GetMaxHP()
    {
        return MaxHP; 
    }
}
