using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject teleportDestination;
    public bool screenWrap = true;

    public enum Direction
    {
        LEFT, RIGHT, UP, DOWN
    }

    public Direction exitDirection = Direction.RIGHT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject objectToTeleport = collision.gameObject;

        float widthObjectToTeleport = collision.bounds.size.x;
        float widthTeleportDestination = teleportDestination.GetComponent<BoxCollider2D>().bounds.size.x;

        float heightObjectToTeleport = collision.bounds.size.y;
        float heightTeleportDestination = teleportDestination.GetComponent<BoxCollider2D>().bounds.size.y;

        float targetX, targetY;
        Direction targetDirection = teleportDestination.GetComponent<Teleport>().exitDirection;

        if ( targetDirection == Direction.RIGHT || targetDirection == Direction.LEFT)
        {
            int xShift = (targetDirection == Direction.LEFT) ? -1 : 1;
            targetX = teleportDestination.transform.position.x + xShift * ((widthObjectToTeleport / 2) + (widthTeleportDestination / 2) + 0.03f);
            if (!screenWrap)
            {
                targetY = teleportDestination.transform.position.y - (teleportDestination.GetComponent<BoxCollider2D>().bounds.size.y / 2) + (collision.bounds.size.y / 2);
            }
            else
            {
                targetY = objectToTeleport.transform.position.y;
            }
        }   
        else
        {
            int yShift = (targetDirection == Direction.DOWN) ? -1 : 1;
            if (!screenWrap)
            {
                targetX = teleportDestination.transform.position.x;
            }
            else
            {
                targetX = objectToTeleport.transform.position.x;
            }
            targetY = teleportDestination.transform.position.y + yShift * ((heightObjectToTeleport / 2) + (heightTeleportDestination / 2) + 0.03f);
        }

        Vector2 targetPos = new Vector2(targetX, targetY);
        objectToTeleport.transform.position = targetPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
