using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] gearVariants;

    private float timeBtwSpawn; // временной интервал между появлениями двух шестиренок
    public float startTimeBtwSpawn; // стартовый интервал
    public float decreaseTime; // время уменьшения, то есть насколько быстро наши шестеренки будут сужаться
    public float minTime = 0.65f;// минимальное время, то есть меньше которого шестеренки не будут сужаться уже

    private void Update()
    {
        // если у нас интервал кончился
        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, gearVariants.Length); // функция Range генерирует от 0 до количества наших вариантов шестеренок

            // то появляется шестеренка, в исходной позиции и без вращения
            Instantiate(gearVariants[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn; // интервал у нас снова становится стартовым

            if (startTimeBtwSpawn > minTime)
                startTimeBtwSpawn -= decreaseTime;
        }
        else
            timeBtwSpawn -= Time.deltaTime;
    }

}