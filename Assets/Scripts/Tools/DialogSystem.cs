using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    /// <summary>
    /// 对话系统
    /// </summary>
    public class DialogSystem : MonoBehaviour
    {
        [Header("UI组件")] public Text textLabel;

        public Image FaceImage;

        [Header("文本文件")] public TextAsset textAsset;

        List<String> textList = new List<String>();


        public Sprite _faceA, _faceB;

        public Image faceImage;

        public int index;

        /// <summary>
        /// 文本加载速度
        /// </summary>
        public float textSpeed = 0.5f;

        /// <summary>
        /// 是否完成打字
        /// </summary>
        private bool textFinish;

        /// <summary>
        /// 取消打字
        /// </summary>
        private bool cancelTypeing;

        private IEnumerator _enumerator;

        private void Start()
        {
            _enumerator = SetTextUI();
        }

        private void Awake()
        {
            GetTextFile(this.textAsset);
            index = 0;
        }

        private void Update()
        {
            if (index < textList.Count && Input.GetKeyDown(KeyCode.R) && this.textFinish)
            {
                StartCoroutine(_enumerator);
            }
            else
            {
                gameObject.SetActive(false);
                index = 0;
            }
        }

        private IEnumerator SetTextUI()
        {
            switch (textList[index])
            {
                case "A":
                    faceImage.sprite = _faceA;
                    index++;
                    break;
                case "B":
                    faceImage.sprite = _faceB;
                    index++;
                    break;
            }

            textLabel.text = "";
            this.textFinish = false;
            for (int i = 0; i < textList[index].Length; i++)
            {
                textLabel.text += textList[index][i];
                yield return new WaitForSeconds(this.textSpeed);
            }

            textFinish = true;
            index++;
        }

        private void OnEnable()
        {
            textLabel.text = textList[index];
            index++;
        }

        private void GetTextFile(TextAsset textAsset)
        {
            textList.Clear();
            index = 0;

            var lineData = textAsset.text.Split('\n');
            foreach (var item in lineData)
            {
                textList.Add(item);
            }
        }
    }
}