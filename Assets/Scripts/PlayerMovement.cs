using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Joystick joystick;
    public float maxvelocity=2f,jumpForce = 10f, movementSpeed,noofjumps=1,timetojump=1f,jumpDelay=0.5f, reversegravityforce=100f;

    public bool canJump = true;
    private int i = 0;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody>().AddForce(new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, 0), ForceMode.Impulse);
        GetComponent<Rigidbody>().AddForce(new Vector3(joystick.Horizontal * movementSpeed * Time.deltaTime, 0, 0), ForceMode.Impulse);

        GetComponent<Rigidbody>().velocity = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().velocity.x, -maxvelocity, maxvelocity), GetComponent<Rigidbody>().velocity.y, 0);
        for (int j = 0; j < Input.touchCount; j++)
        {
            if ((Input.GetTouch(j).position.x>Screen.width/2) && canJump && noofjumps >= i && Time.time > timetojump)
            {
                jump();
                j++;
            }
        }
        if (Input.GetKey(KeyCode.Space)  && canJump && noofjumps >= i && Time.time > timetojump)
        {
            jump();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        i = 0;
        canJump = true;
    }
    public void jump()
    {
        timetojump = Time.time + jumpDelay;
        GetComponent<Rigidbody>().velocity += new Vector3(0, jumpForce * jumpForce / 20, 0);
        i++;
        if(i==noofjumps)
            canJump = false;              
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("reversegravity"))
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().velocity += new Vector3(0, reversegravityforce * Time.deltaTime, 0);
            }
            for (int z = 0; z < Input.touchCount; z++)
            {
                if (Input.GetTouch(z).position.x > Screen.width / 2)
                {
                    GetComponent<Rigidbody>().velocity -= new Vector3(0, reversegravityforce * Time.deltaTime, 0);
                    z++;
                }
            }
        }
    }
}
