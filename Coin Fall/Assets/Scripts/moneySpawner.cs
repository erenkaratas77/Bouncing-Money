using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moneySpawner : MonoBehaviour
{
    public int index = 0;

    public List<GameObject> moneies;
    public GameObject moneyPrefab;
    public GameObject player;
    public GameObject playerText;
    public LevelManager levelManager;

    GameObject moneyEntryPos;
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            moneies[i] = transform.GetChild(i).gameObject;
            index += 1;
        }
        StartCoroutine(stackMoneies());

        moneyEntryPos = GameObject.FindGameObjectWithTag("moneyEnterPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (index <= 0)
        {
            levelManager.fail();
            Destroy(playerText);
            Destroy(player);
            Destroy(this.gameObject);

        }
    }
    public void addMoney(int i)
    {
        for(int t = 0; t < i; t++)
        {
            var newMoney = Instantiate(moneyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            moneies[index-1].AddComponent<fallower>();
            moneies[index-1].GetComponent<fallower>().followingMe = newMoney;
            moneies[index-1].GetComponent<fallower>().isFallowing = true;

            newMoney.transform.parent = this.gameObject.transform;

            moneies[index] = newMoney;
            index += 1;
        }
    }
    public void timesMoney()
    {
        int a = index;
        for (int t = 0; t < a+1; t++)
        {
            var newMoney = Instantiate(moneyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            moneies[index - 1].AddComponent<fallower>();
            moneies[index - 1].GetComponent<fallower>().followingMe = newMoney;
            moneies[index - 1].GetComponent<fallower>().isFallowing = true;

            newMoney.transform.parent = this.gameObject.transform;

            moneies[index] = newMoney;
            index += 1;
        }

    }
    public void subMoney(int i)
    {
        for(int t = 0; t <= i; t++)
        {
            Destroy(moneies[index-1].GetComponent<fallower>());
            Destroy(moneies[index].gameObject);

            index -= 1;

        }
        index += 1;
    }
    public void divMoney()
    {
        int a = (index/2)+1;
        for (int t = 0; t <= a; t++)
        {
            Destroy(moneies[index - 1].GetComponent<fallower>());
            Destroy(moneies[index].gameObject);

            index -= 1;

        }
        index += 1;
    }
    public IEnumerator stackMoneies()
    {
        while (true)
        {
            if (player.GetComponent<Player>().isFinished)
            {
                int howMuchMoney = index;

                for (int i = 0; i < howMuchMoney; i++)
                {
                    
                    moneies[i].transform.DORotate(new Vector3(90, 90, 0), 0.5f);
                    moneies[i].transform.DOMove(new Vector3(0, 3.3f, 128), 0.05f);
                    yield return new WaitForSeconds(0.05f);
                    moneies[i].transform.DOMove(moneyEntryPos.transform.position, 1);
                    Destroy(moneies[i].GetComponent<fallower>());



                    yield return new WaitForSeconds(0.05f);


                }

            }
            yield return new WaitForSeconds(0.05f);

        }


    }
}
