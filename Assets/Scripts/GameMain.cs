using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    //µ¥Àý
    private static GameMain instance;
    public static GameMain Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameMain();
            }
            return instance;
        }
    }

    public Button refresh;
    public GameObject Plate;

    private float minutesCd = 0;
    private GameObject Minute;
    private Transform MinutesParent;
    private Transform DansParent;

    private void Awake()
    {
        instance = this;
        Minute = Resources.Load<GameObject>("Fen");
        MinutesParent = GameObject.Find("------Minutes-------").transform;
        DansParent = GameObject.Find("------Dans-------").transform;
    }

    private void Start()
    {
        refresh.onClick.AddListener(RefreshGame);
        refresh.gameObject.SetActive(false);
    }

    private void Update()
    {
        minutesCd += Time.deltaTime;
        if (minutesCd >= 4)
        {
            DelFens();
            for (int i = 0; i < 4; i++)
            {
                var xPos = Random.Range(4, -4);
                var zPos = Random.Range(1, 7);
                CreateMinute(new Vector3(xPos,1, zPos));
            }
            for (int i = 0; i < 4; i++)
            {
                var xPos = Random.Range(4, -4);
                var zPos = Random.Range(-1, -7);
                CreateMinute(new Vector3(xPos, 1, zPos));
            }
            minutesCd = 0;
        }
    }



    /// <summary>
    /// °åµÄÒÆ¶¯
    /// </summary>
    /// <param name="value"></param>
    public void PlateMove(float value)
    {
        Plate.transform.position += new Vector3(0, 0, value);
        if (Plate.transform.position.z >= 8.5f || Plate.transform.position.z <= -8.5f)
        {
            EndGame();
        }
    }



    private void EndGame()
    {
        refresh.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void RefreshGame()
    {
        DelFens();
        DelDans();
        Plate.transform.position = Vector3.zero;
        refresh.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void DelFens()
    {
        var objs = MinutesParent.GetComponentsInChildren<Fen>();
        for (int i = 0; i < objs.Length; i++)
        {
            var obj = objs[i];
            Destroy(obj.gameObject);
        }
    }

    private void DelDans()
    {
        var objs = MinutesParent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < objs.Length; i++)
        {
            var obj = objs[i];
            Destroy(obj.gameObject);
        }
    }

    private void CreateMinute(Vector3 pos)
    {
        var obj = Instantiate(Minute);
        obj.transform.position = pos;
        obj.transform.parent = MinutesParent;
        obj.name = "Minute";
    }
}
