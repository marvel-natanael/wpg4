using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
public class Masker : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] scentences;
    private int index;
    public float delay;
    private bool nextLine = false;

    public event Action onShowDialog;
    public event Action onCloseDialog;

    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject dialogBox;

    public static Masker Instance { get; private set; }
    DialogList dialog;
    private void Awake()
    {
        index = 0;
        Instance = this;
    }

    private void Update()
    {
        if (textDisplay.text == scentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    public IEnumerator showDialog()
    {
        yield return new WaitForEndOfFrame();
        onShowDialog?.Invoke();
        continueButton.SetActive(true);
        dialogBox.SetActive(true);
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        foreach (char letter in scentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(delay);
        }

    }

    public void Next()
    {
        nextLine = true;
    }
    public void HandleUpdate()
    {
        if (nextLine)
        {
            continueButton.SetActive(false);
            if (index < scentences.Length - 1)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(Type());
                nextLine = false;
            }
            else
            {
                textDisplay.text = "";
                onCloseDialog?.Invoke();
                continueButton.SetActive(false);
                dialogBox.SetActive(false);
                nextLine = false;
            }
        }

    }
}
