using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Общий Абстрактный класс, для реализация поворота элементов
/// </summary>

///< [RequireComponent(typeof(BoxCollider2D))]
public abstract class RotateElement : MonoBehaviour {
	[HideInInspector] public float rotateData;
	[HideInInspector] public bool timeSecondAlarm;
	private Vector2 currentPos;

	private void Start()
	{
		currentPos.x = 0;
		currentPos.y = 1;
	}
	/// <summary>
	/// Реакция на нажатие мышиы
	/// </summary>
	private void OnMouseDown()
	{
		timeSecondAlarm = true;
	}
	/// <summary>
	/// Реакция на отпускание мыши
	/// </summary>
	public virtual void OnMouseUp()	{
	}

	/// <summary>
	/// Пока мышка нажата вращаем элемент
	/// </summary>
	private void RorateElement()
	{
		Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		Vector2 tmp;
		tmp.x = diference.x;
		tmp.y = diference.y;
		rotateData = Vector2.SignedAngle(currentPos, tmp);
		rotateData = rotateData - rotateData % 10;
		transform.rotation = Quaternion.Euler(0f, 0f, rotateData + 90);
	}
	/// <summary>
	/// Повторяем каждый кадр
	/// </summary>
	private void Update()
	{
		if (timeSecondAlarm == true)
		{
			RorateElement();
		}
	}
	/// <summary>
	/// Перевод из [-180; 180] в [0; 360]
	/// </summary>
	public double NormalizeAngle(double angle)
	{
		if (angle <= 0)		{
			return angle;
		}
		else if (angle > 0)		{
			angle = 360 - angle;
		}
		return angle;
	}

}
