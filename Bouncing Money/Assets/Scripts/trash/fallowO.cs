using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallowO : MonoBehaviour
{


    public GameObject followingMe; 
    public int followDistance;
    private List<Vector3> storedPositions;


    void Awake()
    {
        storedPositions = new List<Vector3>(); 

    }

    void Start()
    {

    }

    void Update()
    {
        storedPositions.Add(transform.position); 
        transform.forward = Vector3.RotateTowards(transform.forward, storedPositions[0] - transform.position, 20 * Time.deltaTime, 4.0f);

        if (storedPositions.Count > followDistance)
        {
            followingMe.transform.position = storedPositions[0]; 
            storedPositions.RemoveAt(0); 
        }
    }
}