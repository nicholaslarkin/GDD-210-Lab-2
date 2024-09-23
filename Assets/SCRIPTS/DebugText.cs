using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugText : MonoBehaviour
{
    [SerializeField] private TMP_Text classText;
    [SerializeField] private TMP_Text weaponText;

    // Method to set the class text
    public void SetClassText(string text)
    {
        classText.text = text;
    }

    // Method to set the weapon text
    public void SetWeaponText(string text)
    {
        weaponText.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        //classText.text = Classes.Sniper.ToString();
        //weaponText.text = Weapons.SniperRifle.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // This might not be necessary since I'm setting text in the Sniper class
        // classText.text = Classes.Sniper.ToString();
        // weaponText.text = Weapons.SniperRifle.ToString();
    }
    #region Unused Code
    /*[SerializeField] private TMP_Text classText;
    [SerializeField] private TMP_Text weaponText;
    [SerializeField] private string classID;
    [SerializeField] private string weaponID;

    //List_Weapons.Weapons;

    // Start is called before the first frame update
    void Start()
    {
        classText.text = Weapons.SniperRifle.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        classText.text = Classes.Sniper.ToString();
        weaponText.text = Weapons.SniperRifle.ToString();
    }*/
    #endregion
}
