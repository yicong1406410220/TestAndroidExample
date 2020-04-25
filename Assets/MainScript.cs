using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
#if UNITY_ANDROID// && !UNITY_EDITOR
    AndroidJavaObject currActivity;
#endif
    //UI组件
    Button button;
    InputField inputField;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID// && !UNITY_EDITOR
        //保存当前安卓活动的引用
        currActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
#endif
        //获取界面上的UI实例
        button = transform.Find("Button").GetComponent<Button>();
        inputField = transform.Find("InputField").GetComponent<InputField>();
        text = transform.Find("Text").GetComponent<Text>();
        //按钮添加点击响应
        button.onClick.AddListener(Hello);
    }

    public void Hello()
    {
#if UNITY_ANDROID// && !UNITY_EDITOR
        //调用安卓里面对应的hello方法
        currActivity.Call("Hello", inputField.text);
#endif
    }

    // 等待安卓java代码调用的方法
    public void Accept(string str)
    {
        text.text = str;
    }
}
