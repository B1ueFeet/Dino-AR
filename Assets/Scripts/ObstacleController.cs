using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField]private bool canInstantiate;
    [SerializeField] private Transform end;
    [SerializeField] private bool start;
    [SerializeField] private Transform player;
    void Start()
    {
        
        start = GameManager.Instance.StartGame;
        
    }

    // Update is called once per frame
    float elapsedTime = 0f;
    float repeatTime = 3f;

    void Update()
    {
        moveSpeed = GameManager.Instance.ObstacleSpeed;
        if (GameManager.Instance.StartGame)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= repeatTime)
            {
                canInstantiate = true;
                elapsedTime = 0f;
            }

            if (canInstantiate)
            {
                GameObject obstacle = ObstaclePooling.Instance.Request();
                obstacle.transform.position = transform.position;
                canInstantiate = false;
                //if (obstacle.tag == "pterodactyl") SoundManager.PlaySound(SoundManager.Sound.pterodactyl);
                StartCoroutine(MoveObstacle(obstacle));
            }
        }
    }

    IEnumerator MoveObstacle(GameObject obstacle)
    {
        while (obstacle != null)
        {
            obstacle.transform.Translate(new Vector3(0f, 0f, -moveSpeed * Time.deltaTime));
            if (obstacle.transform.position.x == player.position.x)
            {
                GameManager.Instance.sumarPuntos();
            }
            if (obstacle.transform.position.x <= end.position.x )
            {
                obstacle.gameObject.SetActive(false); 
            }
            yield return null;
        }
    }


}
