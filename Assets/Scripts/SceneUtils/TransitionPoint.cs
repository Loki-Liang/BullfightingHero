using System;
using UnityEngine;

namespace SceneUtils
{
    /// <summary>
    /// 转换点
    /// </summary>
    public class TransitionPoint : MonoBehaviour
    {
        public enum TransitionType
        {
            SameScene,
            DifferentScene
        }

        [Header("Transition info")] public string sceneName;
        /// <summary>
        /// 转换类型，同场景，不同场景
        /// </summary>
        public TransitionType transitionType;

        public TransitionDestination.DestinationTag destinationTag;

        private bool canTrans=false;

        private void Awake()
        {
            if (canTrans)
            {
                SceneController.Instance.TransitionDestination(this);
            }
            
        }

        private void Update()
        {
            
        }

        /// <summary>
        /// 保持触发
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canTrans = true;
            }
        }

        /// <summary>
        /// 退出触发
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canTrans = false;
            }
        }
    }
}