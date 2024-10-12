using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerdoorcontroller : MonoBehaviour
{
    [SerializeField] private Animator mydoor = null;

    [SerializeField] private bool openTrigger = false;

    [SerializeField] private bool closeTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                mydoor.Play("Door animation", 0, 0.0f);
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                mydoor.Play("Doorclose animation", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
