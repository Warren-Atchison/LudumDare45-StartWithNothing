using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    public GameObject cannonball;
    private GameObject cannon;
    private Sprite cannonballSprite;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GetComponent<GameObject>();
        cannonballSprite = Sprite.Create(Resources.Load("Sprite/Cannonball.png") as Texture2D, new Rect(new Vector2(0,0),new Vector2(10,10)), new Vector2(0,0));
        //StartCoroutine("FireCannon");
        CreateCannonball();
    }

    // Update is called once per frame
    public Rigidbody projectile;
    public float speed = 4;
    void Update()
    {
        if (Input.GetKey("t"))
        {
            CreateCannonball();
        }
    }

    IEnumerable FireCannon()
    {

        yield return new WaitForSeconds(2);
        //cannonball = new GameObject();
        //cannonball.transform.position = cannon.transform.position;
        //cannonball.AddComponent<SpriteRenderer>().sprite = cannonballSprite;
        //cannonball.AddComponent<Rigidbody2D>();
        //cannonball.AddComponent<BoxCollider2D>();
        //cannonball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-20, 0));
        Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
        p.velocity = transform.forward * speed;

        yield return null;
    }
    void CreateCannonball()
    {
        Instantiate(cannonball, cannon.transform);
        //GameObject cannonball = new GameObject("cannonball");
        //cannonball.AddComponent<SpriteRenderer>();
        //cannonball.GetComponent<SpriteRenderer>().sprite = cannonballSprite;
        //cannonball.AddComponent<Rigidbody2D>();
        //cannonball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0));
        //return cannonball;
    }
}
