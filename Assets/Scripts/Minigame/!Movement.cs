using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public Vector2 speed;

    //Mihin klikattu
    public Vector2 targetPosition;
    //Alkuperäinen sijainti
    public Vector2 relativePosition;

    private Vector2 movement;
    public Rigidbody2D rb;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Start()
    {

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            relativePosition = new Vector2(
            targetPosition.x - gameObject.transform.position.x,
            targetPosition.y - gameObject.transform.position.y);
            Vector2 mdir = relativePosition.normalized * speed;
            rb.rotation = 90 - Mathf.Atan2(mdir.x, mdir.y) * Mathf.Rad2Deg;
            rb.velocity = mdir;
            rb.angularVelocity = 0;
        }


    }

    private void FixedUpdate()
    {
        if ((targetPosition - (Vector2)transform.position).magnitude < 0.5f)
        {
            rb.velocity = Vector2.zero;
        }
    }

    // void FixedUpdate()
    // {
    //     if (speed.x * Time.deltaTime >= Mathf.Abs(relativePosition.x))
    //     {
    //         movement.x = relativePosition.x;
    //     }
    //     else
    //     {
    //         movement.x = speed.x * Mathf.Sign(relativePosition.x);
    //     }
    //     if (speed.y * Time.deltaTime >= Mathf.Abs(relativePosition.y))
    //     {
    //         movement.y = relativePosition.y;
    //     }
    //     else
    //     {
    //         movement.y = speed.y * Mathf.Sign(relativePosition.y);
    //     }

    //     if (moving)
    //     {
    //         GetComponent<Rigidbody2D>().velocity = movement;

    //     }

    // }
}