using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Slider powerSlider;
    public int maxJumpForce = 10;
    private bool isGrounded = false, isSquished = false, isBouncing = false;
    private static float jumpForce = 0f;
    private static float lastForceValue = 0;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = transform.GetComponent<Rigidbody2D>();
    }

    private void SetPowerSlider()
    {
        powerSlider.value = ((maxJumpForce - jumpForce) / 100) * 10f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SquishDown(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            SquishDown(false);
        }
        if(Input.GetMouseButton(0))
        {
            AddJumpForce();
        }
    }
    void FixedUpdate()
    {
        var diff = lastForceValue - rigidBody.g
    }
    private void AddJumpForce()
    {
        jumpForce = Mathf.Clamp(jumpForce += 0.05f, 0, maxJumpForce);
        SetPowerSlider();
        Debug.Log(jumpForce +", "+ powerSlider.value);
    }
    private void SquishDown(bool squish)
    {
        if (isGrounded && !isSquished && squish)
        {
            //transform.GetComponent<Animator>().SetBool("Squish", true);
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(transform.localScale.y / 2, 0.15f, 0.3f), transform.localScale.z);
            isSquished = true;
            Debug.Log("Squished");
        } else if (isGrounded && !squish) 
        {
            //transform.GetComponent<Animator>().SetBool("Squish", false);
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Clamp(transform.localScale.y * 2, 0.15f, 0.3f), transform.localScale.z);
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 pos = (Input.mousePosition - sp).normalized;
            transform.GetComponent<Rigidbody2D>().AddForce(pos * jumpForce, ForceMode2D.Impulse);

            transform.GetComponent<Rigidbody2D>().AddForce(pos * jumpForce);
            isSquished = false;
            jumpForce = 0;
            powerSlider.value = 1;
            Debug.Log("Unsquish");
        }
        //else if (isGrounded && isSquished && squish)
        //{
        //    transform.position = 
        //}
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
        if(col.gameObject.tag == "Exit" || col.gameObject.tag == "Platform")
        {
            
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false ;
            Debug.Log("Ungounded");
        }
    }
}
