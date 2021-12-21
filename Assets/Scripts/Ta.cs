using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ta : MonoBehaviour
{
    public float fire_Cd = 0.2f;//�ӵ��Ŀ���cd

    private GameObject danObj;
    private Transform firePos;
    private Transform danParent;

    private void Awake()
    {
        switch (transform.name)
        {
            case "Turret_Red": danObj = Resources.Load<GameObject>("Dan_Red"); break;
            case "Turret_Blue": danObj = Resources.Load<GameObject>("Dan_Blue"); break;
        }
        firePos = transform.Find("Fire");
        danParent = GameObject.Find("------Dans-------").transform;
    }

    private void Start()
    {
        //����
        StartCoroutine(UpdateFire());
    }

    private void LateUpdate()
    {
        //�����������
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(new Vector3(worldPos.x, transform.position.y, worldPos.z));
    }

    /// <summary>
    /// ��������
    /// </summary>
    /// <returns></returns>
    private IEnumerator UpdateFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fire_Cd);
            CreateDan();
        }
    }

    /// <summary>
    /// �����ӵ�ʵ��
    /// </summary>
    private void CreateDan()
    {
        var dan = Instantiate(danObj);
        dan.transform.position = firePos.position;
        dan.transform.rotation = transform.rotation;
        dan.transform.parent = danParent;
        dan.tag = transform.tag;
    }


}
