using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text Text;

    // 在Inspector中可以手动填写或通过脚本设置的奖品池
    public string[] prizes;

    void Start()
    {
        
    }

    // 抽奖方法，随机返回奖品池中的一个奖品
    string DrawPrize(string[] prizePool)
    {
        // 创建随机数生成器
        System.Random random = new System.Random();

        // 从奖品池中随机抽取一个奖品
        int index = random.Next(prizePool.Length);
        return prizePool[index];
    }

    public void roll()
    {
        // 如果奖品池不为空，进行抽奖
        if (prizes != null && prizes.Length > 0)
        {
            string winner = DrawPrize(prizes);
            Text.text = winner;
            Debug.Log("中奖结果是: " + winner);
        }
        else
        {
            Debug.Log("奖品池为空，无法抽奖！");
        }
    }
}
