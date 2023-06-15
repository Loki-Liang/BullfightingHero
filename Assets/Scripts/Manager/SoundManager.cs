using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Manager
{
    /// <summary>
    /// 声音管理器
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : Singleton<SoundManager>
    {
        private AudioSource _audioSource;

        private Dictionary<string, AudioClip> _dictAudio;

        protected override void Awake()
        {
            base.Awake();
            _audioSource = GetComponent<AudioSource>();
            _dictAudio = new Dictionary<string, AudioClip>();
        }


        /// <summary>
        /// 辅助函数：加载音频，需要确保音频文件的路径在Resources文件下
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public AudioClip LoadAudio(string path)
        {
            return (AudioClip)Resources.Load(path);
        }

        /// <summary>
        /// 辅助函数：获取音效，并且将其缓存到dictAudio中，避免重复
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private AudioClip GetAudioClip(string path)
        {
            if (!_dictAudio.ContainsKey(path))
            {
                _dictAudio[path] = LoadAudio(path);
            }

            return _dictAudio[path];
        }

        public void PlayBGM(string name, float volume = 1f)
        {
            _audioSource.Stop();
            _audioSource.clip = GetAudioClip(name);
            _audioSource.Play();
        }

        public void StopBGM()
        {
            _audioSource.Stop();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="path"></param>
        /// <param name="volume"></param>
        public void PlaySound(string path, float volume = 1f)
        {
            //PlayOneShot可以叠加播放
            this._audioSource.PlayOneShot(LoadAudio(path));
            // this._audioSource.volume = volume;
        }

        /// <summary>
        /// 3d场景获取到AudioSource距离相关播放
        /// </summary>
        /// <param name="audioSource"></param>
        /// <param name="path"></param>
        /// <param name="volume"></param>
        public void PlaySound(AudioSource audioSource, string path, float volume = 1f)
        {
            audioSource.PlayOneShot(LoadAudio(path));

            audioSource.volume = volume;
        }
    }
}