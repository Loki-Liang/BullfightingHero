using System;
using System.Threading;
using UnityEngine;

namespace Base
{
    public class GameMain : MonoBehaviour
    {
        private void Awake()
        {
            // SynchronizationContext.SetSynchronizationContext(MainThreadContext);
            Application.runInBackground = true;
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

        }
    }
}