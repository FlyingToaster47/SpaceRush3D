using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private float bulletSpeed;

    private Vector3 direction;

    [SerializeField] private GameObject explosionParticles;

    private void Start() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        direction = (worldPosition - transform.position).normalized;

        Invoke("Terminate", 50);
    }

    private void Update() {
        transform.position += direction * bulletSpeed * Time.deltaTime;
    }

    public void Terminate() {
        Destroy(gameObject);
    }

    public void GenerateExplosion() {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        explosionParticles.transform.localScale = new Vector3(3, 3, 3);
    }

}
