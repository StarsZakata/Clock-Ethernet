using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

public class EthernetManager : MonoBehaviour {
	[SerializeField] private WorldTimeAPI One_Ethernet;
	[SerializeField] private WorldGoogleAPI Two_Ethernet;
	private Coroutine coroutine;

	// Проверка времени каждые 15 секунд
	[SerializeField] private int TimeDelaySecond = 15;
	// Флаг, для запущенной коррутины
	[SerializeField] private bool swap = false;

	public event UnityAction<int, int, int> UpdateDataTime;

	/// <summary>
	/// Запускаем Одну из Коррутин для получения времени из интернет-соединения
	/// </summary>
	private void Start()
	{
		SetSwapTransinCorotine();
	}
	/// <summary>
	/// Дополнительный метод
	/// Реализация отключения коррутины и запуск другой коррутины
	/// </summary>
	public void BeginEthernerCoroutine()
	{
		StopCoroutine(coroutine);
		coroutine = null;
		SetSwapTransinCorotine();
	}
	/// <summary>
	/// Меняем Корутины
	/// </summary>
	public void SetSwapTransinCorotine()
	{
		swap = !swap;
		if (swap == false)
		{
			coroutine = StartCoroutine(Two_EthernetWorldGoogleApi());
		}
		else
		{
			coroutine = StartCoroutine(One_EthernetWorldTimeAPI());
		}
	}

	/// <summary>
	/// Корутина, опрашивающая интернет-соединение, через JSON и UnityWebRequest
	/// </summary>
	/// <returns></returns>
	IEnumerator One_EthernetWorldTimeAPI() {
		yield return new WaitForSeconds(0.25f);
		while (true) {
			One_Ethernet.BeginRequestDataTime();
			DateTime currentDateTime = One_Ethernet.GetCurrentDateTime();
			Debug.Log("OneAPI = " + currentDateTime);
			UpdateDataTime?.Invoke(currentDateTime.Hour, currentDateTime.Minute, currentDateTime.Second);
			yield return new WaitForSeconds(TimeDelaySecond);
		}
	}
	/// <summary>
	/// Корутина, опрашивающая интернет-соединение, через WWW
	/// </summary>
	/// <returns></returns>
	IEnumerator Two_EthernetWorldGoogleApi() {
		yield return new WaitForSeconds(0.25f);
		while (true) {
			Two_Ethernet.BeginRequestDataTime();
			DateTime currentDateTime = Two_Ethernet.GetCurrentDateTime();
			Debug.Log("Google time: " + currentDateTime);
			UpdateDataTime?.Invoke(currentDateTime.Hour + 3, currentDateTime.Minute, currentDateTime.Second);
			yield return new WaitForSeconds(TimeDelaySecond);
		}
	}
}
