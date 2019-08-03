using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 50f, MaxSpeed = 3, jumpow = 200f;
    public bool faceright = true, ground = true, doublejump = false;
    public Animator aim;
    public Rigidbody2D rgb;
    
    void Start()
    {
        rgb.gameObject.GetComponent<Rigidbody2D>();
        aim.gameObject.GetComponent<Animator>();

    }
    void Update()
    {
        aim.SetFloat("Speed", Mathf.Abs(rgb.velocity.x));
        aim.SetBool("Ground", ground);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ground)
            {
                ground = false;
                doublejump = true;
                rgb.AddForce(Vector2.up * jumpow);

            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    rgb.velocity = new Vector2(rgb.velocity.x, 0);
                    rgb.AddForce(Vector2.up * jumpow * 0.7f);
                }
            }

        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        rgb.AddForce((Vector2.right) * Speed * h);

        if (rgb.velocity.x > MaxSpeed)
            rgb.velocity = new Vector2(MaxSpeed, rgb.velocity.y);
        if (rgb.velocity.x < -MaxSpeed)
            rgb.velocity = new Vector2(-MaxSpeed, rgb.velocity.y);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }
        if (ground)
        {
            rgb.velocity = new Vector2(rgb.velocity.x * 0.7f, rgb.velocity.y);
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

}

