using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothnessFactor;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, smoothnessFactor);
    }
}
