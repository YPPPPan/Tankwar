using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Transform _tr;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        _tr.Translate(new Vector3(0, Input.GetAxis("Vertical") / 10, 0));
        _tr.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal")));
    }

    internal void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "BulletEnemy(Clone)")
        {
            var attackMusic = FindObjectOfType<Canvas>().GetComponents<AudioSource>();
            attackMusic[1].PlayOneShot(attackMusic[1].clip);
            int i = FindObjectOfType<Gun>().LevelDown();
            Destroy(other.gameObject);
            if (i == 0)
            {
                Object _menu = Resources.Load("Menu");
                GameObject menu = (GameObject)Object.Instantiate(_menu, new Vector3(0, 0, 0), new Quaternion());
                menu.GetComponent<Menu>().Initialize(0);
                Time.timeScale = 0;
            }
        }
    }
}
