using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicControls : MonoBehaviour
{
    [Header("Required References")]
    public Camera weaponCamera;
    public GameObject player;
    public Canvas HUD;

    [Header("Toggles")]
    public bool disableWeaponVisuals = false;
    public bool disableWeaponControls = false;
    public bool disableMovementControls = false;
    public bool disableHUDVisuals = false;

    private PlayerWeaponsManager playerWeaponsManager;
    private PlayerCharacterController playerCharacterController;
    

    // Start is called before the first frame update
    void Start()
    {
        playerWeaponsManager = player.GetComponent<PlayerWeaponsManager>();
        playerCharacterController = player.GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(disableWeaponVisuals)
        {
            weaponCamera.cullingMask = LayerMask.GetMask("Nothing");
        }
        else
        {
            weaponCamera.cullingMask = LayerMask.GetMask("FirstPersonWeapon");
        }

        if(disableHUDVisuals)
        {
            HUD.enabled = false;
        } 
        else
        {
            HUD.enabled = true;
        }

        playerCharacterController.enableControls = !disableMovementControls;
        playerWeaponsManager.enableShooting = !disableWeaponControls;
    }
}
