using UnityEngine.InputSystem; // 使用 New Input System
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIs;

    public PlayerInput playerInput; // 引用 PlayerInput 组件
    // Start is called before the first frame update
    void Start()
    {
        UIs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            UIs[i] = transform.GetChild(i).gameObject;
        }

        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        EventHandler.UIchange += changeUI;
    }

    private void OnDisable()
    {
        EventHandler.UIchange += changeUI;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void changeUI()
    {
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }        
    }

    public void UIexchange(GameObject UI)
    {
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
        UI.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;  // 暂停游戏时间

    }

    public void Continue()
    {
        Time.timeScale = 1;  // 恢复游戏时间

    }
}
