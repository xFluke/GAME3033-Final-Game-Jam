using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float speed;

    float timeAlive = 0f;
    private void Update() {
        if (timeAlive > 8f) {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        timeAlive += Time.deltaTime;
    }
}
