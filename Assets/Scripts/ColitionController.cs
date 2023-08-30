using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColitionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("acabar juego");
            UIManager.Instance.ChangeScene("MainMenu");
        }
    }
    private void onTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("acabar juego");
            UIManager.Instance.ChangeScene("MainMenu");
        }
       
    }
}
