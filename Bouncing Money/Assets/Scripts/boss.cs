using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class boss : MonoBehaviour
{
    public GameObject poor, normal, rich;
    public ParticleSystem smoke;
    public int moneyCount=0;
    public GameObject[] Scores;
    int i=1;
    bool scoreStart = false;
    void Start()
    {
                StartCoroutine(highScore());

    }

    // Update is called once per frame
    void Update()
    {
        
        if (moneyCount < 20)
        {
            poor.SetActive(true);
            normal.SetActive(false);
            rich.SetActive(false);
        }
        else if (moneyCount < 30)
        {
            if (i == 1)
            {
                smoke.Play();
                i += 1;

            }
            poor.SetActive(false);
            normal.SetActive(true);
            rich.SetActive(false);
        }
        else if (moneyCount >= 40)
        {
            if (i == 2)
            {
                smoke.Play();
                i += 1;
            }
            poor.SetActive(false);
            normal.SetActive(false);
            rich.SetActive(true);
        }

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "shotableMoney")
        {
            scoreStart = true;
            Destroy(collision.gameObject);
            moneyCount += 1;

        }
    }
    IEnumerator highScore()
    {
        while (true)
        {
            if (scoreStart)
            {
                for (int i = 0; i < 12; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    if (moneyCount < i * 5)
                    {
                        break;
                    }
                    Scores[i].transform.DOScale(new Vector3(1, 1, 1), 1);

                    
                }

            }
            

            yield return new WaitForSeconds(0.05f);


        }

    }

    
}
