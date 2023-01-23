using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public PhysicMaterial moneyPhysic;
    public float speed;
    bool canITouchAgain;

    // Start is called before the first frame update
    void Start()
    {
        moneyPhysic.bounciness = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.forward * speed * Time.deltaTime;


        if (Input.GetMouseButtonDown(0) && canITouchAgain)
        {
            
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            moneyPhysic.bounciness = 0.75f;

            GetComponent<Rigidbody>().AddForce(0, -600, 0);
            canITouchAgain = false;
            
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(0, 0, 0);

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            moneyPhysic.bounciness = 1;
            canITouchAgain = true;

        }
    }
}
