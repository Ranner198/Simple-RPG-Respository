using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGMovementSystem : MonoBehaviour {

    //Mover
    private Vector3 pos;
    public float speed;
    public Rigidbody rb;

    //Stopper && IsMoving
    public static bool CanMove = true;
    public static bool IsMoving = false;

    //Rotate
    public Vector3 Dir;

    //ResetPos
    public static bool shouldReset = false;

	void Start ()
    {
        //Getting Initial Pos
        pos = transform.position;
        rb = GetComponent<Rigidbody>();
        CanMove = true;
    }

    void FixedUpdate()
    {
        //Check if can move
        if (CanMove == true)
        {
            //Movement Keyboard Only -----------------------------------------------------------------------------------
            if (Input.GetKey(KeyCode.W) && transform.position == pos)
            {
                Dir = Vector3.forward;
                pos += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == pos)
            {
                Dir = Vector3.back;
                pos += Vector3.back;
            }
            if (Input.GetKey(KeyCode.A) && transform.position == pos)
            {
                Dir = Vector3.left;
                pos += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == pos)
            {
                Dir = Vector3.right;
                pos += Vector3.right;
            }

            //Move to here -----------------------------------------------------------------------------

            pos.y = transform.position.y;

            rb.transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);


            //Rotate Player
            if ((Dir != Vector3.zero))
                transform.rotation = Quaternion.LookRotation(Dir);

            //Is Moving works backwards for some reason?
            if (transform.position != pos)
            {
                IsMoving = true;
            }
            else
                IsMoving = false;

        }
        


        //RESET POS ---------------------------------------------------------------------------------

        //Reset Call From SceneChangeScript LN 33
        if (shouldReset)
        {
            shouldReset = false;
            ResetPosition();
        }

    }
    //Reset
    void ResetPosition()
    {        
        while (transform.position != pos)
        {
            pos = transform.position;
        }
    }
}
