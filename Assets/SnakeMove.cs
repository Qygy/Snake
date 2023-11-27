using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D RigidBody;
    public Transform snakePrefab;
    private List<Transform> _addSnake;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.velocity = new Vector2 (Speed, 0);
        _addSnake = new List<Transform>();
        _addSnake.Add(this.transform);
    }

    private void FixedUpdate()
    {
        for (int i = _addSnake.Count - 1; i > 0; i--)
        {
            _addSnake[i].position = _addSnake[i - 1].position;
        }
    }

    private void grow()
    {
        Transform addSnake = Instantiate(this.snakePrefab);
        addSnake.position = _addSnake[_addSnake.Count - 1].position;
        _addSnake.Add (addSnake);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            grow();
            grow();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        /*else if  (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            RigidBody.velocity = new Vector2 (0, Speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            RigidBody.velocity = new Vector2(0, -Speed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RigidBody.velocity = new Vector2(Speed, 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RigidBody.velocity = new Vector2(-Speed, 0);
        }
    }
}
