using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private GameObject player;
    void Start(){
        player=GameObject.Find("Player");
    }

    public void OnTriggerEnter2D(Collider2D collision){
        StartCoroutine("ShakeNDrop");
    }

    IEnumerator ShakeNDrop(){
        Rigidbody2D platform = GameObject.Find("Fallingplatform").GetComponent<Rigidbody2D>();
        platform.bodyType = RigidbodyType2D.Dynamic;
        // Preventing the platform from moving upon collision
        platform.constraints = RigidbodyConstraints2D.FreezeAll;

        // Shaking; duration is WaitForSeconds arg * 2 * max size of i seconds
        for(int i = 0; i < 50; i++){
            yield return new WaitForSeconds(.01f);
            platform.rotation = 1f;
            yield return new WaitForSeconds(.01f);
            platform.rotation = -1f;
        }
        
        // Dropping
        // Allows platform to move
        platform.constraints = RigidbodyConstraints2D.None;
        platform.gravityScale *= 2;
        yield return null;
    }
}
