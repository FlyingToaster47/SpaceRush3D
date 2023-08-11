using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour {
    [SerializeField] private int rotateSpeed = 100;

    private void Update() {
        Vector3 rotation = transform.eulerAngles;
        rotation.z += rotateSpeed * Time.deltaTime;

        transform.eulerAngles = rotation;
    }

    public void Terminate() {
        Destroy(gameObject);
    }
}
