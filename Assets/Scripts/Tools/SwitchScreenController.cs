using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tools
{
    public class SwitchScreenController : Singleton<SwitchScreenController>
    {
        //进度条面板
        public GameObject loadScreen;

        //滑动条
        public Slider slider;

        //百分比
        public Text text;

        public GameObject _camera;

        // //别忘了给按钮添加点击事件
        // public void LoadNextLevel(AsyncOperation sceneName)
        // {
        //     StartCoroutine(Loadlevel(sceneName));
        // }
        private void Start()
        {
            _camera.SetActive(false);
        }

        public IEnumerator LoadScene(AsyncOperation sceneName)
        {
            _camera.SetActive(true);
            loadScreen.SetActive(true);
            sceneName.allowSceneActivation = false; //是否允许加载新场景？ 需要加载完自动跳转  就不用添加这句话
            while (!sceneName.isDone) //isDone 是否完成进度条
            {
                slider.value = sceneName.progress;
                text.text = sceneName.progress * 100 + "%"; //百分比
                if (sceneName.progress >= 0.90f) //如果进度条已经到达90%
                {
                    slider.value = 1; //那就让进度条的值编变成1
                    text.text = "加载完成！";
                    if (Input.anyKey) //如果点击了任意按键
                    {
                        sceneName.allowSceneActivation = true; //就可以跳转场景
                        loadScreen.SetActive(false);
                        _camera.SetActive(false);
                    }
                }

                yield return null;
            }
        }

        public void ToHome()
        {
            SceneManager.LoadSceneAsync("Scenes/MenuTo/MainMenu");
        }

        public void ToBeforeScene()
        {
        }
    }
}