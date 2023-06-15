using CharacterStats.ScriptableObject;
using UnityEngine;

namespace CharacterStats.MonoBehavior
{
    /// <summary>
    /// 攻击信息
    /// </summary>
    public class AttackInfo : MonoBehaviour
    {
        public AttackData_So AttackData
        {
            get => _attackData;
            set => _attackData = value;
        }

        public float AttackDistance
        {
            get
            {
                if (_attackData!=null)
                {
                   return _attackData.attackDistance;
                }

                return 0;
            }
            set => _attackData.attackDistance = value;
        }

        public int AttackDamage
        {
            get
            {
                if (_attackData!=null)
                {
                    return _attackData.attackDamage;
                }

                return 0;
            }
            set => _attackData.attackDamage = value;
        }

        public float LastAttackTime
        {
            get
            {
                if (_attackData!=null)
                {
                    return _attackData.lastAttackTime;
                }

                return 0;
            }
            set => _attackData.lastAttackTime = value;
        }

        public float AttackTime
        {
            get
            {
                if (_attackData!=null)
                {
                    return _attackData.attackTime;
                }

                return 0;
            }
            set => _attackData.attackTime = value;
        }

        public float StopDistance
        {
            get
            {
                if (_attackData!=null)
                {
                    return _attackData.stopDistance;
                }

                return 0;
            }
            set => _attackData.stopDistance = value;
        }
        private AttackData_So _attackData;
        
    }
}