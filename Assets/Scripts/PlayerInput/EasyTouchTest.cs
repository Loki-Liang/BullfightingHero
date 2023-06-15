using System;
using HedgehogTeam.EasyTouch;
using Tools;
using UnityEngine;

namespace PlayerInput
{
    public class EasyTouchTest : Singleton<EasyTouchTest>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void OnEnable()
        {
            EasyTouch.On_Swipe += On_swipe;
        }

        private void On_swipe(Gesture gesture)
        {
            Vector3 ve = new Vector3(gesture.deltaPosition.y, gesture.deltaPosition.x, 0);
            transform.Rotate(ve,Space.World);
        }
    }
}