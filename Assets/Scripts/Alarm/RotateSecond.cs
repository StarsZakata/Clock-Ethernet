using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Поворот Секунлной стрелки
/// </summary>
public class RotateSecond : RotateElement
{
	/// <summary>
	/// Используем систему событий, для отправки данных "выше"
	/// </summary>
	public event UnityAction<int> UpdateAlarmSecond;

	/// <summary>
	/// Переопределяем метод
	/// </summary>
	public override void OnMouseUp()
	{
		timeSecondAlarm = false;
		Debug.Log(rotateData);
		rotateData = rotateData - rotateData % 10;
		UpdateAlarmSecond?.Invoke((int)rotateData);
	}
}
