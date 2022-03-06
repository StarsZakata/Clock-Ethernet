using UnityEngine;
using System;
using System.Threading;


/* Google https://google.com */
public class WorldGoogleAPI :  WorldAPI {

    /// <summary>
    /// Вызов метода для обновления данных с интернета
    /// </summary>
    public override void BeginRequestDataTime()    
    {
       _currentDateTime = CheckGlobalTime();
    }
    /// <summary>
    /// Получение времени
    /// </summary>
    public DateTime GetCurrentDateTime() {
        return _currentDateTime;
    }
    /// <summary>
    /// Запрос времени с указанного URLAdress
    /// </summary>
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

