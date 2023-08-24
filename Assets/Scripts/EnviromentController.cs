using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] GameObject front;
    [SerializeField] GameObject back;
    [SerializeField] GameObject floor;

    [SerializeField] float moveSpeed = 15.0f;
    [SerializeField] float backFactor;
    [SerializeField] float frontFactor;

    [SerializeField] Transform start;
    [SerializeField] Transform end;

    [SerializeField] List<GameObject> elements;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        ManageParallax();
        ManageSpawn();
        
    }

    void ManageMovement()
    {
        floor.transform.position = new Vector3(floor.transform.position.x - moveSpeed * Time.deltaTime, floor.transform.position.y, floor.transform.position.z );
    }

    void ManageParallax()
    {
        //Back
        back.transform.position = new Vector3(back.transform.position.x - (moveSpeed * backFactor) * Time.deltaTime, back.transform.position.y, back.transform.position.z);
        //Front
        front.transform.position = new Vector3(front.transform.position.x - (moveSpeed * frontFactor) * Time.deltaTime, front.transform.position.y, front.transform.position.z);

    }

    void ManageSpawn()
    {
        foreach (GameObject element in elements)
        {
            Debug.Log("ahora esta aca");
            if (element.transform.position.x <= end.position.x) {
                element.transform.position = new Vector3(start.position.x,element.transform.position.y,element.transform.position.z);
            }
        }
    }
}
