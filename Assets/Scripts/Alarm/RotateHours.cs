using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Поворот Часовой стрелки
/// </summary>
public class RotateHours : RotateElement {
	/// <summary>
	/// Используем систему событий, для отправки данных "выше"
	/// </summary>
	public event UnityAction<int> UpdateAlarmHours;

	/// <summary>
	/// Переопределяем метод
	/// </summary>
	public override void OnMouseUp()
	{
		timeSecondAlarm = false;
		Debug.Log(rotateData);
		rotateData = rotateData - rotateData % 10;
		UpdateAlarmHours?.Invoke((int)rotateData);
	}

}
