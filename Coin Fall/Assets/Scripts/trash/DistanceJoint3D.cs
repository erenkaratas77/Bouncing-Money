using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJoint3D : MonoBehaviour
{

    public Rigidbody ConnectedRigidbody;
    public bool DetermineDistanceOnStart = true;
    public float Distance;
    public float Spring = 0.1f;
    public float Damper = 5f;


    protected Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (DetermineDistanceOnStart)
        {
            Distance = Vector3.Distance(rigidbody.position, ConnectedRigidbody.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var connection = rigidbody.position - ConnectedRigidbody.position;
        var distanceDiscrepancy = Distance - connection.magnitude;

        rigidbody.position += distanceDiscrepancy * connection.normalized;

        var velocityTarget = connection + (rigidbody.velocity + Physics.gravity * Spring);
        var projectOnConnection = Vector3.Project(velocityTarget, connection);

        rigidbody.velocity =(velocityTarget - projectOnConnection) / (1+Damper * Time.fixedDeltaTime);
    }
}
