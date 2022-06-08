using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Controller player;
    public int health;
    public float speed;
    public int damage;
    
    void Start() 
    {
        player = GameObject.Find("Player").GetComponent<Controller>();
    }
    
    void Update() 
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            player.DealDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
