using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour {
    // ����ʵ��
    public static TransitionManager Instance { get; private set; }

    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;

    private bool isFade;
    private bool canTransition;

    private void Awake()
    {
        // ����Ƿ�����ʵ����������������ͻ
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            // �����ڳ����л�ʱ������
            DontDestroyOnLoad(gameObject);
        }


    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transition(string from, string to)
    {
        if (!isFade && canTransition)
            StartCoroutine(TransitionToScene(from, to));
    }


    private IEnumerator TransitionToScene(string from, string to)
    {
        Debug.Log(from + "," + to);
        yield return Fade(1);
        if (from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(from);
        }
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
        Debug.Log("1");

        //�����³���Ϊ�����
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);

        EventHandler.CallAfterSceneLoadedEvent();
        Debug.Log("2");
        yield return Fade(0);
        Debug.Log("��������");
    }

    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;

    }

}
