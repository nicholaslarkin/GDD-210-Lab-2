using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    private DebugText debugText;

    FPSController fpsController;
    private float moveSpeed;
    private float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {

        debugText = FindObjectOfType<DebugText>();
        fpsController = FindObjectOfType<FPSController>();

        if (debugText != null)
        {
            debugText.SetClassText(Classes.Sniper.ToString());
            debugText.SetWeaponText(Weapons.SniperRifle.ToString());
        }

        if (fpsController != null)
        {
            
            fpsController.moveSpeed = 7.5f; 
            fpsController.zoomSpeed = 2f;

            moveSpeed = fpsController.moveSpeed;
            zoomSpeed = fpsController.zoomSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        #region Weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (debugText != null)
            {
                debugText.SetWeaponText(Weapons.SniperRifle.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (debugText != null)
            {
                debugText.SetWeaponText(Weapons.SMG.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (debugText != null)
            {
                debugText.SetWeaponText(Weapons.Kukri.ToString());
            }
        }
        #endregion

        #region Sniper Rifle

        bool isZooming = Input.GetKey(KeyCode.Mouse1);

        if (isZooming)
        {
            moveSpeed = zoomSpeed;
        }
        else
        {
            moveSpeed = 7.5f;
        }

        #endregion
    }
}
