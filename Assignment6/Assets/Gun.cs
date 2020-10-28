using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private const float FireCooldown = 1f;
    private float _lastfire;
    private Transform _tr;
    private int level;
    private int kill;
    public static BulletManager Bullets;
    // Start is called before the first frame update
    void Start()
    {
        _tr = GetComponent<Transform>();
        Bullets = new BulletManager();
        level = 1;
        kill = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();
        if (Input.GetAxis("Fire1") != 0)
        {
            Fire();
        }
    }

    private void HandleInput()
    {
        _tr.Translate(new Vector3(-1f * Mathf.Sin(Mathf.PI *( Input.GetAxis("Fire2")- Input.GetAxis("Fire3")) / 720),0, 0));
        _tr.Rotate(new Vector3(0, 0, Input.GetAxis("Fire2")- Input.GetAxis("Fire3")));
    }

    public void Fire()
    {
        float time = Time.time;
        if (time < _lastfire + FireCooldown) { return; }
        _lastfire = time;
        Bullets.BulletGenerator(_tr.position, _tr.rotation, level);
        var attackMusic = GetComponents<AudioSource>();
        attackMusic[0].PlayOneShot(attackMusic[0].clip);
    }

    public void Kill()
    {
        kill++;
        if(kill == 5)
        {
            LevelUp();
            kill = 0;
        }
    }

    private void LevelUp()
    {
        var attackMusic = FindObjectOfType<Canvas>().GetComponents<AudioSource>();
        attackMusic[2].PlayOneShot(attackMusic[2].clip);
        if (level < 3)
            level++;
    }

    public int LevelDown()
    {
        level--;
        if (level == 0)
            return 0;
        else
            return 1;
    }
}
