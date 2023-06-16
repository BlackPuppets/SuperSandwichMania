using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetAnimation : MonoBehaviour
{
    [SerializeField] private float _ScrollX = 0.5f;
    [SerializeField] private float _ScrollY = 0.5f;

    private void Update()
    {
        GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2(Time.time * _ScrollX, Time.time * _ScrollY);
    }
}
