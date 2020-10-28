using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _tr;
    private float _lastMove;
    private float _lastRotate;
    private const float MoveCooldown = 5f;
    float y;
    float x;
    int flag = 0;
    float rotat = 0;
    System.Random rm;
    // Start is called before the first frame update
    public void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
        rm = new System.Random();
        _lastMove = Time.time;
        _lastRotate = Time.time;
        y = 300 * ((float)rm.NextDouble() - 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time - _lastMove;
        _lastMove = Time.time;
        if (flag == 0)
            Move(time);
        else
            Rotate(time);
    }

    private void Move(float gap)
    {
        x = (float)rm.NextDouble();
        _tr.Translate(new Vector3(0, x * gap * 5, 0));
    }


    private void Rotate(float gap)
    {
        x = -0.1f;
        _tr.Translate(new Vector3(0, x * gap, 0));
        if (rotat > 90f) {
            flag = 0;
            rotat = 0;
            return;
        }
        rotat += gap * 50;
        if (y > 0.8f)
        {
            _tr.Rotate(new Vector3(0, 0, gap * 50));
        }
        else
        {
            _tr.Rotate(new Vector3(0, 0, -gap * 50));
        }
    }

    internal void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Tilemap (2)" || other.gameObject.name == "Tilemap (1)" || other.gameObject.name == "Tilemap" || other.gameObject.name == "Enemy(Clone)")
        {
            if(flag == 0)
                y = (float)rm.NextDouble();
            flag = 1;
        }
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet(Clone)" || other.gameObject.name == "Bullet1(Clone)")
        {
            var attackMusic = FindObjectOfType<Canvas>().GetComponents<AudioSource>();
            attackMusic[0].PlayOneShot(attackMusic[0].clip);
            Destroy(gameObject);
            Destroy(other.gameObject);
            FindObjectOfType<Score>().AddScore();
            FindObjectOfType<Gun>().Kill();
        }

        else if (other.gameObject.name == "Bullet2(Clone)")
        {
            var attackMusic = FindObjectOfType<Canvas>().GetComponents<AudioSource>();
            attackMusic[0].PlayOneShot(attackMusic[0].clip);
            Destroy(gameObject);
            FindObjectOfType<Score>().AddScore();
        }

        else if (other.gameObject.name == "Cheese")
        {
            Destroy(other.gameObject);
            Object _menu = Resources.Load("Menu");
            GameObject menu = (GameObject)Object.Instantiate(_menu, new Vector3(0, 0, 0), new Quaternion());
            menu.GetComponent<Menu>().Initialize(0);
            Time.timeScale = 0;
        }
    }
}
