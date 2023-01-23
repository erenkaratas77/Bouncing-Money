using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class fallower : MonoBehaviour
{
    public bool isFallowing;

    public GameObject followingMe;
    int followDistance=1;
    private List<Vector3> storedPositions;

    void Awake()
    {
        storedPositions = new List<Vector3>();

    }

    // Update is called once per frame
    void Update()
    {
        storedPositions.Add(transform.position);

        if (isFallowing)
        {
            
                Vector3 newdirection = Vector3.RotateTowards(transform.forward, storedPositions[0] - transform.position, 20, 4.0f);
                transform.DORotateQuaternion(Quaternion.LookRotation(newdirection), 0.1f);
            
            


            if (storedPositions.Count > followDistance)
            {
                followingMe.transform.DOMove(storedPositions[0], 0.1f);
                storedPositions.RemoveAt(0);
            }
        }
        followingMe.transform.rotation = transform.rotation;



    }
    //void FixedUpdate()
    //{
    //    if (isFallowing)
    //    {
    //        storedPositions.Add(transform.position);

    //        followingMe.transform.rotation = transform.rotation;
    //        transform.forward = Vector3.RotateTowards(transform.forward, storedPositions[0] - transform.position, 20 * Time.deltaTime, 4.0f);

    //        if (storedPositions.Count > followDistance)
    //        {
    //            followingMe.transform.position = storedPositions[0];
    //            storedPositions.RemoveAt(0);
    //        }
    //    }

    //}
}
