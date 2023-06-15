using System;
using UnityEngine;
using UnityEngine.UI;

namespace Transition
{
    public class FadeInOut : MonoBehaviour
    {
        private float fadeSpeed = 1.5f;
        private Texture _texture;

        private void Start()
        {
            _texture = this.GetComponent<Texture>(); 
            new Rect(0, 0, Screen.width, Screen.height);
            

        }
    }
}