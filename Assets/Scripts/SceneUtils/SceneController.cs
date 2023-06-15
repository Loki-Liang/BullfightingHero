using System.Collections;
using Manager;
using Tools;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace SceneUtils
{
    public class SceneController : Singleton<SceneController>
    {
        private GameObject player;
        private GameObject playerProfab;

        public NavMeshAgent playerAgent;

        /// <summary>
        /// 转换到目标点
        /// </summary>
        /// <param name="transitionPoint"></param>
        public void TransitionDestination(TransitionPoint transitionPoint)
        {
            switch (transitionPoint.transitionType)
            {
                case TransitionPoint.TransitionType.SameScene:
                    StartCoroutine(Transition(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,
                        transitionPoint.destinationTag));
                    break;
                case TransitionPoint.TransitionType.DifferentScene:
                    StartCoroutine(Transition(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name,
                        transitionPoint.destinationTag));
                    break;
            }


            //转换场景协程
            IEnumerator Transition(string scenename, TransitionDestination.DestinationTag destinationTag)
            {
                SaveManager.Instance.SavePlayerData();
                
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != scenename)
                {
                    yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scenename);
                    yield return Instantiate(playerProfab, GetDestination(destinationTag).transform.position,
                        GetDestination(destinationTag).transform.rotation);
                    SaveManager.Instance.LoadPlayerData();
                    yield break;
                }
                else
                {
                    player = GameManager.Instance.playerStats.gameObject;
                    playerAgent = player.GetComponent<NavMeshAgent>();
                    playerAgent.enabled = false;
                    player.transform.SetPositionAndRotation(
                        GetDestination(destinationTag).transform.position,
                        GetDestination(destinationTag).transform.rotation);
                    playerAgent.enabled = true;
                    yield return null;
                }
            }
        }

        public void TransitionToFirstLevel()
        {
            StartCoroutine(LoadLevel("Game"));
        }
        
        /// <summary>
        /// 加载场景生产player
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        IEnumerator LoadLevel(string sceneName)
        {
            if (sceneName != "")
            {
                yield return SceneManager.LoadSceneAsync(sceneName);
                yield return player = Instantiate(playerProfab,
                    GameManager.Instance.GetEntrance().position,
                    GameManager.Instance.GetEntrance().rotation);
            }
        }

        /// <summary>
        /// 获取目标点
        /// </summary>
        /// <param name="destinationTag"></param>
        /// <returns></returns>
        private TransitionDestination GetDestination(TransitionDestination.DestinationTag destinationTag)
        {
            var entrances = FindObjectsOfType<TransitionDestination>();
            for (int i = 0; i < entrances.Length; i++)
            {
                if (entrances[i].destinationTag == destinationTag)
                {
                    return entrances[i];
                }
            }

            return null;
        }

        public void TransitionToLoadGame()
        {
            StartCoroutine(LoadLevel(SaveManager.Instance.SceneName));
        }
        
    }
    
    
}