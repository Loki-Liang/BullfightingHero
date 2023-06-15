using System;
using System.Collections;
using UnityEngine;

namespace Scripts.Skills
{
    
    public class CharacterSkillManager : MonoBehaviour 
    {
        public SkillData[] Skills;//技能列表

        private void Awake()
        {
            foreach (var s in Skills)
            {
                InitSkill(s);
            }
        }
        //初始化技能
        private void InitSkill(SkillData data)
        {
            if (data.prefabName != null)
            {
                data.skillPrefab = Resources.Load<GameObject>("SkillPrefab/"+data.prefabName);
                data.owner = this.gameObject;
            }
        }
        //技能释放条件判断
        public SkillData PrepareSkill(int id)
        {
            SkillData data = new SkillData();
            foreach (var s in Skills)
            {
                if (s.skillId == id)
                {
                    data = s;
                }
            }
            if (data != null && data.cdRemain <= 0)//这里还有技能消耗值的判断
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        //生成技能
        /*public void GenerateSkill(SkillData data)
        {
            //创建技能预制体
            GameObject skillgo = GameObjectPool.instance.CreateObject(data.prefabName, data.skillPrefab, transform.position, transform.rotation);
            //传递技能数据给技能释放器
            SkillDeployer deployer = skillgo.GetComponent<SkillDeployer>();
            deployer.SkillData = data;
            //释放器释放技能
            deployer.DeploySkill();
            StartCoroutine(CoolTimeDown(data));//开启冷却
        }*/
        //协程实现技能冷却
        private IEnumerator CoolTimeDown(SkillData data)
        {
            data.cdRemain = data.skillCd;
            while (data.cdRemain > 0)
            {
                yield return new WaitForSeconds(1f);
                data.cdRemain -= 1;
            }
        }
    }

   
}
