using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters
{
    public class RandomCharacter : MonoBehaviour
    {
        public GameObject[] characters; // 存储不同的人物

       private void Start()
        {
            int randomIndex = Random.Range(0, characters.Length); // 随机选择一个索引
            Instantiate(characters[randomIndex], transform.position, Quaternion.identity); // 在当前位置实例化选择的人物
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
    }
}