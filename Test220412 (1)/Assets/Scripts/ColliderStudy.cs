using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStudy : MonoBehaviour
{
    //Collider : 유니티의 체계 안에서 물체(게임오브젝트 / GameObject)를 인지하기 위한 수단
    //Rendering : 그린다 - 유니티 씬 안에 물체들을 그리는 모든 행위
    //렌더링은 보이도록 그려주는 개념!
    //콜라이더는 유니티 씬 상에서 유니티가 물체를 인식하도록 만들기 위한 수단!
    //Rigidbody : 물리엔진상에서 물리연산(충돌, 질량, 가속, 힘받음)을 연산하는것을 담당하는 컴포넌트


    //Collision : 충돌! - 유니티 상의 물리엔진 설정을 통해서 일어나는 콜라이더간의 충돌!
    //Trigger : 충돌이 일어나지 않고, 콜라이더간의 만남만을 통해서 작용하는 상호작용!

    //Enter , Stay , Exit
    //Enter : 처음 두 콜라이더가 만났을때만 실행.
    //Stay : 두 콜라이더가 맞닿아 있을 때 반복 실행.
    //Exit : 두 콜라이더가 떨어지는 순간 실행.(Bug가 너무 많음!)


    private void OnCollisionEnter(Collision collision)
    {
        //해당 스크립트가 들어있는 게임오브젝트가 충돌(Collision)이 일어났을 때, 딱 한번만 호출!
        //collision : 해당 스크립트가 들어있는 게임오브젝트와 충돌이 일어난 오브젝트에 대한 정보!
        //print(collision.gameObject.name + "과 충돌을 시작했습니다!");   
    }

    private void OnCollisionStay(Collision collision)
    {
        //해당 스크립트가 들어있는 게임오브젝트가 충돌(Collision)이 일어났을 때, 맞닿아 있는 동안 호출!
        //collision : 해당 스크립트가 들어있는 게임오브젝트와 충돌이 일어난 오브젝트에 대한 정보!
        //print(collision.gameObject.name + "과 맞닿아 있는 중입니다!");
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name + "물체와 TriggerEnter 했습니다!");
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    //Collision : 두 콜라이더가 맞닿았을때, 더 명확한 물리적인 운동을 제시.
    //Trigger : 두 콜라이더가 맞닿는것에 대한 정보만 제시.
    //따라서 Collision보다 Trigger가 더 연산적으로(성능적으로) 가벼움! -> Trigger가 좀 더 보편적으로 활용!
    //Collision의 용법 : 두 물체의 충돌, 파편 분산.
    //Trigger의 용법 1 : 일정 범위에 특정 오브젝트(ex)스킬범위에 적오브젝트)가 있는지에 대한 판단.
    //Trigger의 용법 2 : 워프,NPC에게 대화를 걸수 있는지에 대한 여부 (특정 공간에 플레이어가 맞닿으면, 상호작용이 일어나는 행위)

    //Trigger의 범주 : Collider컴포넌트 - IsTrigger가 맞닿는 두 물체중 하나라도 켜져있다면, OnTrigger를 활용할 수 있다!
    //Collision을 활용하기 위해서는 IsTrigger가 둘 다 꺼져있어야 한다.
}
