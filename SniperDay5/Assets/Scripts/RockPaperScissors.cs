using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RockPaperScissors : MonoBehaviour
{
    Animator animator;
    public Janken janken;

    public Button[] buttons;
    // button index
    const int start = 0;
    const int rock = 1;
    const int scissors = 2;
    const int paper = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        janken = GameObject.FindWithTag("Player").GetComponent<Janken>();
    }

    public void StartRPS()
    {
        janken.flagJanken = true;
        Debug.Log(janken.flagJanken);
        buttons[start].gameObject.SetActive(false);
        ActiveAllRPS();
    }

    void ActiveAllRPS()
    {
        buttons[rock].gameObject.SetActive(true);
        buttons[paper].gameObject.SetActive(true);
        buttons[scissors].gameObject.SetActive(true);
    }

    void DeActiveAllRPS()
    {
        buttons[rock].gameObject.SetActive(false);
        buttons[paper].gameObject.SetActive(false);
        buttons[scissors].gameObject.SetActive(false);
        buttons[start].gameObject.SetActive(true);  
    }

    public void ChooseRock()
    {
        janken.modeJanken += 1;
        Debug.Log(janken.GetGOO());
        janken.myHand = janken.GetGOO();
        DeActiveAllRPS();
    }

    public void ChoosePaper()
    {
        janken.modeJanken += 1;
        Debug.Log(janken.GetPAR());
        janken.myHand = janken.GetPAR();
        DeActiveAllRPS();
    }

    public void ChooseScissors()
    {
        janken.modeJanken += 1;
        Debug.Log(janken.GetCHOKI());
        janken.myHand = janken.GetCHOKI();
        DeActiveAllRPS();
    }
}