using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = -3;
    private string moveDir = "left";
    private float count = 0;
    public float distance = 600;

    public int health = 100;
    public GameObject deathEffect;

    void Update()
    {
        count++;
        Move();
    }

    void TurnRight()
    {
        moveDir = "right";
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void TurnLeft()
    {
        moveDir = "left";
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void Move()
    {
        if (count == distance && moveDir == "right")
        {
            count = 0;
            TurnLeft();
        }

        if (count == distance && moveDir == "left")
        {
            count = 0;
            TurnRight();
        }

        transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
