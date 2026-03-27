using System.Collections;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flower.localScale = Vector2.zero;
        flowerRight.localScale = Vector2.zero;
        flowerLeft.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
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
