using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameobjectInfo : MonoBehaviour
{
    //gameobject
    //유니티를 구성하는 가장 간단한 단위
    //씬에 있는 것들은 전부 gameobject
    //이 게임오브젝트에 어떻게 접근하나?

    public GameObject go;
    public GameObject textobj;
    public string str;

    public InputField input;

    private void Start()
    {
        go = this.gameObject;
        AddTest();
    }

    //GetComponent : 특정 GameObject에서 컴포넌트를 받아오는 함수
    //AddComponent : 특정 GameObject에 컴포넌트를 더해주는 함수
    //Component : 인스펙터 창에서 있는 요소
    //Camera를 통해서 더하고 받아오는걸 테스트!

    void AddTest()
    {
        this.gameObject.AddComponent<Camera>();
    }

    public void GetTest()
    {
        textobj.GetComponent<Text>().text = str;
        
    }
    //FindObjectOfType : 특정 컴포넌트를 하나만 찾아서 가져오는것!
    //씬에 하나밖에 없는것을 불러오는데 주로 활용! (ex)GameManager, Camera)
    //FindObjectsOfType : 특정 컴포넌트를 전부 찾아서 가져오는것!
    //버튼매니저 / 적 관리 스크립트 같은데 활용!

    public void FindTest()
    {
        //1. InputField를 활용하여 문자열을 받아온다
        //2. 씬 안에 있는 모든 Text 컴포넌트들을 찾아온다
        //3. 2에서 받아온 Text 컴포넌트들에 1에서 받아온 문자열을 일제히 넣는다.

        string str = input.text; //1번

        Text[] texts = FindObjectsOfType<Text>();//2번

        foreach (Text t in texts)
        {
            t.text = str;//3번
        }
    }

}
