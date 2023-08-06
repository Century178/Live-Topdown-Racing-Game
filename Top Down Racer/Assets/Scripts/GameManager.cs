using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] private float lapTotal;
    public float lapCount;

    private void Awake()
    {
        if (gameManager != null) Destroy(gameObject);
        else gameManager = this;

        lapCount = 0;
    }

    public void LapIncrease()
    {
        lapCount++;

        if (lapCount > lapTotal) Victory();
    }

    private void Victory()
    {
        Debug.Log("You win!");
    }
}
