using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 40f;
    [SerializeField] private float mouseRotationSpeed = 20f;

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform gunPos1;
    [SerializeField] private Transform gunPos2;

    public static int score = 0;
    
    private Rigidbody spaceshipRigidbody;

    private Vector2 screenCenter, mousePosition, lookInput;

    private void Awake() {
        spaceshipRigidbody = GetComponent<Rigidbody>();
        screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    }

    private void Update() {
        float rotateInputY = Input.GetAxis("Vertical");
        float rotateInputX = Input.GetAxis("Horizontal");

        lookInput = Input.mousePosition;
        mousePosition.x = (lookInput.x - screenCenter.x)/screenCenter.x;
        mousePosition.y = (lookInput.y - screenCenter.y)/screenCenter.y;


        Quaternion rotation = Quaternion.Euler(-1 * rotateInputY * rotationSpeed * Time.deltaTime, rotateInputX * rotationSpeed * Time.deltaTime, 0f);
        spaceshipRigidbody.MoveRotation(spaceshipRigidbody.rotation * rotation);

        Quaternion mouseRotation = Quaternion.Euler(-mousePosition.y * mouseRotationSpeed * Time.deltaTime, mousePosition.x * mouseRotationSpeed * Time.deltaTime, 0f);
        spaceshipRigidbody.MoveRotation(spaceshipRigidbody.rotation * mouseRotation);

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(projectilePrefab, gunPos1.position, transform.rotation);
            Instantiate(projectilePrefab, gunPos2.position, transform.rotation);
            audioSource.Play();
        }

        if (Input.GetKeyDown("a")) {
            ScreenCapture.CaptureScreenshot(Random.Range(99999, 9999999).ToString() + ".png");
        }
    }

    public static void AddScore(int scoreToAdd) {
        score += scoreToAdd;
        Debug.Log(score);
    }

    public static int GetScore() {
        return score;
    }

    public static void SetScore(int scoreToSet) {
        score = scoreToSet;
    }

    private void FixedUpdate() {
        Vector3 movement = transform.forward * speed;
        spaceshipRigidbody.velocity = movement;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            Death();
            Invoke ("Terminate", 2);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Coin") {
            collider.gameObject.GetComponent<CoinCollectible>().Terminate();
            score += Random.Range(80, 101);
            
        }
    }

    private void Terminate() {
        Destroy(gameObject);
        GameManager.instance.GameOver();
    }

    private void Death() {
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();
        speed = 0;
        rotationSpeed = 0;
        mouseRotationSpeed = 0;
    }

}
