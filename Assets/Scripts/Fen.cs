using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fen : MonoBehaviour
{
    public int num;
    private void Awake()
    {
        num = Random.Range(1, 4);
        if (num <= 1)
        {
            num = -1;
        }
    }

    private void Start()
    {
        transform.Find("Text").GetComponent<TextMesh>().text = num.ToString() + "±¶";
    }
}
