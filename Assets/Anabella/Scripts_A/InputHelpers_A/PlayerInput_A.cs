using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput_A : MonoBehaviour
{
    private Player_A player;//updated to call PLayer_A
    private float horizontal, vertical;
    private Vector2 lookTarget;

    //added variables
    private bool gunPickupCooldown;
    private float gunPickupCooldownTime = 4f;
    [SerializeField] private Image gunPickupImg;
    private float timer;
    private float pickupShootingInterval = 0.2f;

    //added subscriptions to events
    private void OnEnable()
    {
        GameEvents.CollectGunPowerup += ActivateGunPowerup;
    }

    private void OnDisable()
    {
        GameEvents.CollectGunPowerup -= ActivateGunPowerup;
    }

    
    void Start()
    {
        player = GetComponent<Player_A>();
    }

    
    //Changed to check if the game is active and interact with powerups
    //keeping track of cooldown on pickup Gun with a visual feedback
    //firing if has any nuke pickup collected
    void Update()
    {
        if (GameManager_A.GetInstance().isGameActive)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            lookTarget = Input.mousePosition;


            if (Input.GetMouseButtonDown(0))
            {
                player.Shoot(Vector3.zero, 0f);
            }

            if (gunPickupCooldown)
            {
                timer += Time.deltaTime;

                if (Input.GetMouseButton(0) && timer >= pickupShootingInterval)
                {
                    player.Shoot(Vector3.zero, 0f);
                    timer = 0f;
                }

                gunPickupImg.fillAmount -= 1f / gunPickupCooldownTime * Time.deltaTime;
                if (gunPickupImg.fillAmount == 0)
                {
                    gunPickupCooldown = false;
                    gunPickupImg.fillAmount = 1;
                    gunPickupImg.gameObject.SetActive(false);
                }
            }


            if (Input.GetMouseButtonDown(1) && GameManager_A.GetInstance().uiManager.NukePowerupCount > 0)
            {
                GameEvents.ActivateNukePowerUp?.Invoke();
            }
        }

    }


    private void FixedUpdate()
    {
        if (GameManager_A.GetInstance().isGameActive)
        {
            player.Move(new Vector2(horizontal, vertical), lookTarget);
        }
    }


    //new method
    private void ActivateGunPowerup()
    {
        gunPickupCooldown = true;
        gunPickupImg.gameObject.SetActive(true);
    }

}
