using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

namespace NetworkUtils
{
    public class GetUserInfo :Authorization , BaseRequset

    {
        

        IEnumerator getConnect()
        {
            WWWForm wwwForm = new WWWForm();

            wwwForm.AddField("Authorization",PlayerPrefs.GetString("token"));

            UnityWebRequest webRequest = UnityWebRequest.Post("", wwwForm);
            yield return webRequest.SendWebRequest();

            if (webRequest.isDone)
            {
                Debug.Log(webRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log(webRequest.error);
            }
        }


        public IEnumerator GetData()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator Resolving()
        {
            throw new System.NotImplementedException();
        }
    }
}