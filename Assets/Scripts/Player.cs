using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    Animator anim;
    bool isJumping;

    public UnityEvent<Vector3> onPlayerMove;
    public UnityEvent onPlayerSuccessMove;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isJumping) {
       
            float deltaZ = 0;
            if (transform.position.z % 1 != 0) {
                deltaZ = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, deltaZ));
            onPlayerSuccessMove.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isJumping) {

            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isJumping) {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }

    void MoveCharacter(Vector3 movementVector) {
        anim.SetTrigger("Jump");
        isJumping = true;

        transform.position += movementVector;

        onPlayerMove.Invoke(transform.position);
    }

    public void FinishedJumping() {
        isJumping = false;
    }
}
