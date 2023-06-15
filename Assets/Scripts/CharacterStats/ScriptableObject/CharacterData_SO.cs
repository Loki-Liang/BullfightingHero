using UnityEngine;
using System.Collections;

namespace CharacterStats.ScriptableObject
{
    /// <summary>
    /// 状态数据模板
    /// </summary>
    [CreateAssetMenu(fileName = "New Data", menuName = "Character States/Data", order = 0)]
    public class CharacterData_SO : UnityEngine.ScriptableObject
    {
        [Header("状态信息")] public int maxHealth;
        
        public int currentHealth;

        public int baseDefence;

        public int currentDefence;

        public float currentSpeed;
        
        public float maxSpeed;


        /// <summary>
        /// 最大耐力
        /// </summary>
        public float maxStamina;

        /// <summary>
        /// 当前耐力
        /// </summary>
        public float currentStamina;
        

    }
}