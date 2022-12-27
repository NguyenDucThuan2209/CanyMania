using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AdmobGA : MonoBehaviour
{
    private static AdmobGA m_instance;
    public static AdmobGA Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<AdmobGA>();
            }

            return m_instance;
        }
    }
    public GoogleAnalyticsV3 GA;    // instance of Google Analytics 
    public int NumberLevelPerShowRate = 10;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        // Start Session Google Analytics
        GA.StartSession();
    }
}
