using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelLoader : MonoBehaviour
{
 
    void Start()
    {      //Creates Player
        Player player = new Player();

        //Creates Enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        Enemy.SubtractEnemy();


        Debug.Log(Enemy.numberOfEnemies);


        //Creates Weapons
        Weapon gun1 = new Weapon();
      ///  Weapon gun2 = new Weapon("Lazer", 100.0f);

        // Enums
        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;

        EnemyType enemyType2 = EnemyType.MachineGunner;

        //Distripute Weapons
        player.weapon = gun1;

      //  enemy1.weapon = gun2;
       // enemy2.weapon = gun2;

      


        

    }
 
}
