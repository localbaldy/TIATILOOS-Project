using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject heart1Prefab;

    public Unit unit;
    //public int currentHP;
    //public int maxHP;

    List<HealthHeart> hearts = new List<HealthHeart>();


    /*public void Update()
    {
        currentHP = unit.GetCurrentHP();
        maxHP = unit.GetMaxHP();
    }*/

    public void DrawHearts()
    {
        ClearHearts();

        float maxHealthRemainder = unit.MaxHP % 2;
        int heartsToMake = (int)((unit.MaxHP / 2) + maxHealthRemainder);
        for (int i = 0; i < hearts.Count; i++)
        {
            CreateEmptyHeart();
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heart1Prefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }

}
