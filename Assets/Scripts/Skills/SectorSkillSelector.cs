using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Skills
{
    /// <summary>
    /// 扇形范围的敌人检测
    /// </summary>
    public class SectorSkillSelector:ISkillSelector
    {
        GameObject[] tempGOArray;
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            //根据技能数据中得标签 获取所有目标
            List<Transform> taragets = new List<Transform>();
            for (int i = 0; i < data.attackTargetTags.Length; i++)
            {
                tempGOArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
            }
            for (int i = 0; i < tempGOArray.Length; i++)
            {
                taragets.Add(tempGOArray[i].GetComponent<Transform>());
            }
            //判断攻击范围
            taragets = taragets.FindAll(t =>
                Vector3.Distance(t.position, skillTF.position) <= data.attackDistance &&
                Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
            );
            //返回目标
            Transform[] result = taragets.ToArray();
            if (result.Length == 0)
            {
                Debug.Log("没有敌人");
                return result;
            }
            else 
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Debug.Log(result[i].name);
                }
                return result;
            }
        }
    }
}