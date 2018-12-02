using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;

public class FireProjectile : MonoBehaviour
{
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    //done need this anymore public GameObject m_Shell;                   // Prefab of the shell (block).
    public Transform m_FireTransform;           // A child of the tank where the shells are spawned.
    public Inventory linkedInventory;           // the inventory linked to this canon

    public float m_MinLaunchForce = 5f;        // The force given to the shell if the fire button is not held.
    public float m_MaxLaunchForce = 35f;        // The force given to the shell if the fire button is held for the max charge time.
    public float m_MaxChargeTime = 0.75f;       // How long the shell can charge for before it is fired at max force.
    public float m_RotationSpeed = 2f;

    public Slider m_PowerSlider;              
    private string m_FireButton;                // The input axis that is used for launching shells.
    //private string m_AngleUpButton;            // The input axis that is used for adjusting fire angle
    //private string m_AngleDownButton;
    private float m_CurrentLaunchForce;         // The force that will be given to the shell when the fire button is released.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.


    private void OnEnable()
    {
        // When the tank is turned on, reset the launch force and the UI
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_PowerSlider.value = m_MinLaunchForce;
    }


    private void Start()
    {
        // The fire axis is based on the player number.
        m_FireButton = "Fire" + m_PlayerNumber;
        //m_AngleUpButton = Input.GetKey(KeyCode.Z);

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }


    public void HandleInput()
    {
        m_PowerSlider.value = m_MinLaunchForce;
        if (Input.GetKey(KeyCode.O) || Input.GetKey(KeyCode.L)) {
            float xRotation = m_RotationSpeed;
            if(Input.GetKey(KeyCode.O)) {
                xRotation = xRotation * -1;
            }
            m_FireTransform.Rotate(xRotation, 0, 0);
        }
        // The slider should have a default value of the minimum launch force.

        // If the max force has been exceeded and the shell hasn't yet been launched...
        if (m_CurrentLaunchForce >= m_MaxLaunchForce && !m_Fired)
        {
            // ... use the max force and launch the shell.
            m_CurrentLaunchForce = m_MaxLaunchForce;

            //try and get a projectile
            Block nextAvailable = linkedInventory.GetFirstBlockWithState(Block.BlockState.ShootingBlock);
            // ... launch the shell.
            if (nextAvailable != null)
            {
                Fire(nextAvailable);
            }
        }
        // Otherwise, if the fire button has just started being pressed...
        else if (Input.GetButtonDown(m_FireButton))
        {
            // ... reset the fired flag and reset the launch force.
            m_Fired = false;
            m_CurrentLaunchForce = m_MinLaunchForce;

            // Change the clip to the charging clip and start it playing.
            //m_ShootingAudio.clip = m_ChargingClip;
            //m_ShootingAudio.Play();
        }
        // Otherwise, if the fire button is being held and the shell hasn't been launched yet...
        else if (Input.GetButton(m_FireButton) && !m_Fired)
        {
            // Increment the launch force and update the slider.
            m_CurrentLaunchForce += m_ChargeSpeed * Time.deltaTime;

            m_PowerSlider.value = m_CurrentLaunchForce;
        }
        // Otherwise, if the fire button is released and the shell hasn't been launched yet...
        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            
            //try and get a projectile
            Block nextAvailable = linkedInventory.GetFirstBlockWithState(Block.BlockState.ShootingBlock);
            // ... launch the shell.
            if (nextAvailable != null)
            {
                Fire(nextAvailable);
            }
            
        }
    }


    private void Fire(Block block)
    {
        // Set the fired flag so only Fire is only called once.
        m_Fired = true;

        //set block state to shot right away so you can't double shoot it
        block.state = Block.BlockState.Shot;
        Rigidbody shellInstance = block.blockObj.GetComponentInChildren<Rigidbody>();

        //move shell
        shellInstance.transform.position = m_FireTransform.position;
        shellInstance.transform.rotation = m_FireTransform.rotation;

        // Set the shell's velocity to the launch force in the fire position's forward direction.
        shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;

        // Change the clip to the firing clip and play it.
        //m_ShootingAudio.clip = m_FireClip;
        //m_ShootingAudio.Play();

        // Reset the launch force.  This is a precaution in case of missing button events.
        m_CurrentLaunchForce = m_MinLaunchForce;

        // play fire sound
        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.fire);
    }
}
