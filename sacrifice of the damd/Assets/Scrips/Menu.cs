using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuPopup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            MenuAeben();
        }
    }

    void MenuAeben()
    {
        if (menuPopup == menuPopup.activeSelf)
        {
            menuPopup.SetActive(false);
        }
        else
        {
            menuPopup.SetActive(true);
        }
    }
}
