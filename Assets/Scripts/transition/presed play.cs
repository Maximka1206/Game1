using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class presedplay : MonoBehaviour
{
    public GameObject MainMenu; // Ссылка на группу элементов главного меню
    public GameObject Play;    // Ссылка на группу элементов игры

    public void OnPlayButtonPressed()
    {
        MainMenu.SetActive(false); // Скрыть главную группу
        Play.SetActive(true);     // Показать игровую группу
    }
}
