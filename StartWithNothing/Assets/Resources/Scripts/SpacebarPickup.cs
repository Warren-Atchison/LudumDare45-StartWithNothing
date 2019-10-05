using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        Destroy(this.gameObject);
        Debug.Log("YOU PICKED UP SPACEBAR!");

        GameObject.Find("Player").GetComponent<PlayerController>().AddKey("Spacebar", KeyCode.Space);
    }
}
