using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControler : MonoBehaviour
{
    private float keydownSpeed_ = 0.05f;
    private float stepSize_ = 0.5f;
    private float leftLimit_ = -5f;
    private float rightLimit_ = 5f;

    private float timePassedLastKeydown_ = 0f;

    private Transform tf_;
    // Start is called before the first frame update
    void Start()
    {
        tf_ = GetComponent<Transform>();
        tf_.position = new Vector3(0f,0.5f,-5f);
        RecognitionOfKeywordsToAction.MoveLeft += stepLeft;
        RecognitionOfKeywordsToAction.MoveRight += stepRight;
    }

    // Update is called once per frame
    void Update() {
        if (timePassedLastKeydown_ >= keydownSpeed_) {
            if (Input.GetKey("left")) {
                stepLeft();
                timePassedLastKeydown_ = 0f;
            } else if (Input.GetKey("right")) {
                stepRight();
                timePassedLastKeydown_ = 0f;
            }
        }
        timePassedLastKeydown_ = timePassedLastKeydown_ + Time.deltaTime;
        // Debug.Log(timePassedLastKeydown_);
    }

    void stepLeft(int steps = 1) {
        if (tf_.position.x > leftLimit_) {
            tf_.Translate(Vector3.left * stepSize_ * steps);
        }
    }

    void stepRight(int steps = 1) {
        if (tf_.position.x < rightLimit_) {
            tf_.Translate(Vector3.right * stepSize_ * steps);
        }
    }
}
