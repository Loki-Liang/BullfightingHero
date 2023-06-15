using System;
using System.Collections;
using LitJson;
using Tools;
using UnityEngine;
using UnityEngine.Networking;

namespace NetworkUtils
{
    public class Authorization : Singleton<Authorization>
    {
    
    
        private Result result;
        
        [SerializeField] public string host = "127.0.0.1";
        [SerializeField] public int port = 8080;
        [SerializeField] public string username = "admin";
        [SerializeField] public string password = "admin";

        protected override void Awake()
        {
            base.Awake();
            GetAuthorization();
        }

        

        private void GetAuthorization()
        {
            StartCoroutine(getTokenEnumerator());
            Token token = JsonMapper.ToObject<Token>(result.data.ToString());
            PlayerPrefs.SetString("token",token.token.ToString());
        }

        IEnumerator getTokenEnumerator()
        {
            WWWForm wf = new WWWForm();
            wf.AddField("username", username);
            wf.AddField("password", password);
            UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost:8080/login", wf);
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                var message = webRequest.downloadHandler.text;
                Debug.Log(message);
                result = JsonMapper.ToObject<Result>(message);
                
            }
            
        }
    }
}