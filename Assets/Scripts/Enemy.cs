using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject HB;
    HealthBar hb;
    Controller player;
    public int health;
    public int damage;
    public float speed;
    int currentHealth;
    
    void Start() 
    {
        player = GameObject.Find("Player").GetComponent<Controller>();
        currentHealth = health;
        hb = HB.GetComponent<HealthBar>();
        hb.SetMaxHealth(health);
        hb.SetHealth(currentHealth);
    }
    
    void Update() 
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, GameObject.Find("Player").transform.position);
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) <= 10f)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);
        }
        if (currentHealth <= 0)
        {
            HB.SetActive(false);
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            player.DealDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hb.SetHealth(currentHealth);
    }
}
