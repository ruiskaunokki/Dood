using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ult : MonoBehaviour
{
    public LayerMask Solid;
    public int UltNumber;
    public int damage;
    public int distance;
    public int range;
    public float lifetime;
    public float speed;

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, Solid);
        if (hitInfo.collider != null)
        {
            if ((transform.position * new Vector2(1, 1)) == hitInfo.point)
            {
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            switch (UltNumber)
            {
                case 0:
                Ult0(other);
                break;
                case 1:
                Ult1(other);
                break;
                case 2:
                Ult2(other);
                break;
                case 3:
                Ult3(other);
                break;
                default:
                break;
            }
        }
    }

    void Ult0(Collider2D smb)
    {
        smb.GetComponent<Enemy>().TakeDamage(damage);
        int i = 2;
        float timer = 3f;
        if (smb != null)
        {
            while (i > 0)
            {
                if (i == Mathf.Round(timer)) 
                {
                    if (smb != null)
                    {
                        i--;
                        smb.GetComponent<Enemy>().TakeDamage(1);
                    }
                    else
                    {
                        break;
                    }
                }
                timer -= Time.deltaTime;
            }
        }
    }

    void Ult1(Collider2D smb)
    {
        smb.GetComponent<Enemy>().TakeDamage(damage);
        if (smb != null)
        {
            float speed = smb.GetComponent<Enemy>().speed;
            smb.GetComponent<Enemy>().speed = smb.GetComponent<Enemy>().speed - 1.5f;
            for (float i = 1; i > 0; i -=Time.deltaTime)
            {
                Debug.Log(smb.GetComponent<Enemy>().speed);
            }
            smb.GetComponent<Enemy>().speed = speed;
            Debug.Log(smb.GetComponent<Enemy>().speed);
        }
    }

    void Ult2(Collider2D smb)
    {
        smb.GetComponent<Enemy>().TakeDamage(damage);
    }

    void Ult3(Collider2D smb)
    {
        smb.gameObject.transform.position += transform.rotation * new Vector3(1, 1, 0);
        smb.GetComponent<Enemy>().TakeDamage(damage);
    }
}
