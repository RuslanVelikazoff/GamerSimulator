using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderHome : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private FSMScripts.FsmPlayer Player;

    [Space(7)]

    [Header("База данных")]
    [SerializeField] private Data.StartData Data;

    private void Start()
    {
        Data.Initialize();
        Player.Initialize();
    }
}
