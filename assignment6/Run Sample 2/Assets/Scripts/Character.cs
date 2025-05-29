using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    const float CharacterJumpPower = 7f;
    const int MaxJump = 2;
    int RemainJump = 0;
    GameManager GM;

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && RemainJump > 0)
        {
            Jump(CharacterJumpPower);
            RemainJump--;
        }
    }

    // Jump with power
    void Jump(float power)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, CharacterJumpPower, 0), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            RemainJump = MaxJump;
        }

        if (col.gameObject.tag == "Obstacle")
        {
            GM.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Point")
        {
            GM.GetPoint(1);
            Destroy(col.gameObject);
        }
    }
}
