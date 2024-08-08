using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int playerHP = 3;
    [SerializeField] public int playerMP = 0;
    [SerializeField] public int playerCP = 0;
    [SerializeField] public int playerMulti = 1;

    private bool isInvincible;
    public Movement movement;
    public UIHandler handler;
    public bool specialActive;

    // Start is called before the first frame update
    private void Start()
    {
        specialActive = false;
        isInvincible = false;
    }
    public void IncreaseCoin(int amount)
    {
        SoundEffectManager.Play("Coins");
        playerCP += amount;
        handler.HandleUI();
        Debug.Log("Coin increased by: " + amount);
    }

    public void IncreaseMoney(int amount)
    {
        SoundEffectManager.Play("Money");
        playerMP += amount;
        handler.HandleUI();
        Debug.Log("Money increased by: " + amount);
    }

    public void ActivateSpecial()
    {
        SoundEffectManager.Play("PowerUps");
        specialActive = true;
        handler.HandleUI();
        Debug.Log("Special activated");
    }

    public void TakeDamage(int amount)
    {
        SoundEffectManager.Play("Hazard");

        if (isInvincible == false && playerHP > 0) 
        {
            playerHP -= amount;

            handler.hitCheck = true;
            handler.HandleUI();
            Debug.Log("Health decreased by: " + amount + "Total HP: " + playerHP);
            StartInvincibility();
        }



    }

    public void HealDamage()
    {
        handler.HandleHealing();
    }

    public void SpeedUp()
    {
        StartCoroutine(TempSpeed());
    }

    public void StartInvincibility()
    {
        StartCoroutine(TempInvincible());
    }

    private IEnumerator TempSpeed()
    {
        movement.moveSpeed = 6.5f;
        Debug.Log("Movement speed changed: " + movement.moveSpeed);
        yield return new WaitForSeconds(5);
        movement.moveSpeed = 5.0f;
        Debug.Log("Movement speed changed back!: " + movement.moveSpeed);
    }

    private IEnumerator TempInvincible()
    {
        isInvincible = true;
        Debug.Log("Invincibility changed!: " + isInvincible);
        yield return new WaitForSeconds(3);
        isInvincible = false;
        Debug.Log("Invincibility changed!: " + isInvincible);
    }

}
