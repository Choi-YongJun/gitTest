using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    //유니티 기반 코딩
    //c#기반 = 간단
    //변수 / 함수 / 조건문 / 반복문 . . . . .
    // 22년 4월 12일
    // Start is called before the first frame update

    //(private) (선언) (이름)
    public int i;
    private float f;
    public string s;
    public Text t;
    
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void unity()
    {
        int j = 0;
        i = i + 1;
        j = j + 1;
        print(i);
        print(j);
    }


    public int cal1;
    public int cal2;
    
    int plus(int i1 , int i2)
    {
        int i = i1 + i2;
        return i;
    }

    int minus(int i1, int i2)
    {
        int i = i1 - i2;
        return i;
    }


    public void PlusButton()
    {
        int i;
        i = plus(cal1, cal2);
        print(i);
    }

    public void MinusButton()
    {
        int i;
        i = minus(cal1, cal2);
        print(i);
    }
    

}
