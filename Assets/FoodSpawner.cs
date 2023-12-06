using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class FoodSpawner : MonoBehaviour
{
    public BoxCollider2D foodRange;
    
    private void RandomPosition()
    {
        Bounds bounds = this.foodRange.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.GetComponent<SnakeMover>() != null)
        {
            RandomPosition();
        }
    }
}
