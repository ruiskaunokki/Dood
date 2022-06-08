using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject[] bullet;
    public Transform shotPoint;
    public Sprite[] sprites = new Sprite[3];
    SpriteRenderer weaponSprite;
    public Joystick joystick;
    [SerializeField] FieldOfView fieldOfView;
    private float startTimeBtwShots;
    private float timeBtwShots;
    private int count;
    private int spread;

    void Start() {
        weaponSprite = GameObject.Find("Weapon").GetComponent<SpriteRenderer>();
        count = 1;
        spread = 1;
        startTimeBtwShots = 0.2f;
    }

    void Update()
    {
        Vector3 rotVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
            if (joystick.Horizontal !=0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, rotVector);
            }
        
        fieldOfView.SetAimDirection(transform.rotation *  new Vector3(0, 0, -45));
        fieldOfView.SetOrigin(transform.position);


    }
    void LateUpdate()
    {
        Vector3 rotVector = (Vector3.up * joystick.Horizontal + Vector3.left * joystick.Vertical);
        if (timeBtwShots <= 0){
            if (joystick.Horizontal !=0 || joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, rotVector);
                
                if (count == 2)
                {
                    for (int i = 0; i < 7; ++i)
                    {
                        int rand = Random.Range(-90 - spread, -90 + spread);
                        Quaternion rotZ = transform.rotation * Quaternion.Euler(0, 0, rand);
                        Instantiate(bullet[2], shotPoint.position, rotZ);
                    }
                }
                else
                {
                    int rand = Random.Range(-90 - spread, -90 + spread);
                    Quaternion rotZ = transform.rotation * Quaternion.Euler(0, 0, rand);
                    Instantiate(bullet[count], shotPoint.position, rotZ);
                }
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void ChangeWeapon()
    {
        count++;
        if (count >= 3) count -= 3;
        switch (count)
        {
            case 0: 
            weaponSprite.sprite = sprites[0];
            startTimeBtwShots =  0.1f;
            spread = 0;
            break;
            case 1: 
            weaponSprite.sprite = sprites[1]; 
            startTimeBtwShots =  0.2f;
            spread = 1;
            break;
            case 2: 
            weaponSprite.sprite = sprites[2]; 
            startTimeBtwShots =  0.3f;
            spread = 10;
            break;
        }
    }
}

