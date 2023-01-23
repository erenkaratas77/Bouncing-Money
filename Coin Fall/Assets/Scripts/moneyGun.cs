using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class moneyGun : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem moneyParticle;
    public GameObject fakeShootable;
    public GameObject shotableMoneyPrefab;
    public RectTransform crosshair;
    public LevelManager levelManager;

    public Player player;
    public moneySpawner moneySpawner;
    bool canIShoot=false;
    bool aimTaken=false;

    Vector3 newPos;
    bool again=true;

    int howMuchMoney;

    Vector3 mousePosition;
    void Start()
    {
        StartCoroutine(shoot());
    }

    // Update is called once per frame
    
    private void Update()
    {
        crosshair.position = new Vector2(Screen.width/2, Mathf.Clamp(crosshair.position.y, Screen.height/2.75f, Screen.height/1.47f));
        if (player.isFinished && again)
        {
            aim();
            

        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            howMuchMoney = moneySpawner.index;
            Destroy(collision.gameObject);
            moneyParticle.Play();
            canIShoot = true;
        }
        else if (collision.gameObject.tag == "money")
        {
            Destroy(collision.gameObject);
        }
    }
    void aim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

        }
        else if (Input.GetMouseButton(0))
        {

            newPos.y = (Input.mousePosition.y - mousePosition.y)/500;


            //rotationVector = transform.rotation.eulerAngles;
            //rotationVector.z = Mathf.Clamp(rot, -3f, 3f);
            //Quaternion target = Quaternion.Euler(rotationVector);

            //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);

            transform.position += newPos;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 3, 6), transform.position.z);


            crosshair.position += Input.mousePosition - mousePosition;
            crosshair.position = new Vector3(Mathf.Clamp(crosshair.position.x, 0, Screen.width), Mathf.Clamp(crosshair.position.y, 0, Screen.height), 0);
            
            mousePosition = Input.mousePosition;
            aimTaken = true;

        }
        else if (Input.GetMouseButtonUp(0))
        {
        }

    }


    IEnumerator shoot()
    {
        while (true)
        {
            if (canIShoot)
            {
                for (int i = 0; i < howMuchMoney; i++)
                {
                    var newMoney = Instantiate(shotableMoneyPrefab, fakeShootable.transform.position , Quaternion.Euler(90, 90, 0));

                    Vector3 pos = new Vector3(crosshair.gameObject.transform.position.x, crosshair.gameObject.transform.position.y, 50);
                    Vector3 targetPosition = Camera.main.ScreenToWorldPoint(pos);
                    newMoney.transform.DOMove(targetPosition, 1);

                    yield return new WaitForSeconds(.1f);

                }
                crosshair.DOScale(new Vector3(0f, 0f, 1), 0.25f);
                moneyParticle.Stop();
                //fakeMoney.SetActive(false);
                canIShoot = false;
                levelManager.win();
                again = false;
                break;
            }
            yield return new WaitForSeconds(0.05f);

        }
            
           
        }

    

}
    
    

