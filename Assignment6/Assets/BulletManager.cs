using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager
{
    // Start is called before the first frame update
    private Transform holder;
    private Object _bullet;

    public BulletManager()
    {
        holder = GameObject.Find("Bullets").transform;
    }
    
    public void BulletGenerator(Vector3 Position, Quaternion rotate, int level)
    {
        if (level == 1)
            _bullet = Resources.Load("Bullet");
        else if (level == 0)
            _bullet = Resources.Load("BulletEnemy");
        else if (level == 2)
            _bullet = Resources.Load("Bullet1");
        else if (level == 3)
            _bullet = Resources.Load("Bullet2");
        GameObject bullet = (GameObject)Object.Instantiate(_bullet, Position, rotate);
        bullet.GetComponent<Bullet>().Initialize();
        bullet.GetComponent<Transform>().parent = holder;
    }
}
