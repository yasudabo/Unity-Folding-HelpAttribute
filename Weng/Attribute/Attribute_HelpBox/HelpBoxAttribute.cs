using System;
using UnityEngine;


//修改自下方網址六樓回文：
//https://forum.unity.com/threads/helpattribute-allows-you-to-use-helpbox-in-the-unity-inspector-window.462768/


public enum HelpBoxType {
    None,
    Info,
    Warning,
    Error,
    C8763,
}


[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
public class HelpBoxAttribute : PropertyAttribute {


    /// <summary> 要顯示的文字 </summary>
    public string text;

    /// <summary> 訊息類型 </summary>
    public HelpBoxType BoxType;

    /// <summary> 是否折疊 </summary>
    public bool isFoldout = false;

    /// <summary> 是否關閉摺疊功能 </summary>
    public bool isAlwaysOpen = false;


    /// <summary> 顯示一個訊息欄位 </summary>
    /// <param name="tText"        > 訊息內容 </param>
    /// <param name="tBoxType"     > 訊息分類 </param>
    /// <param name="tIsAlwaysOpen"> 是否關閉摺疊功能 (true = 關閉) </param>
    public HelpBoxAttribute(string tText, HelpBoxType tBoxType = HelpBoxType.Info, bool tIsAlwaysOpen = false) {
        this.text = tText;
        this.BoxType = tBoxType;
        this.isAlwaysOpen = tIsAlwaysOpen;
    }


}