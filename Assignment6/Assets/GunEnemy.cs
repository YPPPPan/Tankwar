using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    private const float FireCooldown = 1f;
    private float _lastfire;
    private Transform _tr;
    public static BulletManager Bullets;
    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
        Bullets = new BulletManager();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fire();
    }

    public void Fire()
    {
        float time = Time.time;
        if (time < _lastfire + FireCooldown) { return; }
        _lastfire = time;
        Bullets.BulletGenerator(_tr.position, _tr.rotation,0);
        var attackMusic = GetComponents<AudioSource>();
        attackMusic[0].PlayOneShot(attackMusic[0].clip);
    }
}


