using System;
using System.Transactions;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class Parameter
    {
        public CharacterStats.MonoBehavior.CharacterStats _characterStats;

        public int health;
        
        public float moveSpeed;
        
        public float chaseSpeed;
        
        public float attackSpeed;
        
        public float defendSpeed;

        public Transform[] patrolPoints;

        public Transform[] chasePoint;

        public Animator _Animator;
        
        public float idleTime;
        
        public Transform target;
        
    }
}