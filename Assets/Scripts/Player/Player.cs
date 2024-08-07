using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int playerHP = 3;
    [SerializeField] public int playerMP = 0;
    [SerializeField] public int playerCP = 0;
    [SerializeField] public int playerMulti = 1;

    public UIHandler handler;
    public bool specialActive;
    // Start is called before the first frame update
    private void Start()
    {
        specialActive = false;
    }
    public void IncreaseCandy(int amount)
    {
        playerCP += amount;
        handler.HandleUI();
        Debug.Log("Candy increased by: " + amount);
    }

    public void IncreaseMoney(int amount)
    {
        playerMP += amount;
        handler.HandleUI();
        Debug.Log("Money increased by: " + amount);
    }

    public void ActivateSpecial()
    {
        specialActive = true;
        handler.HandleUI();
        Debug.Log("Special activated");
    }

    public void TakeDamage(int amount)
    {
        playerHP -= amount;
        handler.HandleUI();
        Debug.Log("Health decreased by: " + amount);
    }
}
