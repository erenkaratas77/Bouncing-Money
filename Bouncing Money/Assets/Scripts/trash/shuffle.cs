using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class shuffle : MonoBehaviour
{
    public GameObject[] moneies;
    GameObject[] moneiesCopy;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Shuffle());
            
        }
    }

    IEnumerator Shuffle()
    {
        for(int i = 0; i < moneies.Length; i++)
        {
            moneies[i].transform.DOMoveZ(moneies[i].transform.position.z + 3, 1);
            moneies[i].transform.DOMoveY(0.2f * (i + 1), 1);

            moneies[i].transform.DORotate(new Vector3(180, 0, 0), 1f, RotateMode.LocalAxisAdd);


            yield return new WaitForSeconds(0.3f);

        }
        Array.Reverse(moneies);
    }
   
    
}

