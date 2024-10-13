using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    CollectibleCount CollectibleCount;

    private void Start()
    {
        CollectibleCount = GameObject.Find("Canvas").GetComponent<CollectibleCount>();
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleCount.IncreaseScore();
            gameObject.SetActive(false);
        }
    }
}
