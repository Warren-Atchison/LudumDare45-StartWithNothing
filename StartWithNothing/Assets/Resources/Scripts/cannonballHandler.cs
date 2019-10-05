using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballHandler : MonoBehaviour
{
    public float ShotSpeedX;
    public float ShotSpeedY;
    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(ShotSpeedX,ShotSpeedY));
        Destroy(gameObject, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
