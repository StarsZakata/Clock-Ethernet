using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Общий Абстрактный класс, для реализация поворота элементов
/// </summary>

///< [RequireComponent(typeof(BoxCollider2D))]
public abstract class RotateElement : MonoBehaviour
{
	public float rotateData;
	public bool timeSecondAlarm;

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
	public virtual void OnMouseUp()
	{
		
	}

	/// <summary>
	/// Пока мышка нажата вращаем элемент
	/// </summary>
	private void RorateElement()
	{
		Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		rotateData = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotateData);
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

}
