using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance
    {
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "LevelManager";
                    _instance = obj.AddComponent<LevelManager>();
                }
            }

            return _instance; 
        }

    }

    public GameObject level;

    void Awake()
    {
        // �ٸ� BallManager �ν��Ͻ��� �̹� ������ ���� �ν��Ͻ��� �ı�
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����

        PlayerPrefs.SetInt("UnlockedLevel", 1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        //level = transform.GetChild(0).gameObject;
        //Debug.Log(level.name);
    }

    /// <summary>
    /// Scene�� ó�� �ε�� �� �ʱ�ȭ�ϴ� �Լ�
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            // Title ȭ��
            case 0:
                if (level != null)
                {
                    level.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
}
