using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldAPI : MonoBehaviour
{
	/// <summary>
	/// "http://worldtimeapi.org/api/ip"
	/// Google https://google.com
	/// </summary>
	public string URLAdress;

	public DateTime _currentDateTime = DateTime.Now;

	public virtual void BeginRequestDataTime() { }
}
