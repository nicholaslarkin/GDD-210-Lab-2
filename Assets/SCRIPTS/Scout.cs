using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour
{
    private DebugText debugText;

    FPSController fpsController;
    private float moveSpeed;

    CharacterController characterController;
    public bool canJump;
    public int jumpCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        characterController = FindObjectOfType<CharacterController>();
        debugText = FindObjectOfType<DebugText>();
        fpsController = FindObjectOfType<FPSController>();

        if (debugText != null)
        {
            debugText.SetClassText(Classes.Scout.ToString());
            debugText.SetWeaponText(Weapons.Scattergun.ToString());
        }

        if (fpsController != null)
        {

            fpsController.moveSpeed = 10f;
            
            moveSpeed = fpsController.moveSpeed;
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
                debugText.SetWeaponText(Weapons.Scattergun.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (debugText != null)
            {
                debugText.SetWeaponText(Weapons.Pistol.ToString());
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (debugText != null)
            {
                debugText.SetWeaponText(Weapons.Bat.ToString());
            }
        }
        #endregion

        #region Double Jump

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0 && canJump)
        {
            jumpCount -= 1;
        }

        if (jumpCount == 0)
        {
            canJump = false;
        }

        if (characterController.isGrounded)
        {
            canJump = true;
            jumpCount = 2;
        }

        #endregion
    }
}
