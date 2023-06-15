using UnityEngine;
using System.Collections;

namespace CharacterStats.ScriptableObject
{
    /// <summary>
    /// 攻击数据模板
    /// </summary>
    [CreateAssetMenu(fileName = "New Data", menuName = "Character States/Data", order = 0)]
    public class AttackData_So : UnityEngine.ScriptableObject
    {
        [Header("攻击信息")] public float attackDistance;
        
        public int attackDamage;
        
        public float lastAttackTime;
        
        public float attackTime;

        public float stopDistance;

    }
}