using System.Collections;
using UnityEngine;

public class Grower : MonoBehaviour
{
    public Transform tree;
    public Transform banana;

    Coroutine doTheGrowingCoroutine;
    Coroutine growTheTreeCoroutine;
    Coroutine growTheBananaCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree.localScale = Vector2.zero;
        banana.localScale = Vector2.zero;
    }

    public void StartTheTreeGrow()
    {
        if(doTheGrowingCoroutine != null)
        {
            StopCoroutine(doTheGrowingCoroutine);
        }
        if(growTheTreeCoroutine != null)
        {
            StopCoroutine(growTheTreeCoroutine);
        }
        if (growTheBananaCoroutine != null)
        {
            StopCoroutine(growTheBananaCoroutine);
        }

        doTheGrowingCoroutine = StartCoroutine(DoTheGrowing());
    }

    IEnumerator DoTheGrowing()
    {
        yield return growTheTreeCoroutine = StartCoroutine(GrowTree());
        yield return growTheBananaCoroutine = StartCoroutine(GrowBanana());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GrowTree()
    {
        Debug.Log("Started growing a tree");
        tree.localScale = Vector2.zero;
        banana.localScale = Vector2.zero;
        float t = 0;
        while (t <1)
        {          
            t += Time.deltaTime;
            tree.localScale = Vector2.one * t;
            yield return null; 
        }
        Debug.Log("Finished growing a tree");
    }

    IEnumerator GrowBanana()
    {
        Debug.Log("Started growing a banana");
        banana.localScale = Vector2.zero;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            banana.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished growing a banana");
    }
}
