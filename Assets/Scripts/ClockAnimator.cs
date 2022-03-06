using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ClockAnimator : MonoBehaviour {
	/// <summary>
	/// Углы поворота
	/// </summary>
	private const float	hoursToDegrees = -30,	minutesToDegrees = -6,	secondsToDegrees = -6;
	/// <summary>
	/// Компоненты поворота
	/// </summary>
	[SerializeField] public Transform hours, minutes, seconds;
	/// <summary>
	/// Необходимо подумать, как исправить
	/// </summary>
	private float offset = 270;

	/// <summary>
	/// Хранение данных
	/// </summary>
	private ClockData currentTime;
	private void Awake() {
		currentTime = GetComponent<ClockData>();
	}
	/// <summary>
	/// Обновление данных (Можно сделать через event или вызов метода, чтобы увеличить производительность)
	/// </summary>
	void Update()
	{
		hours.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * currentTime.GetCuttentTimeForRotation().hours - offset);
		minutes.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * currentTime.GetCuttentTimeForRotation().minutes - offset);
		seconds.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * currentTime.GetCuttentTimeForRotation().second - offset);
	}
}
