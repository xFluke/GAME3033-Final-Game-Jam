using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>()) {
            Destroy(collision.gameObject);
        }
    }
}
