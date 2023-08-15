using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderHome : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private FSMScripts.FsmPlayer Player;

    private void Awake() //Потом добавить старт для экрана загрузки
    {
        Player.Initialize();
    }
}
