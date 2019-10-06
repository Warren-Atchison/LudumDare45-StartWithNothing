using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public bool isPushed;
    public bool oneUse;
    private bool safetytimer = false;
    private bool hasBeenPushed = false;

    public Sprite pushedButton;
    public Sprite unpushedButton;
    public BoxCollider2D pushedCollider;
    public BoxCollider2D unpushedCollider;

    public GameObject[] objectsToToggle;

    private void Start()
    {
        if (!isPushed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = unpushedButton;
            pushedCollider.enabled = false;
            unpushedCollider.enabled = true;
            isPushed = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pushedButton;
            pushedCollider.enabled = true;
            unpushedCollider.enabled = false;
            isPushed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (safetytimer || (oneUse && hasBeenPushed))
            return;

        if (isPushed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = unpushedButton;
            pushedCollider.enabled = false;
            unpushedCollider.enabled = true;
            isPushed = false;
            StartCoroutine("Timeout");
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = pushedButton;
            pushedCollider.enabled = true;
            unpushedCollider.enabled = false;
            isPushed = true;
            StartCoroutine("Timeout");
        }

        if (oneUse)
            hasBeenPushed = true;

        foreach(GameObject go in objectsToToggle)
            go.SetActive(!go.activeInHierarchy);
    }

    IEnumerator Timeout()
    {
        safetytimer = true;
        yield return new WaitForSeconds(0.4f);
        safetytimer = false;
    }
}
