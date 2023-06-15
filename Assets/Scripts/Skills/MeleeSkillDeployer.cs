using System;

namespace Scripts.Skills
{
    /// <summary>
    /// 近战技能释放例子
    /// </summary>
   public class MeleeSkillDeployer : SkillDeployer//近战技能释放例子
    {
        public override void DeploySkill()
        {
            //执行选区算法
            CalculateTargets();
            //执行影响算法
            ImpactTargets();
        }
    }
}
