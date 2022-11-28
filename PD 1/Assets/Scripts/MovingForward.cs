using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    public GameObject target;
    public float speed, elapsedTime;

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 1, -10);
        float accelerationX = transform.position.x - target.transform.position.x;
        float accelerationY = transform.position.y - target.transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, accelerationX / 4 + accelerationY / 4 + speed * Time.deltaTime);
    }
}
