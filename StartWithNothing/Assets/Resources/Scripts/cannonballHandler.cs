using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballHandler : MonoBehaviour
{
    //public float ShotSpeedX;
    //public float ShotSpeedY;
    private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector2(ShotSpeedX,ShotSpeedY));
        Destroy(gameObject, 6.0f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            collision.gameObject.GetComponent<PlayerController>().Die();

    }

}
