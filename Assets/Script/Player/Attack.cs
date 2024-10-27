using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Light;
    public AudioClip attackSound;  // 绑定你的音效文件
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 按下左键
        {
            Light.SetActive(true);
            audioSource.PlayOneShot(attackSound);  // 播放音效
            Debug.Log("攻击音效播放");
        }
        else if (Input.GetMouseButtonUp(0)) // 松开左键
        {
            Light.SetActive(false);
        }
    }
}
