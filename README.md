## UnityAttribute_FoldoutHelpBox
一個使用 Unity DecoratorDrawer 達成的「可摺疊訊息窗」。



| - 單行緊縮 -
| ------
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview1_OneLine_Mini.png)

| - 單行大欄位 -
| ------
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview2_OneLine_Normal.png)

| - 雙行 -
| ------
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview3_TwoLine.png)

| - 摺疊 (該功能可以關閉) -
| ------
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview4_Fold.png)
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview5_Foldout.gif)

| - 自定義訊息類型 -
| ------
| ![image](https://raw.githubusercontent.com/Yasudabo/UnityAttribute_FoldoutHelpBox/master/Preview/Preview7_CustomIcon.gif)

--------
1. 一般使用
```python
[HelpBox("訊息", HelpBoxType.None)]
public int property1;
```


2. 關閉摺疊功能 或 單行訊息緊縮顯示
```python
[HelpBox("訊息", HelpBoxType.None, true)]
public int property1;
```

3. 支援類型
<pre>
- None
- Info
- Warning
- Error
- ...... (你可以自定義更多類型和圖示)
<pre/>
