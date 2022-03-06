using UnityEngine;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using System.Collections;
/* API (json) http://worldtimeapi.org/api/ip */

public class WorldTimeAPI : MonoBehaviour
{
	//JSON
	struct TimeData
	{
		public string datetime;
	}

	const string API_URL = "http://worldtimeapi.org/api/ip";
	[HideInInspector] public bool IsTimeLodaed = false;
	private DateTime _currentDateTime = DateTime.Now;

	/// <summary>
	/// Вызов метода для обновления данных с интернета
	/// </summary>
	public void BeginRequestDataTime()
	{
		StartCoroutine(GetRealDateTimeFromAPI());
	}
	/// <summary>
	/// Получение времени
	/// </summary>
	public DateTime GetCurrentDateTime()
	{
		return _currentDateTime.AddSeconds(Time.realtimeSinceStartup);
	}
	/// <summary>
	/// Запрос времени с указанного URLAdress
	/// </summary>
	IEnumerator GetRealDateTimeFromAPI()
	{
		UnityWebRequest webRequest = UnityWebRequest.Get(API_URL);
		yield return webRequest.SendWebRequest();
		if (webRequest.isNetworkError || webRequest.isHttpError)
		{
			Debug.Log("Error: " + webRequest.error);
		}
		else
		{
			TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);
			_currentDateTime = ParseDateTime(timeData.datetime);
			IsTimeLodaed = true;
		}
		yield break;
	}
	/// <summary>
	/// Парсер данных, для получение даты и времени
	/// </summary>
	DateTime ParseDateTime(string datetime)
	{
		string date = Regex.Match(datetime, @"^\d{4}-\d{2}-\d{2}").Value;
		string time = Regex.Match(datetime, @"\d{2}:\d{2}:\d{2}").Value;
		return DateTime.Parse(string.Format("{0} {1}", date, time));
	}
}

