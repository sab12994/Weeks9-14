using System.Collections;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class FlowerGrower : MonoBehaviour
{
    public Transform flower;
    public Transform flowerRight;
    public Transform flowerLeft;
    Coroutine doTheGrowingCoroutine;
    Coroutine growTheFlowerCoroutine;
    Coroutine growTheFlowerRightCoroutine;
    Coroutine growTheFlowerLeftCoroutine;

    public GameObject button;
    public GameObject buttonRight;
    public GameObject buttonLeft;
    public GameObject buttonHeal;
    bool buttonActive;
    bool buttonRightActive;
    bool buttonLeftActive;
    bool buttonHealActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //no flowers in the beginning
        flower.localScale = Vector2.zero;
        flowerRight.localScale = Vector2.zero;
        flowerLeft.localScale = Vector2.zero;

        //set buttons' states
        buttonActive = true;
        buttonRightActive = true;
        buttonLeftActive = true;
        buttonHealActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        //buttons have their assigned state all the time
        button.SetActive(buttonActive);
        buttonRight.SetActive(buttonRightActive);
        buttonLeft.SetActive(buttonLeftActive);
        buttonHeal.SetActive(buttonHealActive);

        //if all buttons are turned off, make a heal button appear
        if(buttonActive == false && buttonRightActive == false && buttonLeftActive == false)
        {
            buttonHeal.SetActive(true);// doesn't work for some reason, solve it later
        }
    }

    public void StartTheFlowerGrow()
    {
        if (doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if (growTheFlowerCoroutine != null)
        {
            StopCoroutine(growTheFlowerCoroutine);
        }
        doTheGrowingCoroutine = StartCoroutine(DoTheGrowing());

    }

    public void StartTheFlowerRightGrow()
    {
        if (doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if (growTheFlowerCoroutine != null)
        {
            StopCoroutine(growTheFlowerRightCoroutine);
        }
        doTheGrowingCoroutine = StartCoroutine(DoTheRightGrowing());
    }

    public void StartTheFlowerLeftGrow()
    {
        if (doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if (growTheFlowerLeftCoroutine != null)
        {
            StopCoroutine(growTheFlowerLeftCoroutine);
        }
        doTheGrowingCoroutine = StartCoroutine(DoTheLeftGrowing());
    }

    IEnumerator GrowFlower()
    {        
        flower.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            flower.localScale = Vector2.one * t;
            yield return null;

            button.SetActive(false);
        }      
        
    }

    IEnumerator GrowFlowerRight()
    {
        flowerRight.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            flowerRight.localScale = Vector2.one * t;
            yield return null;

            buttonRight.SetActive(false);
        }
    }

    IEnumerator GrowFlowerLeft()
    {
        flowerLeft.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            flowerLeft.localScale = Vector2.one * t;
            yield return null;

            buttonLeft.SetActive(false);
        }
    }

    IEnumerator DoTheGrowing()
    {
        yield return growTheFlowerCoroutine = StartCoroutine(GrowFlower());        
    }

    IEnumerator DoTheRightGrowing()
    {       
        yield return growTheFlowerRightCoroutine = StartCoroutine(GrowFlowerRight());        
    }

    IEnumerator DoTheLeftGrowing()
    {
        yield return growTheFlowerRightCoroutine = StartCoroutine(GrowFlowerLeft());
    }
}
