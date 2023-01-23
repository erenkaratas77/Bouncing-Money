using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameFail : MonoBehaviour
{
    public GameObject player;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("fail"))
        {
            levelManager.fail();
            Destroy(player);
            Destroy(this.gameObject);
        }
    }
}
