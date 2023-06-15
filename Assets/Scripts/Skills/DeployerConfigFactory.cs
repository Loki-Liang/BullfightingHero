using System;

namespace Scripts.Skills
{
    /// <summary>
    /// 技能释放配置工厂
    /// </summary>
    public class DeployerConfigFactory //反射来实现
    {
        public static ISkillSelector CreateAttackSelector(SkillData data)//范围选择算法 
        {
            string className = string.Format("MOBASkill.{0}SkillSelector", data.selectorType);
            return CreateObject<ISkillSelector>(className);
        }
        public static IImpactEffect[] CreateImpactEffects(SkillData data) //效果算法
        {
            IImpactEffect[] impacts = new IImpactEffect[data.impactType.Length];
            for (int i = 0; i < data.impactType.Length; i++)
            {
                string classname = string.Format("MOBASkill.{0}Impact", data.impactType[i]);
                impacts[i] = CreateObject<IImpactEffect>(classname);
            }
            return impacts;
        }
        private static T CreateObject<T>(string className) where T : class//创建对应算法
        {
            Type type = Type.GetType(className);
            return Activator.CreateInstance(type) as T;
        }
    }
}
