using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Поворот Минутной стрелки
/// </summary>
public class RotateMinute : RotateElement
{
	/// <summary>
	/// Используем систему событий, для отправки данных "выше"
	/// </summary>
	public event UnityAction<int> UpdateAlarmMinute;

	/// <summary>
	/// Переопределяем метод 
	/// </summary>
	public override void OnMouseUp()
	{
		timeSecondAlarm = false;
		var normDegree = NormalizeAngle(rotateData);
		UpdateAlarmMinute?.Invoke((int)normDegree);
	}

}
