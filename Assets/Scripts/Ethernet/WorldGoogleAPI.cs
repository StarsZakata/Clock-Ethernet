using UnityEngine;
using System;
using System.Threading;


/* Google https://google.com */
public class WorldGoogleAPI :  WorldAPI {
    public override void BeginRequestDataTime()    
    {
       _currentDateTime = CheckGlobalTime();
    }
    public DateTime GetCurrentDateTime() {
        return _currentDateTime;
    }
    private DateTime CheckGlobalTime() {
        var www = new WWW(URLAdress);
        while (!www.isDone && www.error == null)
        {
            Thread.Sleep(1);
        }
        var str = www.responseHeaders["Date"];
        DateTime dateTime;
        if (!DateTime.TryParse(str, out dateTime))
            return DateTime.MinValue;
        return dateTime.ToUniversalTime();
        
    }
}

