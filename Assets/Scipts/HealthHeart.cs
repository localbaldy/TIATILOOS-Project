using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{

    public Sprite fullHeart, halfHeart, emptyHeart;
    Image Heart20;

    private void Awake()
    {
        Heart20 = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                Heart20.sprite = emptyHeart;
                break;
            case HeartStatus.Half:
                Heart20.sprite = halfHeart;
                break;
            case HeartStatus.Full:
                Heart20.sprite = fullHeart;
                break;
        }
    }
}

public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full =2,
}