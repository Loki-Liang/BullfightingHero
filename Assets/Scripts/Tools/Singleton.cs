using System;
using Manager;
using UnityEngine;
using Photon.Pun;

namespace Tools
{
    /// <summary>
    /// 单例工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviourPunCallbacks where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
            
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = (T)this;
            }
            
        }

        public static bool IsInitialized => _instance != null;

        protected virtual void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
    }
}