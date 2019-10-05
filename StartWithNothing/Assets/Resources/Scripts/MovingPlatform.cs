using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float NewX, NewY;
    public float DelayBetweenMoves;
    public float PlatformSpeed = 100f;

    private Transform wall;
    private float deltaX = 0f;
    private float deltaY = 0f;
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        wall = GetComponent<Transform>();
        FindDelta();
        StartCoroutine("Move");

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Move()
    {

        while (true)
        {

            //gets starting position of the object
            float currentX = wall.position.x;
            float currentY = wall.position.y;
            //moves the object from starting coordinates to new coordinates
            for (float ft = 10000; ft >= 0; ft -= PlatformSpeed)
            {
                currentX += deltaX;
                currentY += deltaY;
                wall.position = new Vector2(currentX, currentY);
                yield return null;
            }
            //pauses platform at end location for some seconds
            yield return new WaitForSeconds(DelayBetweenMoves);
            //moves the object from new coordinates to the start coordinates
            for (float ft = 10000; ft >= 0; ft -= PlatformSpeed)
            {
                currentX -= deltaX;
                currentY -= deltaY;
                wall.position = new Vector2(currentX, currentY);
                yield return null;
            }
            //pauses platform at end location for some seconds
            yield return new WaitForSeconds(DelayBetweenMoves);
        }

    }
    void FindDelta()
    {
        deltaX = (NewX - wall.position.x) / (10000 / PlatformSpeed);
        deltaY = (NewY - wall.position.y) / (10000 / PlatformSpeed);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.parent = transform;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        col.transform.parent = null;
    }
}