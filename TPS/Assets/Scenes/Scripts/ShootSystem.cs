using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public int AmmoCount; // Патронов в обоймах
    public int CurAmmo; // Кол-во патронов
    public int Ammo; // Кол-во патронов в 1ой обойме
    public AudioClip Fire; // Звук выстрела
    public float ShootSpeed; // Скорострельность
    public float ReloadSpeed; // Скорость перезарядки  
    public float ReloadTimer = 0.0f; // Стандартное время перезарядки(не трогать)
    public float ShootTimer = 0.0f; // Стандартное время выстрела(не трогать)
    public Transform bullet; // Наш патрон
    
    void Update()
    {
        {
            if (Input.GetMouseButtonDown(0) & CurAmmo > 0 & ReloadTimer <= 0 & ShootTimer <= 0)
            {
                Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("Spawn").transform.position, Quaternion.identity);
                BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
                CurAmmo = CurAmmo - 1;
                GetComponent<AudioSource>().PlayOneShot(Fire);
                ShootTimer = ShootSpeed;
            }
            if (ShootTimer > 0)
            {
                ShootTimer -= Time.deltaTime;
            }

            {

            }
            if (Input.GetButtonDown("Reload"))
            {
                ReloadTimer = ReloadSpeed;
                CurAmmo = Ammo;
                //GetComponent<AudioSource>().PlayOneShot(Reload);
                {
                    if (ShootTimer > 0)
                    {
                        ShootTimer -= Time.deltaTime;
                    }
                }
            }
        }
        if (ReloadTimer > 0)
        {
            ReloadTimer -= Time.deltaTime;
        }
        {

        }
    }
}
