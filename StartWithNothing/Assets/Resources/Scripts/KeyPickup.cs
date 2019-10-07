using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyName;
    public KeyCode keyCode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("YOU PICKED UP THE " + keyName + " KEY!");

            GameObject.Find("Player").GetComponent<PlayerController>().AddKey(keyName, keyCode);
            ShowPickup();
        }
    }

    private void ShowPickup()
    {
        return;
    }
}
