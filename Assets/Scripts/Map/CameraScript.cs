using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //public Transform player;
    public GameObject player;
    [SerializeField]
    float timeOffset;
    [SerializeField]
    Vector2 posOffset;

    //private Vector3 velocity;

    #region Camera boundaries
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float topLimit;
    [SerializeField]
    float bottomLimit;
    #endregion

    void Update()
    {
        // Cam Start pos
        Vector3 startPos = transform.position;
        // Players current pos
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        #region Camera Smoothing
        // Lerp Camera smoothing
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        // SmoothDamp Camera smoothing, Needs velocity attribute
        //transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
        #endregion

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        // Draw a box around our camera boundary
        Gizmos.color = Color.red;
        // Top boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        // Right boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        // Bottom boundary line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        // Left boundary line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));
    }
}
