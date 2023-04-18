using UnityEngine;

public class Proximity : MonoBehaviour
{
    public GameObject PlanetName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in proximity of");

            if (!PlanetName.activeInHierarchy)
            {
                PlanetName.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (PlanetName.activeInHierarchy)
        {
            PlanetName.SetActive(false);
        }
    }
}
