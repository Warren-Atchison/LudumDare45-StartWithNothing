using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    public GameObject cannonball;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireCannon");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            CreateCannonball();
        }
    }

    IEnumerable FireCannon()
    {
        while (true)
        {
            CreateCannonball();
            yield return new WaitForSeconds(4);
        }
    }
    void CreateCannonball()
    {
        Instantiate(cannonball);
    }
}
