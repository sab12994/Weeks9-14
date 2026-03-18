using System.Collections;
using UnityEngine;

public class GrowerCG : MonoBehaviour
{
    public Transform flower;
    public GameObject button; 

    bool buttonActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flower.localScale = Vector2.zero;

        buttonActive = true;
    }

    public void DoTheGrowing()
    {
        StartCoroutine(GrowFlower());
    }

    // Update is called once per frame
    void Update()
    {
        button.SetActive(buttonActive);
    }

    IEnumerator GrowFlower()
    {
        Debug.Log("Started growing a flower");
        flower.localScale = Vector2.zero;
        float t = 0;
        while (t < 3)
        {
            t += Time.deltaTime;
            flower.localScale = Vector2.one * t;
            yield return null;

            button.SetActive(false);
        }
        Debug.Log("Finished growing a flower");
    }
}
