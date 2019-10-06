using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public bool isPushed;
    private bool safetytimer = false;

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
        if (safetytimer)
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

        foreach(GameObject go in objectsToToggle)
            go.SetActive(!go.activeInHierarchy);
    }

    IEnumerator Timeout()
    {
        safetytimer = true;
        yield return new WaitForSeconds(0.1f);
        safetytimer = false;
    }
}
