using System.Collections;
using UnityEngine;

namespace NetworkUtils
{
    public interface BaseRequset
    {
        IEnumerator GetData();
        
        IEnumerator Resolving();
    }
}