﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static T m_Instance;
    // Start is called before the first frame update

    public static T Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton]Instance'" + typeof(T) +
                    "'alreadydestroyed.Returningnull.");
                return null;
            }
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    m_Instance = (T)FindObjectOfType(typeof(T));
                    if (m_Instance == null)
                    {
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + "(Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }else
                {
                    DontDestroyOnLoad(m_Instance);
                }
                return m_Instance;
            }
        }
    }
    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }
    private void OnDestroy()
    {
        //m_ShuttingDown = true;
    }
    void Awake()
    {
        var t = Singleton<T>.Instance;
        if (Instance != null)
        {
            if (this != Instance)
            {
                Destroy(this.gameObject);
            }
        }
    }
}