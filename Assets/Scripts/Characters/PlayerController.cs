using System;
using Manager;
using Photon.Pun;
using Tools;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    public class PlayerController : Singleton<PlayerController>
    {
        public CharacterStats.MonoBehavior.CharacterStats _characterStats;

        private NavMeshAgent _agent;

        private Animator _animator;
        
        
        private bool death = false;

        #region 事件函数方法

        //获取遥感脚本
        // public EasyTouchMove touch;

        protected override void Awake()
        {
            base.Awake();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _characterStats = GetComponent<CharacterStats.MonoBehavior.CharacterStats>();
            _animator.Play("IdleB");
        }


        private void Update()
        {
            
        }

        #endregion

        #region 普通函数方法

        /// <summary>
        /// 摇杆移动
        /// </summary>
        /// <param name="Position"></param>
        public void Moving(Vector2 Position)
        {
            if (!photonView.IsMine
                && PhotonNetwork.IsConnected)
            {
                return;
            }
            if (death)
            {
                ETCInput.SetControlActivated("LeftJoystick", false);
                ETCInput.SetControlActivated("RightJoystick", false);
            }

            if (!death && Position.y != 0 || Position.x != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                transform.LookAt(new Vector3(transform.position.x + Position.x,
                    transform.position.y,
                    transform.position.z + Position.y));
                _animator.Play("Walk");
            }
        }

        /// <summary>
        /// 摇杆移动结束
        /// </summary>
        /// <param name="position"></param>
        public void StoppingMove()
        {
            _animator.CrossFade("IdleB",0.5f);
        }

        #endregion
        
        
    }
}