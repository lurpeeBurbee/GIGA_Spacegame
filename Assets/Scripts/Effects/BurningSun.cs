using System.Collections;
using UnityEngine;

public class BurningSun : MonoBehaviour
{
    [SerializeField] GameObject tank;
        SpriteRenderer tankColor;
    [SerializeField] GameObject cab; 
    SpriteRenderer cabColor;
    [SerializeField] GameObject boosters;
    SpriteRenderer boostersColor;   

    Color red = new Color(0.8f, 0.2f, 0.2f, 1);
    Color normal = new Color(1, 1, 1, 1);   
    // float burningDegree;
    // [SerializeField] float burningSpeed;

    //IEnumerator BurningEffect()
    //{
    //    if (burningDegree < 1)
    //    {
    //        while (true)
    //        {

    //            burningDegree += burningSpeed;
    //            shuttleColor.color = new Color(burningDegree, 0.2f, 1, 1);
    //            Debug.Log("Started burning: " + burningDegree);
    //            yield return new WaitForSeconds(0.2f);
    //        }
    //    }
    //}

    //IEnumerator CoolingEffect()
    //{
        //if (burningDegree < 1)
        //{
        //    while (true)
        //    {

        //        burningDegree += burningSpeed;
        //        shuttleColor.color = new Color(burningDegree, burningDegree, burningDegree, 1);
        //        Debug.Log("Cooling down: " + burningDegree);
        //        yield return new WaitForSeconds(0.2f);
        //    }
        //}

   // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Sun"))
            {

                tankColor.color = red;
                cabColor.color = red;
                boostersColor.color = red;
                //  StartCoroutine(BurningEffect());


            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        tankColor.color = normal;
        cabColor.color = normal;    
        boostersColor.color = normal;   
    }
    void Start()
    {
        //burningDegree = 0;
        //burningSpeed = 0.2f;

        tankColor = tank.GetComponent<SpriteRenderer>();

        cabColor = cab.GetComponent<SpriteRenderer>();  

        boostersColor = boosters.GetComponent<SpriteRenderer>(); 
   
    }

    void Update()
    {

    }
}
