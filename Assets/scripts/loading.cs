using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
/// <summary>
/// 进度条下方显示的文本
/// </summary>
[SerializeField] Text loading_text;
/// <summary>
/// 进度条
/// </summary>
[SerializeField] Slider slider;
/// <summary>
/// 文字后方点数显示
/// </summary>
float pointCount;
/// <summary>
/// 当前进度
/// </summary>
float progress = 0;
/// <summary>
/// 进度条读取完成时间
/// </summary>
float total_time = 3f;
/// <summary>
/// 计时器
/// </summary>
float time = 0;
void OnEnable()
{
//开启协程
StartCoroutine("slider_animate");
}
void Update()
{
//记录时间增量
time += Time.deltaTime;
//当前进度随着时间改变的百分比
progress = time / total_time;
if (progress >= 1)
{
return;
}
//把进度赋给进度条的值
slider.value = progress;
}
void OnDisable()
{
//关闭协程
StopCoroutine("slider_animate");
}
/// <summary>
/// 检测外挂协程
/// </summary>
/// <returns></returns>
IEnumerator slider_animate()
{
while (true)
{
yield return new WaitForSeconds(0.1f);
float f = slider.value;
//设置进度条的value值在某个区间的时候要显示的字符串
string reminder = "";
if (f < 0.1f)
{
reminder = "0%";
}
else if (f < 0.2f)
{
reminder = "20%";
}
else if (f < 0.5f)
{
reminder = "50%";
}
else if (f < 0.75f)
{
reminder = "75%";
}
else if (f < 0.9f)
{
reminder = "90%";
}
else if (f < 0.95f)
{
reminder = "100%";
}
else
{
reminder = "進入遊戲";
SceneManager.LoadScene(1);
}
//显示字符串后面的“.”
pointCount++;
if (pointCount == 7)
{
pointCount = 0;
}
for (int i = 0; i < pointCount; i++)
{
reminder += ".";
}
//把显示内容赋给场景中的text
loading_text.text = reminder;
}
}
}