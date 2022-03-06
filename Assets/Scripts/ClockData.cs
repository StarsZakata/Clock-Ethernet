using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;



public class ClockData : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI currentTimeData;
    [SerializeField] private AudioSource audioClip;
    [SerializeField] private EthernetManager MainEthernetManager;
    public struct TimeMy {
        public int hours;
        public int minutes;
        public int second;
    }
    public TimeMy currentTime;


    /// <summary>
    /// Отправка данных, для реализации Анимации циферблата
    /// </summary>
    /// <returns></returns>
    public TimeMy GetCuttentTimeForRotation() {
        return currentTime;
    }
    /// <summary>
    /// Структура для хранения времени будильника
    /// </summary>
    public TimeMy alarmTime;
    /// <summary>
    /// Отслеживание Запуска Будильника
    /// </summary>
    private bool alarmRun = false;
    /// <summary>
    /// Установка времени будильника
    /// </summary>
    public void SetAlarm(int hourses, int minute, int second) {
        alarmTime.hours = hourses;
        alarmTime.minutes = minute;
        alarmTime.second = second;
        alarmRun = true;
    }


	private void OnEnable()
	{
        MainEthernetManager.UpdateDataTime += SetCurrentDataFromIthernet;
    }
	private void OnDisable()
	{
        MainEthernetManager.UpdateDataTime -= SetCurrentDataFromIthernet;
    }

    /// <summary>
    /// Возможно реализовать, через Локальное время компьютера
    /// </summary>
	private void Start()
	{
        //SetCurrentTime();
        InvokeRepeating("UpdateDataTime", 0, 1); /// обновляем время (Можно реализовать через Коррутину)
    }
    /// <summary>
    /// Обновление текста (Для производительности можно сделать через систему событий или вызов метода);
    /// </summary>
	void Update() {  
        ///< Заглушка, лучше есть через UnityEvent
        if (currentTime.second <= 9)
        {
            currentTimeData.text = (currentTime.hours + ":" + currentTime.minutes + ":0" + currentTime.second);
        }
        else
        {
            currentTimeData.text = (currentTime.hours + ":" + currentTime.minutes + ":" + currentTime.second);
        }
        if (alarmRun == true) {
            RunSound(alarmTime, currentTime);
        }
    }

    /// <summary>
    /// Получение времени из интернета
    /// </summary>
    public void SetCurrentDataFromIthernet(int hours, int minute,int second) {
        Debug.Log("Время Интернета = " + hours + ":" + minute + ":" + second);
        currentTime.hours = hours;
        currentTime.minutes = minute;
        currentTime.second = second;
    }
    /// <summary>
    /// Получение Локального времени из комьютера
    /// </summary>
    private void SetCurrentTime() {
        DateTime time = DateTime.Now;
        currentTime.hours = time.Hour;
        currentTime.minutes = time.Minute;
        currentTime.second =  time.Second;
    }
    /// <summary>
    /// Обновление Данных (не заглядываю повторно в Локальное время компьютера)
    /// </summary>
    private void UpdateDataTime() {
        currentTime.second++;
        if (currentTime.second >= 60) {
            currentTime.minutes++;
            currentTime.second = 0;
        }
        if (currentTime.minutes >= 60) {
            currentTime.hours++;
            currentTime.minutes = 0;
        }
        if (currentTime.hours >= 24) {
            currentTime.hours = 0;
        }
    }

    /// <summary>
    /// Воспроизведение звука
    /// </summary>
    private void RunSound(TimeMy alarmTime, TimeMy currentTime) {
        if (alarmTime.hours == currentTime.hours && alarmTime.minutes == currentTime.minutes && alarmTime.second == currentTime.second) {
            //Debug.Log("Din-Din-Don");
            audioClip.Play();
            alarmRun = false;
        }
    }
}
