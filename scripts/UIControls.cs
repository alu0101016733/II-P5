using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public delegate void StartDictate();
    public static event StartDictate DictateStarted;

    public delegate void StartGame();
    public static event StartGame GameStarted;

    public delegate void StopAllHandler();
    public static event StopAllHandler StopAll;
    // Start is called before the first frame update
    void Start()
    {
        GameObject startDict = GameObject.FindGameObjectsWithTag("StartDictate")[0];
        startDict.GetComponentInChildren<Text>().text = "Start Dictate";
        startDict.GetComponent<Button>().onClick.AddListener(StartDictation);

        GameObject startGam = GameObject.FindGameObjectsWithTag("StartGame")[0];
        startGam.GetComponentInChildren<Text>().text = "Start Game";
        startGam.GetComponent<Button>().onClick.AddListener(StartGaming);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDictation() {
        StopAll();
        DictateStarted();
    }

    void StartGaming() {
        StopAll();
        GameStarted();
    }
}
