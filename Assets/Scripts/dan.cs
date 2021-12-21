using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dan : MonoBehaviour
{
    private float Speed = 6;
    private dan danScript;

    private void Awake()
    {
        danScript = GetComponent<dan>();
    }

    private void LateUpdate()
    {
        transform.Translate(transform.forward * Time.deltaTime * Speed, Space.World);

        if (danScript.enabled == false)
        {
            danScript.enabled = true;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Wall":
                    var inNormal =(new Vector3(0, transform.position.y, transform.position.z) - transform.position).normalized;
                    var v3 = Vector3.Reflect(transform.forward, inNormal);
                    transform.forward = v3;
                break;

            case "Plate":
                    switch (transform.tag)
                    {
                        case "Red" : GameMain.Instance.PlateMove(0.05f);  break;
                        case "Blue": GameMain.Instance.PlateMove(-0.05f); break;
                    }
                    Destroy(gameObject);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.name)
        {

            case "Minute":
                var num = other.GetComponent<Fen>().num;
                if (num == -1)
                {
                    Destroy(gameObject);
                }

                for (int i = 1; i < num; i++)
                {
                    int count = i;
                    if (i % 2 == 0)
                    {
                        count = 1 - count;
                    }

                    var dan = Instantiate(gameObject);
                    dan.transform.parent = GameObject.Find("------Dans-------").transform;
                    dan.transform.position = transform.position + new Vector3(0.3f * count, 0, 0);
                    dan.transform.rotation = transform.rotation;
                    dan.tag = transform.tag;
                }
                break;
        }
    }
}
