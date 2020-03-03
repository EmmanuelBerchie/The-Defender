using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI healthText;
    Player player;
    int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int playerHealth = player.GetHealth(); // local variable

        // Terminate the method immediately if the playerHealth value hasn't changed
        if (this.playerHealth == playerHealth) return;

        if (playerHealth <= 0)
        {
            healthText.text = "0";

        }
        else
        {
            healthText.text = playerHealth.ToString();
        }

        this.playerHealth = playerHealth;
    }



}
 