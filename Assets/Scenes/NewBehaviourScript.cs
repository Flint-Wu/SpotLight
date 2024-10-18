using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text Text;

    // ��Inspector�п����ֶ���д��ͨ���ű����õĽ�Ʒ��
    public string[] prizes;

    void Start()
    {
        
    }

    // �齱������������ؽ�Ʒ���е�һ����Ʒ
    string DrawPrize(string[] prizePool)
    {
        // ���������������
        System.Random random = new System.Random();

        // �ӽ�Ʒ���������ȡһ����Ʒ
        int index = random.Next(prizePool.Length);
        return prizePool[index];
    }

    public void roll()
    {
        // �����Ʒ�ز�Ϊ�գ����г齱
        if (prizes != null && prizes.Length > 0)
        {
            string winner = DrawPrize(prizes);
            Text.text = winner;
            Debug.Log("�н������: " + winner);
        }
        else
        {
            Debug.Log("��Ʒ��Ϊ�գ��޷��齱��");
        }
    }
}
