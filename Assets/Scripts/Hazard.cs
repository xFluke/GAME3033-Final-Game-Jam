using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.GetComponent<Player>()) {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.collider.GetComponent<Player>()) {
            Destroy(collision.gameObject);
        }
    }
}
