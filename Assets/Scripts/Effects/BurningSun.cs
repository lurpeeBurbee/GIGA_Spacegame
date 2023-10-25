using System.Collections;
using UnityEngine;

public class BurningSun : MonoBehaviour
{
    [SerializeField] GameObject tank;
    SpriteRenderer tankColor, cabColor, boostersColor;
    [SerializeField] GameObject cab;

    [SerializeField] GameObject boosters;


    //Color red = new(0.8f, 0.2f, 0.2f, 1);
    //Color normal = new(1, 1, 1, 1);
    float burningDegree;
    [SerializeField] float burningSpeed;
    void ReColor(SpriteRenderer sr, bool isBurning)
    {
        if (isBurning)
        {
            sr.color = new(burningDegree, 0.2f, 1, 1);
                }
        else
        {
            sr.color = new(burningDegree, burningDegree, burningDegree, 1);
        }

    }
    IEnumerator BurningEffect()
    {

        if (burningDegree <= 1)
        {
            while (true)
            {
                if (burningDegree == 1)
                {
                   burningDegree -= 0.2f;      // Turn to black
                ReColor(tankColor, true);
                ReColor(cabColor, true);
                ReColor(boostersColor, true);


                    //tankColor.color = new(0, 0, 0, 1);
                    //cabColor.color = new(0, 0,0, 1);    
                    //boostersColor.color = new(0,0,0, 1);    
                    yield break;
                }

                burningDegree += burningSpeed;
               // tankColor.color = new(burningDegree, 0.2f, 1, 1);

                Debug.Log("Started burning: " + burningDegree);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator CoolingEffect()
    {
        if (burningDegree < 1)
        {
            while (true)
            {
                if (burningDegree == 1)
                {
                    yield break;
                }
                burningDegree += burningSpeed;
                ReColor(tankColor, false);
                ReColor(cabColor, false);
                ReColor(boostersColor, false);
                Debug.Log("Cooling down: " + burningDegree);
                yield return new WaitForSeconds(0.2f);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
   
            StopCoroutine(CoolingEffect());
            if (collision.CompareTag("Sun"))
            {
                if (burningDegree <= 1)
                {
                    //tankColor.color = red;
                    //cabColor.color = red;
                    //boostersColor.color = red;
                    StartCoroutine(BurningEffect());
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        StopCoroutine(BurningEffect());
       StartCoroutine(CoolingEffect());
        //tankColor.color = normal;
        //cabColor.color = normal;
        //boostersColor.color = normal;
    }
    void Start()
    {
        burningDegree = 1;
        burningSpeed = 0.2f;

        tankColor = tank.GetComponent<SpriteRenderer>();

        cabColor = cab.GetComponent<SpriteRenderer>();

        boostersColor = boosters.GetComponent<SpriteRenderer>();

    }


}
