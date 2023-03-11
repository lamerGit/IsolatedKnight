using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { Init(); return s_instance; } }

    public Canvas Canvas;

    #region Contents

    ObjectManager _obj = new ObjectManager();
    PoolManager _pool =new PoolManager();
    GameManager _gameManager = new GameManager();
    UIManager _uiManager = new UIManager();

    public static UIManager UIManager { get { return Instance._uiManager; } }

    public static GameManager GameManager { get { return Instance._gameManager; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ObjectManager Object { get { return Instance._obj; } }

    #endregion

    #region Core
    DataManager _data =new DataManager();
    
    public static DataManager Data { get { return Instance._data; } }
    

    #endregion

    private void Start()
    {
        Canvas=FindObjectOfType<Canvas>();

        Init();

    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go==null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);
            s_instance=go.GetComponent<Managers>();

            s_instance._data.Init();

            //게임씬일때만
            s_instance._uiManager.GameScenInit();
            s_instance._obj.Init();
            s_instance._pool.Init();
            s_instance._pool.CreatePool(Object.Skel,count:30);
            s_instance._pool.CreatePool(Object.DamageText,count:30);
            
            
            
        }
    }

}
