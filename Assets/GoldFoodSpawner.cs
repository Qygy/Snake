

using UnityEngine;

public class GoldFoodSpawner : MonoBehaviour
{
    public BoxCollider2D foodRange;
    public float TimeInterval;
    private float TimeSinceLastSpawn;


    private void Start()
    {
        RandomPosition();
    }


void Update()
{
    if ((Time.time - TimeSinceLastSpawn) > TimeInterval)
    {
        RandomPosition();
        TimeSinceLastSpawn = Time.time;
    }
}

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