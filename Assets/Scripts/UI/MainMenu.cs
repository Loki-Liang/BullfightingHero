using SceneUtils;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : Singleton<MainMenu>
    {
        private Button _newGameBtn;

        private Button _continueBtn;

        private Button _quiteBtn;

        protected override void Awake()
        {
            base.Awake();
            _newGameBtn = transform.GetChild(1).GetComponent<Button>();
            _continueBtn = transform.GetChild(2).GetComponent<Button>();
            _quiteBtn = transform.GetChild(3).GetComponent<Button>();
            _quiteBtn.onClick.AddListener(QuiteGame);
        }

        public void newGame()
        {
            PlayerPrefs.DeleteAll();
            //转换场景
            SceneController.Instance.TransitionToFirstLevel();
        }


        public void continueGame()
        {
            //转换场景，读取进度
        }


        public void QuiteGame()
        {
            Application.Quit();
            Debug.Log("退出游戏");
        }
    }
}