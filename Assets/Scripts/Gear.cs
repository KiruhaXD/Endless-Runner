using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gear : MonoBehaviour
{
    public int damage = 1; // шестеренка наносит один урон
    public float speed;

    public GameObject effect;
    public GameObject sound;

    private Animator camAnim;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    public void Update()
    {
        transform.Translate(Vector2.left * speed);
    }

    // данная функция будет работать именно при столкновении с игроком
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            camAnim.SetTrigger("shake");
            Instantiate(sound, transform.position, Quaternion.identity); // с помощью Instantiate звук проигрывается полностью
            Instantiate(effect, transform.position, Quaternion.identity);
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }
}
