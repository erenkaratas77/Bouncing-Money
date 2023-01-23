using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text : MonoBehaviour
{
    public moneySpawner moneySpawner;
    public float distY;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target.GetComponent<Player>().isFinished)
        {
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(target.position.x, target.position.y + distY, target.position.z);
        GetComponent<TextMeshPro>().text = (moneySpawner.index+1).ToString();
        

    }
}
