using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
    private string m_Hypotheses = "";

    private string m_Recognitions = "";

    private DictationRecognizer m_DictationRecognizer = null;

    // Start is called before the first frame update
    void Start() {
        UIControls.DictateStarted += startDictation;
        UIControls.StopAll += stopDictation;
    }

    void startDictation() {
        if (PhraseRecognitionSystem.Status == SpeechSystemStatus.Running) {
            Debug.Log("PhraseRecognitionSystem still online, will retry in 0.1s");
            Invoke("startDictation", 0.1f);
        } else {
            m_Recognitions = "";
        m_Hypotheses = "";
        m_DictationRecognizer = new DictationRecognizer();

        m_DictationRecognizer.DictationResult += (text, confidence) =>
        {
            Debug.LogFormat("Dictation result: {0}", text);
            m_Recognitions += text + "\n";
        };

        m_DictationRecognizer.DictationHypothesis += (text) =>
        {
            Debug.LogFormat("Dictation hypothesis: {0}", text);
            m_Hypotheses += text;
        };

        m_DictationRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete) {
                //Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
            }
            
            stopDictation();
        };

        m_DictationRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };

        m_DictationRecognizer.AutoSilenceTimeoutSeconds = 5f;
        Debug.Log("Start Dictating");
        m_DictationRecognizer.Start();
        }
    }

    void stopDictation() {
        if (m_DictationRecognizer != null) {
            Debug.Log("Stop Dictation and free up resources");
            createBrickField();
            m_DictationRecognizer.Stop();
            m_DictationRecognizer.Dispose();  
        }
        m_DictationRecognizer = null;
    }

    void createBrickField() {

        int columns_ = 10;
        int lines_ = 8;
        float startColPos_ = -4.9f;
        float startLinePos_ = 5.5f;
        float seperation_ = 1.1f;

        float colPos = startColPos_;
        float linePos = startLinePos_;
        int stringPos = 0;

        for (int j = 0; j < lines_; j++) {
            for (int i = 0; i < columns_; i++) {
                if (m_Recognitions.Length > stringPos) {
                    char nextChar = m_Recognitions[stringPos];
                    stringPos += 1;
                    if (nextChar.Equals('\n')) {
                        break;
                    } else if (nextChar.Equals(' ')) {
                        // no nothing so no cube will be created
                    } else {
                        GameObject cube = TargetCube.createCube ("TargetBrick", 2,
                            nextChar.ToString());
                        cube.transform.Translate(Vector3.up * 1f);
                        cube.transform.Translate(new Vector3(colPos, 0, linePos));
                    }
                    colPos += seperation_;
                }
            }
            linePos -= seperation_;
            colPos = startColPos_;
        }
        // GameObject cube = TargetCube.createCube ("TargetBrick", 2, "A");
        // cube.transform.Translate(Vector3.up * 1f);

        // cube.transform.Translate(new Vector3(3.8f, 0, 5.5f));

        // GameObject cube1 = TargetCube.createCube ("TargetBrick", 2, "A");
        // cube1.transform.Translate(Vector3.up * 1f);

        // cube1.transform.Translate(new Vector3(4.9f, 0, 5.5f));        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
