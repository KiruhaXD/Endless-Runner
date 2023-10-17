using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos; // задаем целевую позицию
    public float Yincrement; // отклонение по Y

    public float speed;

    // создаем переменные чтобы игрок не заходил за границы экрана
    public float maxHeight; 
    public float minHeight;

    public int health = 5; // 5 жизней

    public GameObject effect;
    public Text displayHealth; // переменная для текста со здоровьем

    public GameObject panel;
    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    private void Update()
    {
        displayHealth.text = health.ToString();

        if (health <= 0)
        {
            panel.SetActive(true); // когда у персонажа заканчивается здоровье ее активируем
            Destroy(gameObject);
        }

        // делаем передвижение игрока плавнее
        transform.position = Vector2.MoveTowards(transform.position, targetPos,speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            // позиция игрока плюс отклонение по Y
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }

        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}
