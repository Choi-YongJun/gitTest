using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStudy : MonoBehaviour
{
    //애니메이션을 재생하는데 있어서 Animation과 Animator가 필요하다!
    //Animation : 모델링을 움직이게 만드는 한 구간의 동작!
    //Animator : Animation을 짜깁기하여 원하는 방식대로 재생할수 있도록 만들어주는 도구!
    //Animator의 구성요소 : State / Transtion / Entry / Exit / Any State / Parameter (Layer)
    //State : Animation을 담을 수 있는 칸!

    //Transtion : State간의 이동과 이동하는 조건을 담당하는 선!
    //Parameter : Transtion의 이동의 조건을 담당하는 변수!
    //댐의 수문같은 개념! : 이동할건지, 이동을 막을건지 정할 수 있다!

    //Entry : Animator의 시작지점
    //Exit : Animator의 끝지점 - 여기서 애니메이터가 Entry부터 재시작!

    //Any State : Parameter의 조건이 맞아 떨어질 때 무조건 실행!
    //Trigger를 사용해 어떤 상황에서 원하는 State가 실행되고자 할때 주로 사용!

    //N개의 유니티짱 포즈를 사용하는데, 버튼을 누르면, 해당 포즈가 바로 나오는 씬.

    //1. 내가 포즈를 잡게 만들 Animator를 밖에서 받아온다!
    //2. Animator의 trigger를 켜는 함수를 만들어준다!
    //3. 2에서 만든 함수를 버튼에 연결시켜준다!
    //4. 내가 보여주고 싶은 Animation만큼 2~3을 반복한다!

    public Animator anim;
    public void unitychan1()
    {
        anim.SetTrigger("t1");
    }

}
