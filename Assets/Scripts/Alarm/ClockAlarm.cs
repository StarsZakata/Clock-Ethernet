using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockAlarm : MonoBehaviour {
	[SerializeField] private RotateHours rotateHours;
	[SerializeField] private RotateMinute rotateMinute;
	[SerializeField] private RotateSecond rotateSecond;

	[SerializeField] private ClockData clockData;
	private int hoursData, minutesData, secondData;

	[SerializeField] private TMP_Text buttonText;

	/// <summary>
	/// Запуск Будильника 
	/// </summary>
	public void RunClockAlarm()	{
		if (SetHours && SetMinute && SetSecond)
		{
			if(clockData.currentTime.hours > 12) {
				hoursData += 12;
			}
			Debug.Log("Alarm: " + hoursData + ":" + minutesData + ":" + secondData);
			clockData.SetAlarm(hoursData, minutesData, secondData);
			buttonText.text = "Успешно";
		}
		else
		{
			Debug.Log("Error Data ClockAlarm");
			buttonText.text = "Ошибка";
		}

	}

	private bool SetHours, SetMinute, SetSecond;

	private void OnEnable()
	{
		rotateHours.UpdateAlarmHours += SetDataTimeAlarmHours;
		rotateMinute.UpdateAlarmMinute += SetDataTimeAlarmMinute;
		rotateSecond.UpdateAlarmSecond += SetDataTimeAlarmSecond;

	}
	private void OnDisable()
	{
		rotateHours.UpdateAlarmHours -= SetDataTimeAlarmHours;
		rotateMinute.UpdateAlarmMinute -= SetDataTimeAlarmMinute;
		rotateSecond.UpdateAlarmSecond -= SetDataTimeAlarmSecond;
	}
	/////////////////////////////////////////////////////
	/// <summary>
	/// Получение времени
	/// </summary>
	private void SetDataTimeAlarmHours(int hours) {
		hoursData = Mathf.Abs( hours / 30);
		SetHours = true;
	}
	private void SetDataTimeAlarmMinute(int minutes)
	{
		minutesData = Mathf.Abs( minutes / 6);
		SetMinute = true;
	}
	private void SetDataTimeAlarmSecond(int second)
	{
		secondData = Mathf.Abs(second / 6);
		SetSecond = true;
	}
	////////////////////////////////////////////////////////



}
