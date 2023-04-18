using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    Vector3 mousePosition;
    Vector2 position = new Vector2(0f, 0f);



    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.MoveTowards(transform.position, mousePosition, speed);
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            rb.MovePosition(position);
    }
}
