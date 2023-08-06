using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.gameManager.LapIncrease();
    }
}
