using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Afterburner : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerShuttle;

    bool PlayerIsMoving;
    UnityEvent shuttleEvent;
    Movement2 movementscript;

    void Start()
    {
        PlayerShuttle.GetComponent<GameObject>();
        PlayerShuttle.SetActive(true);

        if (shuttleEvent == null)
        {
            shuttleEvent = new UnityEvent();

            shuttleEvent.AddListener(HandleAfterburner);
        }

        if (TryGetComponent(out GameObject spaceshuttle))
        {  
        movementscript = PlayerShuttle.GetComponent<Movement2>();
        PlayerIsMoving = movementscript.rb.velocity != Vector2.zero;
        }

    }

    void HandleAfterburner() { 
            PlayerShuttle.SetActive(true);
        Debug.Log("Afterburner appeared");
    }


    void Update()
    {
       if (Input.GetKey(KeyCode.Mouse0)) { 
      
    
     //  if (PlayerIsMoving && shuttleEvent != null) {

        shuttleEvent.Invoke();

        //shuttleEvent.RemoveListener(HandleAfterburner);
        }
        else
        { 
            PlayerShuttle.SetActive(false);
            Debug.Log("Afterburner disappeared");
        }

    }
}
