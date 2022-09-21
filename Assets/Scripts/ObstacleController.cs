using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float min;
    private float max;
    public float moveSpeed;
    public Transform endTransform;
    public Vector3 moveDir;

    public void Start()
    {
        if(moveDir.Equals(Vector3.right))
        {
            min = transform.position.x;
            max = endTransform.position.x;
        }
        else if (moveDir.Equals(Vector3.forward))
        {
            min = transform.position.z;
            max = endTransform.position.z;
        }
        else if (moveDir.Equals(Vector3.up))
        {
            min = transform.position.y;
            max = endTransform.position.y;
        }

    }

    float prevX = 0f;
    void Update()
    {
        if(moveDir.Equals(Vector3.right))
        {
            float newX = Mathf.PingPong(Time.time * moveSpeed, max - min);
            transform.position = new Vector3(newX + min, transform.position.y, transform.position.z);
            Vector3 scale = transform.localScale;
            scale.x = newX < prevX ? -1 : 1;
            transform.localScale = scale;
            prevX = newX;
        }
    }
}
