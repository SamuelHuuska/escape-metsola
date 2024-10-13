using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerdoorcontroller : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private bool closeTrigger = false;

    [SerializeField] private string doorOpen = "Door animation";
    [SerializeField] private string doorClose = "Doorclose animation";
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                mydoor.Play(doorOpen, 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                mydoor.Play(doorClose, 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
