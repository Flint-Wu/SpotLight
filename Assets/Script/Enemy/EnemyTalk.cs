using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyTalk : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float lineDelay = 0.5f;  // 每行显示的间隔时间
    public float clearDelay = 1.0f; // 完成后清空文本的延迟时间
    [TextArea(3, 10)] public string[] lines; // 已编辑好的文本，每行一个元素

    

    private void Start()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();

        StartCoroutine(DisplayTextWithDelay());
    }

    private void Update()
    {

    }


    private IEnumerator DisplayTextWithDelay()
    {
        textMeshPro.text = "";  // 清空初始文本
        foreach (string line in lines)
        {
            textMeshPro.text += line + "\n";  // 添加每行文本
            yield return new WaitForSeconds(lineDelay);  // 延迟
        }

        // 文本播放完成后，延迟一段时间再清空
        yield return new WaitForSeconds(clearDelay);
        textMeshPro.text = "";  // 清空文本
    }



}
