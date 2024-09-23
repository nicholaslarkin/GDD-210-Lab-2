using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSelection : MonoBehaviour
{
    public bool inMenu = false;
    public GameObject classSelectMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            inMenu = true;
            classSelectMenu.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Period)) //fix later to work with "comma" && bool instead
        {
            inMenu = false;
            classSelectMenu.SetActive(false);
        }
    }
}
