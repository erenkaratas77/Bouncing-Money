using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallowp : MonoBehaviour
{

    //public Transform targetP;
    public Vector3 LastTargetPoint;
    //public Vector3 target_Offset;
    public GameObject target;
    public int Current_Position = 0;
    const int MAX_POSITIONS = 10000;
    public Vector3[] TrailRecorded = new Vector3[MAX_POSITIONS];
    public float speed = 20f;

    private void Start()
    {
        // target_Offset = transform.position - targetP.position;
    }
    void Update()
    {
        int numberOfPositions = target.GetComponent<TrailRenderer>().GetPositions(TrailRecorded);

        speed += 0.25f * Time.deltaTime;
        if (Current_Position < this.TrailRecorded.Length)
        {
            if (LastTargetPoint == null)
                LastTargetPoint = TrailRecorded[Current_Position];
            follow();

        }
    }
    void follow()
    {
        transform.forward = Vector3.RotateTowards(transform.forward, LastTargetPoint - transform.position, speed * Time.deltaTime, 4.0f);

        if (transform.position == LastTargetPoint)
        {
            Current_Position++;
            LastTargetPoint = TrailRecorded[Current_Position];
        }
    }

}