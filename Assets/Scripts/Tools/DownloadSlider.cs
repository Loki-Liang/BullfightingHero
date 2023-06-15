using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace NetworkUtils
{
    /// <summary>
    /// 下载进度条
    /// </summary>
    public class DownloadSlider : MonoBehaviour
    {
        //进度条
        private Slider my_Slider;
 	
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="url">下载的地址</param>
        /// <returns></returns>
        IEnumerator Download(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SendWebRequest();
            if (request.isHttpError||request.isNetworkError)
            {
                print("当前的下载发生错误" + request.error);
                yield break;
            }
            while (!request.isDone)
            {
                print("当前的下载进度为：" + request.downloadProgress);
                my_Slider.value = request.downloadProgress;
                yield return 0;
            }
            if (request.isDone)
            {
                my_Slider.value = 1; 
                //将下载的文件写入
                using (FileStream fs=new FileStream(Application.streamingAssetsPath+"/Test.MP4",FileMode.Create))
                {
                    byte[] data = request.downloadHandler.data;
                    fs.Write(data, 0, data.Length);
                }
            }
        }

    }
}