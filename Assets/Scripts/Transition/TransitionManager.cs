using System;
using System.Collections;
using Tools;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace Transition
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        /// <summary>
        /// 是否正在进行场景切换
        /// </summary>
        private bool isFading; //是否在进行场景切换

        // public CanvasGroup canvasGroup; //切换场景禁用鼠标

        // public float fadeDuration; //渐变持续时间

        private bool canTransition;

        private Tweener _tweener;

        private Material _material;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            isFading = false;
        }

        /// <summary>
        /// 转换场景
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void Transition(Teleport.SceneName from, Teleport.SceneName to)
        {
            if (!isFading)
            {
                StartCoroutine(TransitionToScene(from, to));
            }
        }

        /// <summary>
        /// 场景切换
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        IEnumerator TransitionToScene(Teleport.SceneName from, Teleport.SceneName to)
        {
            // yield return Fade(1);
            if (from != null) //当前场景不为空才能卸载
            {
                // EventHandler.CallBeforeSceneUnloadEvent();

                yield return SceneManager.UnloadSceneAsync(from.ToString()); //卸载当前场景
            }

            AsyncOperation
                asyncOperation = SceneManager.LoadSceneAsync(to.ToString(), LoadSceneMode.Additive); //叠加方式加载转换场景
            yield return SwitchScreenController.Instance.LoadScene(asyncOperation);
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1); //获取新加载场景
            SceneManager.SetActiveScene(newScene); //激活新加载场景

            // EventHandler.CallAfterSceneLoadedEvent();
            // yield return Fade(0);
        }

        /// <summary>
        /// 实现场景切换的渐入渐出效果
        /// </summary>
        /// <param name="targetAlpha"></param>
        /// <returns></returns>
        // private IEnumerator Fade(float targetAlpha)
        // {
        //     isFading = true;
        //
        //     canvasGroup.blocksRaycasts = true; //禁用鼠标
        //
        //     float speed = Mathf.Abs(targetAlpha - canvasGroup.alpha) / fadeDuration; //渐变速度
        //
        //     while (!Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        //     {
        //         canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
        //         yield return null;
        //     }
        //
        //     canvasGroup.blocksRaycasts = false;
        //
        //     isFading = false;
        // }
        IEnumerator Fading(float target)
        {
            _tweener = _material.DOColor(Color.red, 2);
            yield return null;
        }
    }
}