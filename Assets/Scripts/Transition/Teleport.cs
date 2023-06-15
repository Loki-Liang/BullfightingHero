using System;
using System.Collections.Generic;
using UnityEngine;

namespace Transition
{
    public class Teleport : MonoBehaviour
    {
        /// <summary>
        /// 场景枚举
        /// </summary>
        public enum SceneName
        {
            MainMenu,
            Store,
            Hero,
            News,
            Event,
            Guild,
            Friend,
            Level1,
            Level2
            
        }

        //TODO: 后期改成字典读取，并放入配置文件

        [Header("切换的场景")] public SceneName fromSceneName;

        public SceneName toSceneName;

        public SceneName _SceneName;

        public void TeleportToScene()
        {
            TransitionManager.Instance.Transition(fromSceneName, toSceneName);
        }
    }
}