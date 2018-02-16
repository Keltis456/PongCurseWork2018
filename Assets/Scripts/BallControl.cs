using UnityEngine;

public class BallControl : MonoBehaviour {

    Vector2 velocity;
    Collision2D lastCollision;

	void Start () {
        var randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            velocity = new Vector2(8, 1);
        }
        else
        {
            velocity = new Vector2(-8, -1);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + velocity.x * Time.deltaTime, transform.position.y + velocity.y * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.name);
        if (lastCollision == collision) return;
        lastCollision = collision;

        if (collision.collider.tag == "Player")
        {
            velocity = new Vector2(-velocity.x, velocity.y);
        }
        if (collision.collider.tag == "Wall")
        {
            if (collision.collider.name == "topWall" || collision.collider.name == "bottomWall")
            {
                velocity = new Vector2(velocity.x, -velocity.y);
            }
            if (collision.collider.name == "leftWall" || collision.collider.name == "rightWall")
            {
                velocity = new Vector2(-velocity.x, velocity.y);
                GameManager.instance.Score(collision.collider.name);
            }
        }
    }
}
