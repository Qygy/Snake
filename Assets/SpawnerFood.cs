using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    public BoxCollider2D foodRange;
    public float score;
    public TextMeshProUGUI snoreNumber;

    private void RandomPosition()
    {
        Bounds bounds = this.foodRange.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RandomPosition();
            score += 1;
        }
    }

    private void Update()
    {
        snoreNumber.text = "Score: " + score;
    }


}
