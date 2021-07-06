using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTransform;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    public float smooth;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != playerTransform.position)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z*-2);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        }
    }
}
