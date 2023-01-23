using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public PhysicMaterial moneyPhysic;
    public float speed;
    bool canITouchAgain;

    public bool isFinished;

    public GameObject followingMe;
    public moneySpawner moneySpawner;

    public AudioSource bounce, add, sub;
    

    int followDistance = 3;
    List<Vector3> storedPositions;


    void Awake()
    {
        storedPositions = new List<Vector3>();

    }
    void Start()
    {
        moneyPhysic.bounciness = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        storedPositions.Add(transform.position);


        if (!isFinished)
        {
            transform.localPosition += Vector3.forward * speed * Time.deltaTime;

            Vector3 newdirection = Vector3.RotateTowards(transform.forward, storedPositions[0] - transform.position, 20, 4.0f);
            transform.DORotateQuaternion(Quaternion.LookRotation(newdirection), 0.1f);
            followingMe.transform.rotation = transform.rotation;

            //transform.rotation = Quaternion.LookRotation(newdirection);


            if (storedPositions.Count > followDistance)
            {
                followingMe.transform.DOMove(storedPositions[0], 0.1f);
                storedPositions.RemoveAt(0);
            }

            if (Input.GetMouseButtonDown(0) && canITouchAgain)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                moneyPhysic.bounciness = 0.77f;

                GetComponent<Rigidbody>().AddForce(0, -600, 0);
                canITouchAgain = false;

            }
            else
            {
                GetComponent<Rigidbody>().AddForce(0, 0, 0);

            }

        }
        

        
    }
    
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            moneyPhysic.bounciness = 1f;
            canITouchAgain = true;
            bounce.Play();

        }
        else if (collision.gameObject.tag == "addGround")
        {

            moneyPhysic.bounciness = 1f;
            canITouchAgain = true;
            add.Play();

            moneySpawner.addMoney(collision.gameObject.GetComponent<ground>().operationValue);


        }
        else if (collision.gameObject.tag == "subGround")
        {

            moneyPhysic.bounciness = 1f;
            canITouchAgain = true;
            sub.Play();


            moneySpawner.subMoney(collision.gameObject.GetComponent<ground>().operationValue);


        }
        else if (collision.gameObject.tag == "timesGround")
        {
            moneyPhysic.bounciness = 1f;
            canITouchAgain = true;
            add.Play();

            moneySpawner.timesMoney();

        }
        else if (collision.gameObject.tag == "divGround")
        {
            moneyPhysic.bounciness = 1f;
            canITouchAgain = true;
            sub.Play();

            moneySpawner.divMoney();
        }
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finish")
        {
            isFinished = true;

            transform.DORotate(new Vector3(90, 90, 0), 0.5f);
            transform.DOMove(new Vector3(0, 3.3f, 128), 0.05f);
            yield return new WaitForSeconds(0.5f);
            transform.DOMove(new Vector3(0, 3.4f, 137.81f), 1);
        }
    }
    
    

    
}
