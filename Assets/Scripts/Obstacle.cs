using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2f;

    private int health = 100;

    private Rigidbody obstacleRigidbody;
    private Vector3 directionToPlayer;

    [SerializeField] private GameObject explosion; 


    private void Awake() {
        obstacleRigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        directionToPlayer = (player.position - transform.position).normalized;
        obstacleRigidbody.velocity = directionToPlayer * speed;
    }

    private void Update() {
        if (health <= 0) {
            Death();        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Projectile") {
            Player.AddScore(Random.Range(20, 45));

            health -= Random.Range(30, 46);

            collider.gameObject.GetComponent<Projectile>().Terminate();
            collider.gameObject.GetComponent<Projectile>().GenerateExplosion();
        }
    }

    private void Death() {
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(10, 10, 10);
        Destroy(gameObject);
    }

}
