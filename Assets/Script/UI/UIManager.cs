using UnityEngine.InputSystem; // ʹ�� New Input System
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] UIs;

    public PlayerInput playerInput; // ���� PlayerInput ���
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
        Time.timeScale = 0;  // ��ͣ��Ϸʱ��

    }

    public void Continue()
    {
        Time.timeScale = 1;  // �ָ���Ϸʱ��

    }
}
