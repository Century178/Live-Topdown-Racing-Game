using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [Header("Lapping")]
    [SerializeField] private float lapTotal;
    public float lapCount;
    public float oppLapCount;
    [SerializeField] private TextMeshProUGUI lapText;

    [Header("Other")]
    [SerializeField] private TextMeshProUGUI placeText;

    private void Awake()
    {
        if (gameManager != null) Destroy(gameObject);
        else gameManager = this;

        lapCount = 0;
    }

    public void LapIncrease()
    {
        lapCount++;

        if (lapCount > lapTotal) Victory(true);
        else lapText.text = "Lap " + lapCount.ToString();
    }

    public void OppLapIncrease()
    {
        oppLapCount++;

        if (oppLapCount > lapTotal) Victory(false);
    }

    private void Victory(bool playerWon)
    {
        if (playerWon) placeText.text = "You Win!";
        else placeText.text = "You Lose!";
    }
}
