using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfmoveX : MonoBehaviour
{
    public float Speed = 0.05f, changeDirection = -1;
    Vector3 Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move.x += Speed;
        this.transform.position = Move;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Speed *= changeDirection;
        }
    }
}
