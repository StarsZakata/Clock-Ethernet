using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AlarmManager : MonoBehaviour
{
	[SerializeField] private TMP_InputField hoursAlarm;
	[SerializeField] private TMP_InputField minuteAlarm;
	[SerializeField] private TMP_InputField secondAlarm;

	[SerializeField] private ClockData clockData;
	private int hours, minutes, second;

	[SerializeField] private TMP_Text buttonText;

	public void RunAlarm()	{
		hours = Convert.ToInt16(hoursAlarm.text);
		minutes = Convert.ToInt16(minuteAlarm.text);
		second = Convert.ToInt16(secondAlarm.text);

		if (ChekHours(hours) && ChekMinutes(minutes) && ChekSecond(second))
		{
			hoursAlarm.text = string.Empty;
			minuteAlarm.text = string.Empty;
			secondAlarm.text = string.Empty;

			Debug.Log("Alarm: " + hours + ":" + minutes + ":" + second);
			buttonText.text = "Успешно";
			clockData.SetAlarm(hours, minutes, second);
		}
		else {
			Debug.Log("Error Data Alarm");
			buttonText.text = "Ошибка";
		}
	}

	private bool ChekHours(int hours) {
		if (hours >= 0 && hours <= 23) {
			return true;
		}
		return false;
	}
	private bool ChekMinutes(int minutes)
	{
		if (minutes >= 0 && minutes <= 60)
		{
			return true;
		}
		return false;
	}

	private bool ChekSecond(int second)
	{
		if (second >= 0 && second <= 60)
		{
			return true;
		}
		return false;
	}
}
