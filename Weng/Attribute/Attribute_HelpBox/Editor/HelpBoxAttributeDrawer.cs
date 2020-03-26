using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(HelpBoxAttribute))]
public class HelpBoxAttributeDrawer : DecoratorDrawer {


    /// <summary> 整個訊息欄所占用的高度大小 </summary>
    private float BoxHeight;

    /// <summary> 欄位最小高度 (40 剛好能完整顯示兩行文字的內容) </summary>
    private const float minHeight = 40.0f;

    /// <summary> 緩存用 GUIContent </summary>
    private static GUIContent tmpContent = new GUIContent();

    /// <summary> 編輯器 EditorStyle 引用緩存 (使用static可以減少初始化的次數)</summary>
    private static GUIStyle HelpBoxStyle;

    /// <summary> 背景色 (無框風格時使用) </summary>
    private static Color helpBoxBackGroundColor = new Color32(208, 208, 208, 255);

    /// <summary> 自定義圖示1 (使用static可以減少Resources.Load的次數) </summary>
    private static Texture customIcon_1 = null;


    public override float GetHeight() {

        HelpBoxAttribute helpBox = (HelpBoxAttribute) attribute;
        InitStyle(helpBox);
        BoxHeight = HelpBoxStyle.CalcHeight(new GUIContent(helpBox.text), EditorGUIUtility.currentViewWidth);

        //None 類型由於沒有圖示無法產生折疊按鍵，故直接返回預設大小
        if (helpBox.BoxType == HelpBoxType.None) {
            return BoxHeight;
        }

        //關閉摺疊功能的話也直接返回預設大小
        if (helpBox.isAlwaysOpen) {
            return BoxHeight;
        }

        //至少要有指定的最小高度使介面看起來一致
        if (BoxHeight < minHeight) {
            return minHeight;
        }


        //如果高度有超過最小高度的話，依折疊狀態顯示高度
        if (helpBox.isFoldout) {
            return BoxHeight;
        }
        else {
            return minHeight;
        }
    }


    //這裡不直接使用 EditorGUI.HelpBox 以方便擴展
    public override void OnGUI(Rect position) {

        //取得訊息、初始化 UI風格
        HelpBoxAttribute helpBox = (HelpBoxAttribute)attribute;
        InitStyle(helpBox);


        //與下方參數的距離 = 2
        position.height -= 2;
        position = EditorGUI.IndentedRect(position);

        //背景圖 (無框風格)
        //Texture2D originTex = HelpBoxStyle.normal.background;
        //HelpBoxStyle.normal.background = originTex;
        //HelpBoxStyle.normal.background = EditorGUIUtility.whiteTexture;
        //Color tColor = GUI.color;
        //GUI.color = helpBoxBackGroundColor;
        //GUI.DrawTexture(position, HelpBoxStyle.normal.background);
        //GUI.color = tColor;

        //背景圖 (有黑色邊框)
        GUI.Box(position, "", EditorStyles.helpBox);


        //None 類型文字置左+置中，介面比較好看
        if (helpBox.BoxType == HelpBoxType.None) {
            HelpBoxStyle.alignment = TextAnchor.MiddleLeft;
        }

        //其它類型如果高度不高，文字也置左+置中
        else {
            if (BoxHeight < minHeight) {
                HelpBoxStyle.alignment = TextAnchor.MiddleLeft;
            }
            else {
                HelpBoxStyle.alignment = TextAnchor.UpperLeft;
            }
        }


        //顯示文字訊息
        HelpBoxStyle.normal.background = null;
        tmpContent.text = helpBox.text;
        tmpContent.tooltip = "";
        tmpContent.image = null;
        if (helpBox.BoxType == HelpBoxType.None) {
            position.x += 2;
        } else {
            position.x += 30;
        }
        position.width = EditorGUIUtility.currentViewWidth - 50;
        EditorGUI.LabelField(position, tmpContent, HelpBoxStyle);
        if (helpBox.BoxType == HelpBoxType.None) {
            position.x -= 2;
        }
        else {
            position.x -= 30;
        }


        //顯示資訊類型的圖示
        HelpBoxStyle.imagePosition = ImagePosition.ImageOnly;
        HelpBoxStyle.normal.background = null;
        tmpContent.image = GetHelpIcon(helpBox.BoxType);
        position.y += position.height * 0.5f;
        position.y -= 18;
        position.width = 36;
        position.height = 36;
        if (isOneMiniLine(helpBox)) {

            //單行緊縮模式下，特定類型的圖片稍作調整，使介面美觀
            if (helpBox.BoxType == HelpBoxType.Warning) {
                position.y += 1;
                position.width = 35;
                position.height = 35;
            }
            else if(helpBox.BoxType == HelpBoxType.Error) {
                position.y += 2;
                position.width = 35;
                position.height = 35;
            }
        }
        EditorGUI.LabelField(position, tmpContent, HelpBoxStyle);
        HelpBoxStyle.imagePosition = ImagePosition.ImageLeft;


        //None 類型由於沒有圖示無法產生折疊按鍵，故下面不做處理，並恢復文字對齊方式
        if (helpBox.BoxType == HelpBoxType.None) {
            HelpBoxStyle.alignment = TextAnchor.UpperLeft;
            return;
        }

        //如果高度不高，沒有摺疊的問題，故下面也不做處理
        if (BoxHeight < minHeight) {
            return;
        }

        //如果關閉摺疊功能，也不處理摺疊開關
        if (helpBox.isAlwaysOpen) {
            return;
        }

        //調整折疊關的風格 (隱藏 HelpBox背景圖)
        HelpBoxStyle.normal.background = null;

        //折疊時的提示
        if (!helpBox.isFoldout) {

            //折疊時的顯示「---」表示摺疊中
            tmpContent.text = "---";
            tmpContent.image = null;
            position.width = 30;
            position.height = 16;
            HelpBoxStyle.alignment = TextAnchor.MiddleLeft;
            position.x += 4;
            position.y += 20;
            EditorGUI.LabelField(position, tmpContent, HelpBoxStyle);
            position.y -= 20;
            position.x -= 4;
            
            //針對按鍵位置的位移，使折疊與非折疊時按鍵位置一致
            position.y += 10;
        }


        //折疊按鍵
        position.x += 6f;
        position.y += position.height * 0.5f;
        position.y -= 10;
        position.width = 22;
        position.height = 22;
        if (GUI.Button(position, "", HelpBoxStyle)) {
            helpBox.isFoldout = !helpBox.isFoldout;
        }

    }


    /// <summary> 初始化訊息欄風格 </summary>
    /// <param name="helpBox"> 參考風格 </param>
    private void InitStyle(HelpBoxAttribute helpBox) {
        if (HelpBoxStyle == null) {
            HelpBoxStyle = new GUIStyle(EditorStyles.helpBox);
            HelpBoxStyle.fontSize = 13;
            HelpBoxStyle.wordWrap = false;
            HelpBoxStyle.padding = new RectOffset(4, 4, 4, 4); //文字部分跟周圍邊框的間距
            HelpBoxStyle.border = new RectOffset(4, 4, 4, 4);  
            HelpBoxStyle.margin = new RectOffset(4, 4, 3, 3);
        }
    }



    /// <summary> 單行緊縮模式判斷 </summary>
    private bool isOneMiniLine(HelpBoxAttribute helpBox) {
        if (helpBox.isAlwaysOpen) {
            if (BoxHeight < 30) {
                return true;
            }
        }
        return false;
    }



    /// <summary> 取得訊息圖示 </summary>
    /// <param name="type"> 訊息類型 </param>
    private Texture GetHelpIcon(HelpBoxType type) {
        switch (type) {
            case HelpBoxType.None:
                return null;
            case HelpBoxType.Info:
                return EditorGUIUtility.IconContent("console.infoicon").image;
            case HelpBoxType.Warning:
                return EditorGUIUtility.IconContent("console.warnicon").image;
            case HelpBoxType.Error:
                return EditorGUIUtility.IconContent("console.erroricon").image;
            case HelpBoxType.C8763:
                if (customIcon_1 == null) {
                    customIcon_1 = Resources.Load<Texture>("C8763");
                }
                return customIcon_1;
                //return EditorGUIUtility.IconContent("BuildSettings.SelectedIcon").image;
            default:
                return null;
        }
    }



}










