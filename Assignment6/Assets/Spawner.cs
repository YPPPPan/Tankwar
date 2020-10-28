using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int remainEnemies;
    private float _lastSpawn;
    private float spawnCooldown;
    System.Random rm;
    private Transform holder;
    private Object _enemy;
    // Start is called before the first frame update
    void Start()
    {
        remainEnemies = 50;
        _lastSpawn = Time.time;
        spawnCooldown = 3f;
        rm = new System.Random();
        _enemy = Resources.Load("Enemy");
        holder = GameObject.Find("Enemies").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > _lastSpawn + spawnCooldown && remainEnemies > 0)
        {
            remainEnemies -= 1;
            _lastSpawn = Time.time;
            if(remainEnemies == 25)
            {
                spawnCooldown = 2f;
            }
            else if(remainEnemies == 10)
            {
                spawnCooldown = 1f;
            }
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        double a = rm.NextDouble();
        Vector3 pos = new Vector3();
        Quaternion rot = new Quaternion();
        if(a < 0.4)
        {
            pos = new Vector3(10, 0, 0);
            rot.eulerAngles = new Vector3(0, 0, 90);
        }
        else if(a >= 0.4 && a < 0.7)
        {
            pos = new Vector3(0, -4, 0);
            rot.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (a >= 0.7)
        {
            pos = new Vector3(0, 4, 0);
            rot.eulerAngles = new Vector3(0, 0, 180);
        }
        GameObject enemy = (GameObject)Object.Instantiate(_enemy, pos, rot);
        enemy.GetComponent<Enemy>().Initialize();
        enemy.GetComponent<Transform>().parent = holder;
    }
}
