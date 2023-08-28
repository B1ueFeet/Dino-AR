using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColitionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("acabar juego");
        }
        else if (other.gameObject.tag == "EndPoint")
        {
            gameObject.SetActive(false);
        }
    }
}
