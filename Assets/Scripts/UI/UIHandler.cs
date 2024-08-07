using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMPText;
    [SerializeField] private TextMeshProUGUI playerCPText;
    [SerializeField] private TextMeshProUGUI playerSpecialText;
    [SerializeField] public GameObject[] hpImages;
    [SerializeField] public Player player;

    public bool hitCheck;
    private int imageCounter;
    private string playerSpecialType;
    private string playerSpecialBoolean;

    private void Start()
    {
        hitCheck = false;
        imageCounter = 0;
        HandleUI();
    }

    public void HandleUI()
    {
        playerMPText.text = ("Money: " + player.playerMP.ToString());
        playerCPText.text = ("Coin: " + player.playerCP.ToString());
        playerSpecialText.text = ("Special: " + player.specialActive.ToString());

        if (hitCheck == true)
        {
            HandleHearts();
            Debug.Log("HandleHearts() CALLED from If player.playerHP < 3");
        }
        

    }

    private void HandleHealing()
    {
        if(player.playerHP < 3 && imageCounter > 0 && hitCheck == true)
        {
            player.playerHP++;
            imageCounter--;
            hpImages[imageCounter].SetActive(true);
            Debug.Log("Health image handled!: " + imageCounter + " Health handled;" + player.playerHP );
            hitCheck = false;
        }

    }

    private void HandleHearts()
    {
        Debug.Log("HandleHearts() Entered successfully");
        if (imageCounter < 3 && player.playerHP > 0)
        {
            hpImages[imageCounter].SetActive(false);
            imageCounter++;
            hitCheck = false;
        }

        if (player.playerHP <= 0)
        {
            HandleDeath();
        }
    }

    public void HandleDeath()
    {
        Debug.Log("You Lost/:");
        SceneManager.LoadScene("Main Menu");
    }
}
