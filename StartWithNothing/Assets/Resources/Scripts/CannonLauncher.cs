using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLauncher : MonoBehaviour
{
    public GameObject Cannonball;
    public float SecondsBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireCannon");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FireCannon()
    {
        while (true)
        {
            CreateCannonball();
            yield return new WaitForSeconds(SecondsBetweenShots);
        }
    }
    void CreateCannonball()
    {
        Instantiate(Cannonball, gameObject.transform.position, Quaternion.identity);
    }
}
