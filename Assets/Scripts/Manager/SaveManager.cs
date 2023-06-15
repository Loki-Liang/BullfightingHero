using System;
using CharacterStats.ScriptableObject;
using LitJson;
using Manager;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;


namespace SceneUtils
{
    public class SaveManager : Singleton<SaveManager>
    {
        private string _sceneName="";

        public string SceneName
        {
            get
            {
                return PlayerPrefs.GetString(_sceneName);
            }
        }
        
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SavePlayerData();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadPlayerData();
            }
        }

        public void LoadPlayerData()
        {
            Load(GameManager.Instance.playerStats, GameManager.Instance.playerStats.characterData.name);
        }

        public void SavePlayerData()
        {
            Save(GameManager.Instance.playerStats, GameManager.Instance.playerStats.characterData.name);
        }

        /// <summary>
        /// 保存json数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        public void Save(Object data, string key)
        {
            var jsonData = JsonUtility.ToJson(data, true);
            // var jsonData = JsonMapper.ToJson(data);
            PlayerPrefs.SetString(key, jsonData);
            PlayerPrefs.SetString(_sceneName,SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
        }

        public void Load(Object data, string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), data);
                // JsonMapper.ToObject(PlayerPrefs.GetString(key));
            }
        }
    }
}