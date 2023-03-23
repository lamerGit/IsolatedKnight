using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    //private static bool isShutDown = false;

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // ���� �̱���� �ν��Ͻ��� ��������� �ʾҴ�. �ѹ��� ���� ���� ����.
                T obj = FindObjectOfType<T>(); // �ϴ� ���� Ÿ���� �ִ��� ã��
                if (obj == null)
                {
                    GameObject gameObject = new(); // ������ ���� �����.
                    gameObject.name = $"{typeof(T).Name}";
                    obj = gameObject.AddComponent<T>();
                }
                instance = obj;
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance; //instance�� ������ null�� �ƴ� ���� ����
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            //���Ӱ� ������� �̱���
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //�� Ÿ������ ������� �̱����� �ִ�
            if (instance != this)
            {
                //�̹� ��������� ���� �ƴϴ�.
                Destroy(this.gameObject); // ���� ����
            }
        }
    }

    protected virtual void OnEnable()
    {
        // ���� �ε��Ǹ� OnSceneLoaded �Լ��� ������Ѷ�.(SceneManager�� ������ �ִ� ��������Ʈ�� �Լ� �߰�)
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected virtual void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnApplicationQuit()
    {
        // isShutDown = true;
    }

    /// <summary>
    /// ���� �ε��� �� ����� ��������Ʈ�� ����� �Լ�
    /// </summary>
    /// <param name="arg0">�ش� �� ������</param>
    /// <param name="arg1">�� �߰� ���</param>
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Initialize();
    }

    /// <summary>
    /// ���� �ʱ�ȭ�� �Լ�, ��ӹ��� Ŭ�������� override�ؼ� ����� ��
    /// </summary>
    protected virtual void Initialize()
    {

    }
}
