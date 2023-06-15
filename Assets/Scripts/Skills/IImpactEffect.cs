using System;

namespace Scripts.Skills
{
    /// <summary>
    /// 效果算法接口
    /// </summary>
    public interface IImpactEffect // 效果算法接口
    {
        void Execute(SkillDeployer deployer); 
    }    
}
