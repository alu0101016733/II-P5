// most of this code was taken from http://geek1337.blogspot.com/2017/04/unity3d-creating-cube-with-text-on-each.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCube : MonoBehaviour
{
    static GameObject addSide (float size, string text) {
        //First we create a canvas-object to hold the UI:
        GameObject mainObj = new GameObject();
        Canvas canvasObj = mainObj.AddComponent<Canvas>();
        canvasObj.renderMode = RenderMode.WorldSpace;
        //Then we create a rawimage-object and we connect it to the parent object:

        GameObject childObj2 = new GameObject ();
        RawImage rawimageObj = childObj2.AddComponent<RawImage>();
        rawimageObj.rectTransform.SetSizeWithCurrentAnchors
            (RectTransform.Axis.Horizontal, size);
        rawimageObj.rectTransform.SetSizeWithCurrentAnchors
            (RectTransform.Axis.Vertical, size);
        rawimageObj.color = Color.red;
        childObj2.transform.SetParent(mainObj.transform,false);

        //We also have to create the text-object and connect it to the parent object:
        GameObject childObj1 = new GameObject ();
        Text textObj = childObj1.AddComponent<Text>();
        textObj.font = (Font)Resources.GetBuiltinResource
            (typeof(Font), "Arial.ttf");;
        textObj.text = text;
        textObj.alignment = TextAnchor.MiddleCenter;
        textObj.enabled = true;
        textObj.fontSize = (int) (size*0.8);
        textObj.color = Color.black;
        textObj.rectTransform.SetSizeWithCurrentAnchors
            (RectTransform.Axis.Horizontal, size);
        textObj.rectTransform.SetSizeWithCurrentAnchors
            (RectTransform.Axis.Vertical, size);
        childObj1.transform.SetParent(mainObj.transform,false);

        return mainObj;
    }

    public static GameObject createCube (string name, float size, string curChar) {

        size = size * 50;
        GameObject mainObj = new GameObject();
        mainObj.name = name;
        mainObj.tag = name;

        GameObject side1 = addSide (size, curChar);
        side1.transform.SetParent (mainObj.transform);
        side1.transform.position = new Vector3(0,0,-size/2);
        side1.transform.rotation = Quaternion.Euler(0,0,0);

        GameObject side2 = addSide (size, curChar);
        side2.transform.SetParent (mainObj.transform);
        side2.transform.position = new Vector3(0,0,size/2);
        side2.transform.rotation = Quaternion.Euler(0,180,0);

        GameObject side3 = addSide (size, curChar);
        side3.transform.SetParent (mainObj.transform);
        side3.transform.position = new Vector3(0,-size/2,0);
        side3.transform.rotation = Quaternion.Euler(90,0,0);

        GameObject side4 = addSide (size, curChar);
        side4.transform.SetParent (mainObj.transform);
        side4.transform.position = new Vector3(0,size/2,0);
        side4.transform.rotation = Quaternion.Euler(90,0,0);

        GameObject side5 = addSide (size, curChar);
        side5.transform.SetParent (mainObj.transform);
        side5.transform.position = new Vector3(-size/2,0,0);
        side5.transform.rotation = Quaternion.Euler(0,90,0);

        GameObject side6 = addSide (size, curChar);
        side6.transform.SetParent (mainObj.transform);
        side6.transform.position = new Vector3(size/2,0,0);
        side6.transform.rotation = Quaternion.Euler(0,270,0);

        mainObj.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        float boxCscale = size;
        mainObj.AddComponent<BoxCollider>();
        mainObj.GetComponent<BoxCollider>().size = new Vector3(boxCscale,boxCscale,boxCscale);;

        return mainObj;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
