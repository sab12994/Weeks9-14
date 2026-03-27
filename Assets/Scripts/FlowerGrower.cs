using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class FlowerGrower : MonoBehaviour
{
    public Transform flower;
    Coroutine doTheGrowingCoroutine;
    Coroutine growTheFlowerCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flower.localScale = Vector2.zero;
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

    IEnumerator DoTheGrowing()
    {
        yield return growTheFlowerCoroutine = StartCoroutine(GrowFlower());
    }
}
