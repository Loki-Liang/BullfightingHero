using System.Collections.Generic;
using Tools;
using Cinemachine;
using SceneUtils;
using UnityEngine;

namespace Manager
{
    public sealed class GameManager : Singleton<GameManager>
    {
        [HideInInspector]
        public CharacterStats.MonoBehavior.CharacterStats playerStats;
        
        
        private CinemachineFreeLook _followCamera;
        
        protected override void Awake()
        {
            base.Awake();
        }
        

        private readonly List<IEndGameObserver> _endGameObservers = new List<IEndGameObserver>();
        public void RegisterPlayer(CharacterStats.MonoBehavior.CharacterStats player)
        {
            playerStats = player;
            _followCamera = FindObjectOfType<CinemachineFreeLook>();
            if (_followCamera!=null)
            {
                _followCamera.Follow = playerStats.transform.GetChild(1);
                _followCamera.LookAt = playerStats.transform.GetChild(1);
            }
        }

        public void AddObserver(IEndGameObserver observer)
        {
            _endGameObservers.Add(observer);
        }

        public void RemoveObserver(IEndGameObserver observer)
        {
            _endGameObservers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _endGameObservers)
            {
                observer.EndNotify();
            }
        }

        public Transform GetEntrance()
        {
            foreach (var item in FindObjectsOfType<TransitionDestination>())
            {
                if (item.destinationTag==TransitionDestination.DestinationTag.Enter)
                {
                    return item.transform;
                }
            }

            return null;
        }
        
    }
}