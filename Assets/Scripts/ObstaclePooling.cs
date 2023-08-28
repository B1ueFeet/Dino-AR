using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooling : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;
    [SerializeField]
    private int poolsize = 10;
    [SerializeField]
    private List<GameObject> obstaclelist;

    private static ObstaclePooling instance;

    public static ObstaclePooling Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AddInstance(poolsize);
    }

    private void AddInstance(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomizer = Random.Range(0, prefabs.Count); 
            GameObject obstacle = Instantiate(prefabs[randomizer]);
            obstacle.SetActive(false);
            obstaclelist.Add(obstacle);
            obstacle.transform.parent = transform;
        }
    }

    public GameObject Request()
    {
        int randomizer = Random.Range(0, obstaclelist.Count);
        if (!obstaclelist[randomizer].activeSelf)
        {
            obstaclelist[randomizer].SetActive(true);
            return obstaclelist[randomizer];
        }
        else return Request();        
    
    }


}
