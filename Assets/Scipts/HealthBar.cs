using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject heart1Prefab;
    public string tag;
    public Unit unit;
    //public int currentHP;
    //public int maxHP;

    List<HealthHeart> hearts = new List<HealthHeart>();


    public void Update()
    {
        //  currentHP = unit.GetCurrentHP();
        // maxHP = unit.GetMaxHP();
        if (unit == null)
        {
            print("hello");
            unit = GameObject.FindGameObjectWithTag(tag).GetComponent<Unit>();
            DrawHearts();
        }
    }

    private void Start()
    {
        
      
        
    }

    public void DrawHearts()
    {
        ClearHearts();

        float maxHealthRemainder = unit.MaxHP % 2;
        int heartsToMake = (int)((unit.MaxHP / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(unit.CurrentHP - (i * 2), 0, 2);
            //print($"Hjärta {i} har {heartStatusRemainder}");
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
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
