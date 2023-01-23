using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camFallow : MonoBehaviour
{
    public GameObject target;
    public Player player;
    public Vector3 dist;
    public float speed;

    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!player.isFinished)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + dist, Time.deltaTime * speed);

        }
        else
        {
           
            transform.DORotate(new Vector3(0, 0, 0), 2);
            transform.DOMove(new Vector3(0, 8, 127), 2);
        }
    }
}
