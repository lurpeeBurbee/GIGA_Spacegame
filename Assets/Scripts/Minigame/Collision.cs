using System.Collections;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Movement2 movement;
    public GameManager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            StartCoroutine(MoveDisable());
        }

        if (collision.gameObject.CompareTag("Mercury"))
        {
            gm.currentPlanet = 1;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Venus"))
        {
            gm.currentPlanet = 2;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Earth"))
        {
            gm.currentPlanet = 3;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Mars"))
        {
            gm.currentPlanet = 4;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Jupiter"))
        {
            gm.currentPlanet = 5;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Saturn"))
        {
            gm.currentPlanet = 6;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Uranus"))
        {
            gm.currentPlanet = 7;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Neptune"))
        {
            gm.currentPlanet = 8;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }
        if (collision.gameObject.CompareTag("Pluto"))
        {
            gm.currentPlanet = 9;
            gm.Save();
            Debug.Log("currentPlanet has been set to " + gm.currentPlanet);
        }

    }

    private IEnumerator MoveDisable()
    {
        movement.enabled = false;
        yield return new WaitForSeconds(0.5f);
        movement.enabled = true;
    }
}
