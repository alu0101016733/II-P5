using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private float ballForce_ = 500f;
    private Rigidbody rigidBody_;

    private Vector3 startPosition_;
    // Start is called before the first frame update
    void Start()
    {
        startPosition_ = GetComponent<Transform>().position;
        rigidBody_ = GetComponent<Rigidbody>();
        UIControls.StopAll += StopPlaying;
        UIControls.GameStarted += StartPlaying;
    }

    void StartPlaying() {
        rigidBody_.AddForce(Vector3.forward * ballForce_);
    }

    void StopPlaying() {
        rigidBody_.velocity = Vector3.zero;
        GetComponent<Transform>().position = startPosition_;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("TargetBrick")) {
            Destroy(other.gameObject);
        }
    }
}
