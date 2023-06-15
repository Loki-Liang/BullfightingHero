using CharacterStats.ScriptableObject;
using UnityEngine;

namespace CharacterStats.MonoBehavior
{
    public class CharacterStats : MonoBehaviour
    {
        public CharacterData_SO characterData;

        /// <summary>
        /// 最大血量
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if (characterData != null) return characterData.maxHealth;
                return 0;
            }
            set => characterData.maxHealth = value;
        }

        /// <summary>
        /// 当前血量
        /// </summary>
        public int CurrentHealth
        {
            get
            {
                if (characterData != null) return characterData.currentHealth;
                return 0;
            }
            set => characterData.currentHealth = value;
        }

        /// <summary>
        /// 基本防御
        /// </summary>
        public int BaseDefence
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.baseDefence;
                }

                return 0;
            }
            set => characterData.baseDefence = value;
        }

        /// <summary>
        /// 当前防御
        /// </summary>
        public int CurrentDefence
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.currentDefence;
                }

                return 0;
            }
            set => characterData.currentDefence = value;
        }

        /// <summary>
        /// 当前速度
        /// </summary>
        public float CurrentSpeed
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.currentSpeed;
                }

                return 0;
            }
            set => characterData.currentSpeed = value;
        }

        /// <summary>
        /// 最大速度
        /// </summary>
        public float MaxSpeed
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.maxSpeed;
                }

                return 0;
            }
            set => characterData.maxSpeed = value;
        }

        /// <summary>
        /// 最大耐力
        /// </summary>
        public float MaxStamina
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.maxStamina;
                }

                return 0;
            }
            set => characterData.maxStamina = value;
        }

        /// <summary>
        /// 当前耐力
        /// </summary>
        public float CurrentStamina
        {
            get
            {
                if (characterData != null)
                {
                    return characterData.currentStamina;
                }

                return 0;
            }
            set => characterData.currentStamina = value;
        }
    }
}