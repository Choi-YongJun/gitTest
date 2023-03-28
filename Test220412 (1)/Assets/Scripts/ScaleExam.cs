using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleExam : MonoBehaviour
{

    //Scale : 물체의 크기를 3좌표를 통해서 정할수 있는 변수.
    //Scale을 지정하는 변수 : Vector3(float형 변수 3개를 품을 수 있는 변수)

    //ScaleExam 스크립트가 들어간 물체에 작용하는 스크립트를 제작!
    private void Update()
    {
        ScaleTest();
    }

    public float scaleFactor;

    void ScaleTest()
    {
        //받아온 임의의 실수형 값을 통하여 물체의 크기를 조절하는 함수 제작!
        //ScaleExam 스크립트가 들어간 물체에 작용하는 스크립트를 제작!
        //1. 크기를 조정할 오브젝트의 Transform을 받아온다!
        //2. 어떤 크기로 정할것인지 정해주는 실수형 변수를 받아온다!
        //3. 받아온 실수를 통해 Vector3형 변수를 만들어 준다!
        //4. 만든 Vector3형 변수로 오브젝트의 scale을 조정한다!

        //이 스크립트가 들어간 오브젝트의 크기를 조정하려면 : 이 스크립트가 들어간 오브젝트의 트랜스폼에 접근해야한다!
        Transform tr =  this.gameObject.transform;

        Vector3 v3 = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        tr.localScale = v3;
    }
}
