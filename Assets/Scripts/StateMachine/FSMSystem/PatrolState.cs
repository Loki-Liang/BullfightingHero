using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine.FSMSystem
{
    /// <summary>
    /// 巡逻状态
    /// </summary>
    public class PatrolState : FSMState
    {
        private List<Transform> pathList = new List<Transform>();
        private int index = 0;
        private Transform playerTrans;

        public PatrolState(FSMSystem fSMSystem) : base(fSMSystem)
        {
            currentState = CurrentState.Patrol;
            Transform pathTrans = GameObject.Find("Enemy").transform;
            Transform[] trans = pathTrans.GetComponentsInChildren<Transform>();
            foreach (Transform t in trans)
            {
                if (t != pathTrans)
                {
                    pathList.Add(t);
                }
            }

            playerTrans = GameObject.Find("Player").transform;
        }

        public CurrentState GetOutputState(Transition trans)
        {
            return CurrentState;
        }
        /// <summary>
        /// 当前状态所做的事,巡逻
        /// </summary>
        public override void Act(GameObject npc)
        {
            npc.transform.LookAt(pathList[index]);
            npc.transform.Translate(Vector3.forward * Time.deltaTime * 3);
            if (Vector3.Distance(npc.transform.position, pathList[index].position) < 0.5f)
            {
                index++;
                index %= pathList.Count;
            }
        }
        

        /// <summary>
        /// 在某一状态执行过程中，新的转换条件满足时做的事，追赶
        /// </summary>
        public override void Reason(GameObject npc)
        {
            if (Vector3.Distance(playerTrans.position, npc.transform.position) < 3)
            {
                fSMSystem.PerformTransition(Transition.SeePlayer);
            }
        }
    }
}