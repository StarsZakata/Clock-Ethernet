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

	public void RunClockAlarm()	{
		if (SetHours && SetMinute && SetSecond)
		{
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

	/// <summary>
	/// Необходимо додумать, как исправить
	/// </summary>
	/// <param name="hours"></param>
	private void SetDataTimeAlarmHours(int hours) {
		//Debug.Log("TimeHours " + (hours / -30));

		hoursData = Mathf.Abs( hours / 30);
		SetHours = true;
	}
	private void SetDataTimeAlarmMinute(int minutes)
	{
		//Debug.Log("TimeMinute " + (minutes / -6));
		minutesData = Mathf.Abs( minutes / 6);
		SetMinute = true;
	}
	private void SetDataTimeAlarmSecond(int second)
	{
		//Debug.Log("TimeSecond " + (second / -6));
		secondData = Mathf.Abs(second / 6);
		SetSecond = true;
	}
}
