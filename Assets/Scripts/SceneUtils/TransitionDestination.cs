using UnityEngine;

namespace SceneUtils
{
    public class TransitionDestination : MonoBehaviour
    {
        /// <summary>
        /// 目标点枚举
        /// </summary>
       public enum DestinationTag
        {
            a,
            b,
            c,
            Enter
        }

        public DestinationTag destinationTag;
    }
}