using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float velocity;
    private Transform _tr;
    // Start is called before the first frame update
    public void Initialize()
    {
        velocity = 0.2f;
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _tr.Translate(new Vector3(0, velocity, 0));
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Bullet(Clone)" && gameObject.name == "BulletEnemy(Clone)")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.name == "Bullet1(Clone)" && gameObject.name == "BulletEnemy(Clone)")
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.name == "Bullet2(Clone)" && gameObject.name == "BulletEnemy(Clone)")
        {
            Destroy(gameObject);
        }

        else if (other.gameObject.name == "Cheese" && gameObject.name == "BulletEnemy(Clone)")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            Object _menu = Resources.Load("Menu");
            GameObject menu = (GameObject)Object.Instantiate(_menu, new Vector3(0, 0, 0), new Quaternion());
            menu.GetComponent<Menu>().Initialize(0);
            Time.timeScale = 0;
        }
    }
}
