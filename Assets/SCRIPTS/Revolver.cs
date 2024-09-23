using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : MonoBehaviour
{
    //[SerializeField] private bool aimAtBarrel;
    [SerializeField] private float impactForce = 30f;
    [SerializeField] private float gunRange;
    [SerializeField] private float revolverCD = 0.7f;
    [SerializeField] private bool canShoot = true;


    [SerializeField] private Animator revolver;
    [SerializeField] private AudioClip revolver_shoot_SFX;
    [SerializeField] private AudioClip[] revolver_ric_SFXs;

    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject light_muzzleFlash;
    [SerializeField] private GameObject impactEffect;

    [SerializeField] private LayerMask Barrel;

    //[SerializeField] private SFX canPlayRevRicoSFX;


    // Start is called before the first frame update
    void Start()
    {
        //revolverShoot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RevolverAnim();

        #region Revolver Cooldown
        if (!canShoot)
        {
            // Update the cooldown timer if not able to shoot
            revolverCD -= Time.deltaTime;

            // Check if the cooldown is complete
            if (revolverCD <= 0f)
            {
                revolverCD = 0.04f; // Reset the cooldown timer
                canShoot = true;  // Enable shooting again
            }

            if (revolverCD > 0.02f && revolverCD < 0.03f)
            {
                light_muzzleFlash.gameObject.SetActive(true);
            }
            else
            {
                light_muzzleFlash.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            RevolverShoot();
            canShoot = false; // Disable shooting until cooldown is complete
        }
        #endregion

        #region Unused Cooldown Code for Documentation
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Cooldown after Shooting
            if (canShoot == true && revolverCD == 0.7f)
            {
                RevolverShoot();
                canShoot = false;
                
                if (revolverCD > 0f)
                {
                    revolverCD = revolverCD - Time.deltaTime;
                }

                if (revolverCD == 0f)
                {
                    revolverCD = 0.7f;
                    canShoot = true;
                }

            }
            else if (canShoot == false)
            {
                return;
            }
        }*/
        #endregion

    }

    private void RevolverShoot()
    {
        SFXManager.instance.PlaySoundFXClip(revolver_shoot_SFX, transform, 0.5f);
        muzzleFlash.Play();
        //light_muzzleFlash.gameObject.SetActive(true);
        //if (revolverCD < 0.5f)
        //{
           //light_muzzleFlash.gameObject.SetActive(false);
       //}

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, gunRange, Barrel))
        {
            Debug.Log("Hit!");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            SFXManager.instance.PlayRandomSoundFXClip(revolver_ric_SFXs, transform, 0.25f);

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Barrel") && hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    private void RevolverAnim()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            revolver.SetBool("isZooming", true);
            revolver.Play("Zoom");
            gunRange = 30f;
        }
        else
        {
            revolver.SetBool("isZooming", false);
            gunRange = 10f;
        }

    }
}
