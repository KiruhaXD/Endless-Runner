using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos; // ������ ������� �������
    public float Yincrement; // ���������� �� Y

    public float speed;

    // ������� ���������� ����� ����� �� ������� �� ������� ������
    public float maxHeight; 
    public float minHeight;

    public int health = 5; // 5 ������

    public GameObject effect;
    public Text displayHealth; // ���������� ��� ������ �� ���������

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
            panel.SetActive(true); // ����� � ��������� ������������� �������� �� ����������
            Destroy(gameObject);
        }

        // ������ ������������ ������ �������
        transform.position = Vector2.MoveTowards(transform.position, targetPos,speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            // ������� ������ ���� ���������� �� Y
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
