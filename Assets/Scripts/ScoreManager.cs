using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score; // указываем переменную нашего счета
    public Text scoreDisplay; // переменная для текста, который будет отображаться

    private void Update()
    {
        scoreDisplay.text = score.ToString(); // указываем что наш текст равен нашему счету
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gear"))
            score++; // если наш объект будет сталкиваться с шестиренкой, то мы будем прибавлять наш счет
    }
}
