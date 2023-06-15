using System;

namespace NetworkUtils
{
    [Serializable]
    public class Result
    {
        public string code ;
        public string message ;
        public object data ;
    }

    [Serializable]
    public class Token
    {
        public string token ;
    }
    
    
}