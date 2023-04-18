using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTrigger : MonoBehaviour
{
    #region Variables
    [Header("Player's GameObject")]
    public GameObject player;
    [Header("Interractive Menu's GameObject")]
    public GameObject interractionMenu;
    [Header("Close Menu's GameObject")]
    public GameObject closeMenu;

    [Header("Planets GameObject")]
    public GameObject planet;
    [Header("NPCs GameObject")]
    public GameObject person;
    #endregion

    private void OnCollisionEnter2D(Collision2D planet)
    {
        player.GetComponent<Movement2>().enabled = false;

        if (!interractionMenu.activeInHierarchy)
        {
            interractionMenu.SetActive(true);
            person.SetActive(true);
        }
    }
}
