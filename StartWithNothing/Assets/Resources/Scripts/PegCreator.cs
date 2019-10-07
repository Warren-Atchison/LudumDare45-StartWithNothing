using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegCreator : MonoBehaviour
{
    public GameObject peg;

    void Awake()
    {
        StartCoroutine("CreatePegs");
    }
    // Start is called before the first frame update
    void Start()
    {
        peg = GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("t"))
        {
            StartCoroutine("CreatePegs");
        }
    }

    IEnumerator CreatePegs()
    {
        Instantiate(peg, new Vector2(-8.5f, -1f), Quaternion.identity);
        Instantiate(peg, new Vector2(-8.5f, 1f), Quaternion.identity);
        for (float x = -8; x <= 8; x += 1f)
        {
            for (float y = -2; y <=2; y += 2f)
            {
                Instantiate(peg, new Vector2(x, y), Quaternion.identity);
                 
            }

            for (float z = -1; z <=1; z += 2f)
            {
                Instantiate(peg, new Vector2(x+0.5f, z), Quaternion.identity);
            }
            
        }
        yield return null;
    }
}
