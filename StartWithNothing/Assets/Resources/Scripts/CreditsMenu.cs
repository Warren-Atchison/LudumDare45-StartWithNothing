using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void CreditsBackButton()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }
}
