using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationTest : MonoBehaviour
{
    //이 스크립트가 들어있는 오브젝트가 일정한 속도로 y좌표로 빙글빙글 도는 스크립트
    // Update is called once per frame

    public int speed;

    void Update()
    {
        //1. 이 스크립트가 들어있는 오브젝트의 트랜스폼에 접근할 수 있도록 변수로 지정!
        //2. 어떤 속도로 돌것인지 변수를 지정!(밖에서 접근 가능하도록!)
        //3. 속도와 물체가 정해졌으니, 물체를 y 로테이션 값으로 빙글빙글 돌려보자!
        //3번을 진행하기 위해서 Eular를 사용!
        Transform tr = this.gameObject.transform;

        tr.rotation = Quaternion.Euler(tr.rotation.eulerAngles.x 
            ,tr.rotation.eulerAngles.y 
            + speed * Time.deltaTime * 20 
            , tr.rotation.eulerAngles.z);

    }

}
