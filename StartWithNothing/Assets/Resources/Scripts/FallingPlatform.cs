using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public int shakeTime = 1;
    public float shakeDegree = 1f;
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

        // Shaking; duration is WaitForSeconds arg * 2 * time
        for(int i = 0; i < ((shakeTime)*100)/2; i++){
            yield return new WaitForSeconds(.01f);
            platform.rotation = shakeDegree;
            yield return new WaitForSeconds(.01f);
            platform.rotation = -shakeDegree;
        }
        
        // Dropping
        // Allows platform to move
        platform.constraints = RigidbodyConstraints2D.None;
        platform.gravityScale = 4;
        yield return null;
    }
}
