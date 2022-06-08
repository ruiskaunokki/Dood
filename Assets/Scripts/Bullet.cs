using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask Solid;
    
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, Solid);
        if (hitInfo.collider != null)
        {
            if ((transform.position * new Vector2(1, 1)) == hitInfo.point){
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                }
                Destroy(gameObject);
            }        
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (lifetime >= 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
