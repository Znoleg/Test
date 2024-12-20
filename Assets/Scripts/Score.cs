using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Юзинги чистим, комментарии не оставляем
public class Score : MonoBehaviour
{
    [SerializeField] private int coins;
    //[SerializeField] private TextMeshPro coinsText;
    [SerializeField] private TextMeshProUGUI coinsText;

    //Свойство нигде не используется, убрать
    public int Coins { get; private set; }

    public void AddOne()
    {
        coins++;
        coinsText.text = coins.ToString();
    } 
}
