using System.Collections;
using UnityEngine;

namespace Scripts.Skills
{
    /// <summary>
    /// 敌人添加一个击飞Buff
    /// </summary>
    public class BlowFlyImpact : IImpactEffect
    {
        private SkillData data;
        public void Execute(SkillDeployer deployer)
        {
            data = deployer.SkillData;
            deployer.StartCoroutine(ContinuousBlowFly(deployer));
        }
        // public void BlowFly(Transform transform)//给敌人添加Buff 
        // {
        //     CharacterData cd = transform.GetComponent<CharacterData>();
        //     BuffManager.instance.AllBuffs[0].currentTarget = cd;
        //     cd.AddBuff(BuffManager.instance.AllBuffs[0]);
        // }
        IEnumerator ContinuousBlowFly(SkillDeployer deployer) //每隔0.05秒检测一次敌人
        {
            float time = 0;
            do
            {
                yield return new WaitForSeconds(0.05f);
                time += 0.05f;
                deployer.CalculateTargets();
                if (data.attackTargets.Length != 0) 
                {
                    foreach (var t in data.attackTargets) 
                    {
                        // BlowFly(t);
                    }
                }
            } while (time < 0.4f);
        }
    }
}