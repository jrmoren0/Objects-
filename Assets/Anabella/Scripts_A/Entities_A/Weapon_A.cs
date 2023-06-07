using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_A : MonoBehaviour
{
    private string name;
    private float damage;
    private float bulletSpeed;

    //Added variable
    private float bulletInterval;

    //Explicity Defined Constructor
    public Weapon_A() { }

    //Explicity Defined Constructor Override
    public Weapon_A(string _name, float _damage, float _bulletSpeed)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }


    //change variable GameObject to Bullet_A type
    //Uncomment the destroy after some time
    public void Shoot(Bullet_A _bullet, PlayableObject _player, string _targettag, float _timeToDie)//targettag is reference to enemy
    {
        Bullet_A tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        tempBullet.SetBullet(damage, bulletSpeed, _targettag);

        GameObject.Destroy(tempBullet.gameObject, _timeToDie);
    }
}
