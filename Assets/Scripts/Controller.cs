using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 moveVelocity;
    public Joystick joystick;
    public Joystick fireJoystick;
    public float speed;
    public int health;
    public int spawnTimer;
    float timer;
    public int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = health;
        timer = spawnTimer;
    }

    void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;
        Vector3 moveVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (fireJoystick.Horizontal == 0 || fireJoystick.Vertical == 0)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            }
        }
        if (currentHealth <= 0)
        {
            Debug.Log("Игрок умер");
            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
    }
}
