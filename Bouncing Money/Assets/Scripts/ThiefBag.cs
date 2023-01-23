using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThiefBag : MonoBehaviour
{
    public GameObject thief;
    public ParticleSystem bills;
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

        if (collision.gameObject.CompareTag("Player"))
        {
            bills.Play();
            transform.DOLocalMoveY(.2f, 1);
            transform.parent.DOScale(new Vector3(8, 8, 8), 1);
            thief.GetComponent<Animator>().SetBool("isHappy", true);
            Destroy(this);
            Debug.Log("Girdi");
        }
    }
}
