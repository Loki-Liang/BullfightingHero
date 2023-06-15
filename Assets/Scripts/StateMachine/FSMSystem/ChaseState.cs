using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace StateMachine.FSMSystem
{
    /// <summary>
    /// 追赶状态
    /// </summary>
    public class ChaseState : FSMState
    {
        private Transform playerTrans;

        private Animator _animator;
        public ChaseState(FSMSystem fSMSystem) : base(fSMSystem)
        {
            currentState = CurrentState.Chase;
            playerTrans = GameObject.Find("Player").transform;
        }

        /// <summary>
        /// 当前状态所做的事，追赶
        /// </summary>
        public override void Act(GameObject npc)
        {
            npc.transform.LookAt(playerTrans);
            npc.transform.Translate(Vector3.forward * Time.deltaTime * 2);
            _animator=npc.GetComponent<Animator>();

        }

        /// <summary>
        /// 在某一状态执行过程中，新的转换条件满足时做的事，继续巡逻
        /// </summary>
        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(playerTrans.position, npc.transform.position) > 6)
            {
                fSMSystem.PerformTransition(Transition.LostPlayer);
            }
        }
    }
}