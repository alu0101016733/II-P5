using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

using System.Linq;

public class RecognitionOfKeywordsToAction : MonoBehaviour
{
    public delegate void MoveLeftHandler(int steps);
    public static event MoveLeftHandler MoveLeft;

    public delegate void MoveRightHandler(int steps);
    public static event MoveRightHandler MoveRight;

    private KeywordRecognizer keywordRecognizer_ = null;
    private Dictionary<string, System.Action> keywords_ = new Dictionary<string, System.Action>();
    private string currentWord_;

    private int steps_ = 1;
    // Start is called before the first frame update
    void Start()
    {
        // Define keywords to recognize and assign action to be performed
        keywords_.Add("Base", () => baseAction());

        keywords_.Add("Two", () => setNextStepSize(2));
        keywords_.Add("Three", () => setNextStepSize(3));
        keywords_.Add("Four", () => setNextStepSize(4));
        keywords_.Add("Five", () => setNextStepSize(5));
        keywords_.Add("Six", () => setNextStepSize(6));
        keywords_.Add("Seven", () => setNextStepSize(7));
        keywords_.Add("Eight", () => setNextStepSize(8));
        keywords_.Add("Nine", () => setNextStepSize(9));
        keywords_.Add("Then", () => setNextStepSize(10));

        keywords_.Add("Left", () => actionLeft());
        keywords_.Add("Right", () => actionRight());

        UIControls.GameStarted += StartkeywordRecognizer;
        UIControls.StopAll += StopkeywordRecognizer;

    }

    void StartkeywordRecognizer() {
        keywordRecognizer_ = new KeywordRecognizer(keywords_.Keys.ToArray());
        keywordRecognizer_.OnPhraseRecognized += CallWhenRecognized;
        if (!keywordRecognizer_.IsRunning) {
            keywordRecognizer_.Start();
            Debug.Log("Started Keyword Recognition");
        }
    }

    void StopkeywordRecognizer() {
        if (keywordRecognizer_ != null) {
            if (keywordRecognizer_.IsRunning) {
                Debug.Log("Stop Keyword recognizer");
                keywordRecognizer_.Stop();
                keywordRecognizer_.Dispose();
                PhraseRecognitionSystem.Shutdown(); 
            }
        }
        keywordRecognizer_ = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CallWhenRecognized(PhraseRecognizedEventArgs args) {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        Debug.Log(builder.ToString());
        if (args.confidence != ConfidenceLevel.Rejected) {
            PerformActionFor(args.text);
        }
    }

    private void PerformActionFor(string action) {
        Debug.Log("Will perform action for command: " + action);
        if (keywords_.ContainsKey(action)) {
            keywords_[action].Invoke();
        }
    }

    private void baseAction() {
        Debug.Log("Entered into base action");
        steps_ = 1;
    }

    void setNextStepSize(int steps) {
        steps_ = steps;
    }

    void actionLeft() {
        MoveLeft(steps_);
    }

    void actionRight() {
        MoveRight(steps_);
    }

}
