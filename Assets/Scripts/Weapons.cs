using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons 
{
   private string name;
   private float damage;

    private float bulletSpeed;

    //Explicitly Defined Constructor
    public Weapons()
    {
        
    }
    
    
    
    //Explicity Defined Constructor Override
    public Weapons(string _name, float _damage, float _bulletSpeed)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
    }

    public void Shoot(GameObject _bullet, PlayableObject _player, string _targettag, float _timeToDie)
    {
        GameObject tempBullet = GameObject.Instantiate(_bullet, _player.transform.position, _player.transform.rotation);
        tempBullet.GetComponent<Bullet>().SetBullet(damage, bulletSpeed);

        //GameObject.Destroy(tempBullet, _timeToDie);

    }



}
