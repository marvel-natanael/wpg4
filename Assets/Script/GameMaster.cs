using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { FreeRoam, Dialog }
public class GameMaster : MonoBehaviour
{
    GameState state;
    [SerializeField] PlayerControl playerController;
    public static bool masker, sanitizer, vit, n95;
    DialogList dialog;
    private void Start()
    {
        masker = false;
        sanitizer = false;
        vit = false;
        n95 = false;
        StartCoroutine(Dialog.Instance.showDialog());
        Dialog.Instance.onShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        Dialog.Instance.onCloseDialog += () =>
        {
            if (state == GameState.Dialog)
                state = GameState.FreeRoam;
            Boss.gameStart = true;
        };
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Dialog)
        {
            Dialog.Instance.HandleUpdate();
        }
    }
}
