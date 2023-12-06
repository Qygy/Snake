using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D RigidBody;
    public Transform snakePrefab;
    private List<Transform> _SnakeTiles;
    private int score;
    public TextMeshProUGUI snoreNumber;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.velocity = new Vector2(Speed, 0);
        _SnakeTiles = new List<Transform>();
        _SnakeTiles.Add(this.transform);
    }
    private void FixedUpdate()
    {
        for (int i = _SnakeTiles.Count - 1; i > 0; i--)
        {
            _SnakeTiles[i].position = _SnakeTiles[i - 1].position;
        }
    }

    private void grow()
    {
        Transform addSnake = Instantiate(this.snakePrefab);
        addSnake.position = _SnakeTiles[_SnakeTiles.Count - 1].position;
        _SnakeTiles.Add(addSnake);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.GetComponent<Food>() != null)
        {
            grow();
            Speed = Speed * 1.01f;
            score += 1;
            snoreNumber.text = "Score: " + score;
        }

        if (collidedObject.GetComponent<GoldFood>() != null)
        {
            grow();
            grow();
            grow();
            grow();
            grow();
            Speed = Speed * 1.05f;
            score += 5;
            snoreNumber.text = "Score: " + score;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.GetComponent<Wall>() != null)
        {
            GameManager.instance.Lose();
            Time.timeScale = 0;
        }
        if (collidedObject.GetComponent<SnakeTail>() != null)
        {
            GameManager.instance.Lose();
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                RigidBody.velocity = Vector2.up * Speed;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                RigidBody.velocity = -Vector2.up * Speed;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                RigidBody.velocity = Vector2.right * Speed;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                RigidBody.velocity = -Vector2.right * Speed;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
    }
}
