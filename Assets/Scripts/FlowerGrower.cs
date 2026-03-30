using System.Collections;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

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
    public GameObject buttonPoison;
    
    public UnityEvent OnFirstTouch;
    public UnityEvent OnSecondTouch;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //no flowers in the beginning
        flower.localScale = Vector2.zero;
        flowerRight.localScale = Vector2.zero;
        flowerLeft.localScale = Vector2.zero;

     
        //buttons have their assigned state all the time
        button.SetActive(true);
        buttonRight.SetActive(true);
        buttonLeft.SetActive(true);
        buttonHeal.SetActive(false);
        buttonPoison.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!button.activeSelf && !buttonRight.activeSelf && !buttonLeft.activeSelf)
        {
            Debug.Log("the poison potion");
            OnFirstTouch.Invoke();
            
        }
        else
        {
            Debug.Log("the heal potion");
            OnSecondTouch.Invoke();
        }


        ////if all buttons are turned off, make a heal button appear
        //if (!button.activeSelf && !buttonRight.activeSelf && !buttonLeft.activeSelf)
        //{
        //    buttonHeal.SetActive(true);// doesn't work for some reason, solve it later
        //}
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
        if (growTheFlowerRightCoroutine != null)
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
        button.SetActive(false); 
        while (t < 1)
        {
            t += Time.deltaTime;
            flower.localScale = Vector2.one * t;
            yield return null;            
        }      
        
    }

    IEnumerator GrowFlowerRight()
    {
        flowerRight.localScale = Vector2.zero;
        float t = 0;
        buttonRight.SetActive(false);
        while (t < 1)
        {
            t += Time.deltaTime;
            flowerRight.localScale = Vector2.one * t;
            yield return null;            
        }
    }

    IEnumerator GrowFlowerLeft()
    {
        flowerLeft.localScale = Vector2.zero;
        float t = 0;
        buttonLeft.SetActive(false);
        while (t < 1)
        {
            t += Time.deltaTime;
            flowerLeft.localScale = Vector2.one * t;
            yield return null;            
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
    
    public void heal()
    {
        buttonHeal.SetActive(true);
    }

    public void poison()
    {
        buttonPoison.SetActive(true);
    }

}
