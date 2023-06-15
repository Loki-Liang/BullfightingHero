using Transition;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tools
{
    public class HomeBtnController : MonoBehaviour
    {
        /// <summary>
        /// 商店
        /// </summary>
        public void Store()
        {
            Debug.Log("商店");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Store);
        }

        /// <summary>
        /// 英雄
        /// </summary>
        public void Hero()
        {
            Debug.Log("英雄");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Hero);
        }

        /// <summary>
        /// 新闻
        /// </summary>
        public void News()
        {
            Debug.Log("新闻");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.News);
        }

        /// <summary>
        /// 特别活动
        /// </summary>
        public void Event()
        {
            Debug.Log("特别活动");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Event);
        }

        /// <summary>
        /// 公会
        /// </summary>
        public void Guild()
        {
            Debug.Log("公会");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Guild);
        }

        /// <summary>
        /// 好友
        /// </summary>
        public void Friend()
        {
            Debug.Log("好友页面");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Friend);
        }

        /// <summary>
        /// 匹配游戏
        /// </summary>
        public void Battle()
        {
            Debug.Log("匹配游戏");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Level1);
        }

        /// <summary>
        /// 排位游戏
        /// </summary>
        public void Ranking()
        {
            Debug.Log("排位游戏");
            TransitionManager.Instance.Transition(Teleport.SceneName.MainMenu, Teleport.SceneName.Level2);
        }
    }
}