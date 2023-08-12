using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private float lapTotal;
    public float lapCount;
    public float oppLapCount;
    [SerializeField] private TextMeshProUGUI lapText;

    [SerializeField] private bool playerWon;

    private void Awake()
    {
        if (gameManager != null) Destroy(gameObject);
        else gameManager = this;

        lapCount = 0;
    }

    public void LapIncrease()
    {
        lapCount++;

        if (lapCount > lapTotal)
        {
            playerWon = true;
            Victory();
        }
        else lapText.text = "Lap " + lapCount.ToString();
    }

    public void OppLapIncrease()
    {
        if (!playerWon)
        {
            oppLapCount++;

            if (oppLapCount > lapTotal) Victory();
        }
    }

    private void Victory()
    {
        if (playerWon) lapText.text = "You Win!";
        else lapText.text = "You Lose!";
    }
}
