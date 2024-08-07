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

    private int imageCounter;
    private string playerSpecialType;
    private string playerSpecialBoolean;

    private void Start()
    {
        imageCounter = 0;
        HandleUI();
    }

    public void HandleUI()
    {
        playerMPText.text = ("Money: " + player.playerMP.ToString());
        playerCPText.text = ("Candy: " + player.playerCP.ToString());
        playerSpecialText.text = ("Special: " + player.specialActive.ToString());

        if (player.playerHP < 3)
        {
            HandleHearts();
        }
        

    }

    private void HandleHealing()
    {
        if(player.playerHP < 3 && imageCounter > 0)
        {
            player.playerHP++;
            imageCounter--;
            hpImages[imageCounter].SetActive(true);
            Debug.Log("Health image handled!: " + imageCounter + " Health handled;" + player.playerHP );

        }

    }

    private void HandleHearts()
    {
        if (imageCounter < 3 && imageCounter > 0)
        {
            hpImages[imageCounter].SetActive(false);
            imageCounter++;
        }

        if (player.playerHP < 0)
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
