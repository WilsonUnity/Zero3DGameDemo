﻿using UnityEngine;

namespace Zero
{
    /// <summary>
    /// MonoBehaviour的单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ASingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        private static T _ins;

        /// <summary>
        /// 获得单例
        /// </summary>
        public static T Ins
        {
            get
            {
                if (null == _ins)
                {
                    string name = typeof(T).Name;
                    GameObject go = GameObject.Find(name);
                    if (null == go)
                    {
                        go = new GameObject();
                        go.name = name;
                        go.AddComponent<T>();
                    }

                    DontDestroyOnLoad(go);
                    _ins = go.GetComponent<T>();
                }
                return _ins;
            }

            protected set
            {
                if (null == _ins)
                {
                    _ins = value;
                    DontDestroyOnLoad(_ins.gameObject);
                }
            }
        }

        /// <summary>
        /// 销毁当前单例
        /// </summary>
        public static void DestroyIns()
        {
            if (null != _ins)
            {                
                GameObject.Destroy(_ins.gameObject);
                _ins = null;
            }
        }
    }
}