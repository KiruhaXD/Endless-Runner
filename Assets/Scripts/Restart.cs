using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    public ScoreManager sm;

    private void Start()
    {
        score.text = ("Ваш счёт: ") + sm.score.ToString(); // высвечиваем Какой у нас счет
    }

    private void Update()
    {
        // если у нас нажата клавиша Q, то перезапускаем нашу сцену
        if (Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
