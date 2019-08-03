using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        player.ground = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.ground = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.ground = false;
    }
}
