using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    // переменные с конечной до начальной точки движения фона
    public float endX; 
    public float startX;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // двигаем наш фон влево

        // если наш фон прокуртился до конца по x
        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y); // то начинаем движение фона со стартовой точки
            transform.position = pos;

        }
    }
}
