using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int coins;
    //[SerializeField] private TextMeshPro coinsText;
    [SerializeField] private TextMeshProUGUI coinsText;

    public void AddOne()
    {
        coins++;
        coinsText.text = coins.ToString();
    } 
}
