using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AttributeDemo {

    public class HelpBoxDemo : MonoBehaviour {

        [HelpBox("單行-短訊息3 (緊縮)", HelpBoxType.Error, true)]
        [HelpBox("單行-短訊息2 (緊縮)", HelpBoxType.Warning, true)]
        [HelpBox("單行-短訊息1 (緊縮)", HelpBoxType.Info, true)]
        [HelpBox("單行-短訊息0 (緊縮)", HelpBoxType.None, true)]
        public int property1;


        [HelpBox("單行-短訊息3", HelpBoxType.Error)]
        [HelpBox("單行-短訊息2", HelpBoxType.Warning)]
        [HelpBox("單行-短訊息1", HelpBoxType.Info)]
        [HelpBox("單行-短訊息0", HelpBoxType.None)]
        [Space(16)]
        public int property2;



        [HelpBox("第一行\n第二行", HelpBoxType.Error)]
        [HelpBox("第一行\n第二行", HelpBoxType.Warning)]
        [HelpBox("第一行\n第二行", HelpBoxType.Info)]
        [HelpBox("第一行\n第二行", HelpBoxType.None)]
        [Header("- 雙行的樣式只有一種模樣")]
        [Space(12)]
        public int property3;


        [HelpBox("長訊息示例:\n" +
            "1. A、\n" +
            "2. B、\n" +
            "3. C。",
            HelpBoxType.None, true)]
        [HelpBox("長訊息示例:\n" +
            "1. A、\n" +
            "2. B、\n" +
            "3. C。",
            HelpBoxType.None)]
        [Header("- None 類型無法摺疊")]
        [Space(12)]
        public int[] property4;


        [HelpBox("長訊息示例:\n" +
           "1. A、\n" +
           "2. B、\n" +
           "3. C、\n" +
           "4. D、\n" +
           "5. E、\n" +
           "6. F。",
            HelpBoxType.Error)]
        [HelpBox("長訊息示例:\n" +
           "1. A、\n" +
           "2. B、\n" +
           "3. C、\n" +
           "4. D、\n" +
           "5. E、\n" +
           "6. F。",
            HelpBoxType.Warning)]
        [HelpBox("長訊息示例:\n" +
            "1. A、\n" +
            "2. B、\n" +
            "3. C、\n" +
            "4. D、\n" +
            "5. E、\n" +
            "6. F。",
            HelpBoxType.Info)]
        [Space(16)]
        public int property5;



        [HelpBox("長訊息示例:\n" +
          "1. A、\n" +
          "2. B、\n" +
          "3. C、\n" +
          "4. D、\n" +
          "5. E、\n" +
          "6. F。",
           HelpBoxType.Error, true)]
        [HelpBox("長訊息示例:\n" +
          "1. A、\n" +
          "2. B、\n" +
          "3. C、\n" +
          "4. D、\n" +
          "5. E、\n" +
          "6. F。",
           HelpBoxType.Warning, true)]
        [HelpBox("長訊息示例:\n" +
           "1. A、\n" +
           "2. B、\n" +
           "3. C、\n" +
           "4. D、\n" +
           "5. E、\n" +
           "6. F。",
           HelpBoxType.Info, true)]
        [Space(16)]
        public int property6;


        [HelpBox("喔喔喔喔!!!!!\n" +
            "星爆氣流斬！\n" +
            "星爆氣流斬！\n" +
            "星爆氣流斬！\n" +
            "星爆氣流斬！\n" +
            "星爆氣流斬！\n" +
            "騙...騙人的吧 !？",
        HelpBoxType.C8763, true)]
        [HelpBox("拜託了，\n" +
            "幫我撐十秒！\n" +
            "....\n" +
            "....\n" +
            "幹，怎麼沒人？",
         HelpBoxType.C8763)]
        [HelpBox("亞斯娜！\n克萊茵！", HelpBoxType.C8763)]
        [HelpBox("只能用那一招了嗎？", HelpBoxType.C8763)]
        [HelpBox("可.. 可惡!", HelpBoxType.C8763, true)]
        [Space(16)]
        public int propertyC8763;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }

}

