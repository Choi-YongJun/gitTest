using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iffor : MonoBehaviour
{
    //public bool b;//true / false만 가질 수 있는 자료형
    public int num;

    public int age;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(b)//조건 : 특정 코드를 실행할지 말지 정해주는 조건
        //{
        //    //내용 : 조건이 충족하면 실행할 코드
        //    print("True!");
        //}
        //if(!b)
        //{
        //    print("False!!");
        //}
        //위 코드는 수정이 필요한 코드!
        //true와 false를 구분할 때, 두 if문을 둘 다 거쳐야 한다!

        //if (b)
        //{
        //    print("True!");
        //}
        //else
        //{
        //    print("False!!");
        //}

        //if (num > 0) //숫자 비교도 결국은 true / false로 결과값이 나온다
        //{
        //    print("num은 양수 입니다!");
        //}
        //else
        //{
        //    print("num은 음수 입니다!");
        //}
    }



    //나이를 기입하고 확인버튼을 누르면 몇십대인지(10대 / 20대 / 30대....50대)보여주는 함수를 작성
    public void CheckAge()
    {
        if(age < 0)
        {
            print("올바른 나이를 적어주세요!");
            return;
        }

        if(age < 10)
        {
            print("영유아입니다!");
        }        
        //조건연산자 || / &&
        //&& : 둘 다 참일때(AND)
        //|| : 둘 중 하나만 참일때(OR)
        else if (10 <= age && age < 20)
        {
            print("10대 입니다!");
        }
        else if (20 <= age && age < 30)
        {
            print("20대 입니다!");
        }
        else if (30 <= age && age < 40)
        {
            print("30대 입니다!");
        }
        else if (40 <= age && age < 50)
        {
            print("40대 입니다!");
        }
        else if (50 <= age && age < 60)
        {
            print("50대 입니다!");
        }
        else
        {
            print("적당한 나이를 적어주세요");
        }
    }

    //조건문 : if / switch
    //if , else if , else가 있다
    //if문을 쓸땐 (조건) , {내용} 이 필요하다.
    //else문은 if문을 충족하지 못할 때만 실행한다
    //else문에서 분기점을 두고싶을때(조건에 따라서 실행하고 싶을 때) else if를 사용한다
    //if문 하나당 else문 하나만 사용 가능하며 else if문은 if와 else 사이에만 사용 가능하다

    //조건연산자
    //AND(&&) / OR(||)
    //AND는 두 조건이 참일때만 참이다
    //OR는 두 조건 중 하나만 참이라도 참이다

    //switch
    //정수형의 조건에 따라 분기를 나누는 조건문이다
    //case : 해당 정수와 값이 같을 때 실행 시키겠다는 의미의 switch문법
    //default : case들 맨 아래 위치할 수 있으며, case들 중 하나라도, 만족을 못할시에 실행 시키겠다는 의미의 switch문법

    //enum 열거형
    //코드를 작성한 사람이 항목을 설정해서 직접 열거하여 만들 수 있는 변수형

    public int switchint;

    public enum switchenum
    {
        one,
        two,
        three,
        four,        
    };

    public switchenum _switchenum;

    public void SwitchTest()
    {
        /*
        switch(switchint)
        {
            case 0:
                {
                    print("switchint는 0입니다.");
                    break;
                }
            case 1:
                {
                    print("switchint는 1입니다.");
                    break;
                }
            case 2:
                {
                    print("switchint는 2입니다.");
                    break;
                }
            case 3:
                {
                    print("switchint는 3입니다.");
                    break;
                }
            default:
                {
                    print("0,1,2,3의 정수 중 하나를 입력해주세요.");
                    break;
                }
        }
        */
        switch(_switchenum)
        {
            case switchenum.one:
                {
                    print("switchenum은 one입니다!");
                    break;
                }
            case switchenum.two:
                {
                    print("switchenum은 two입니다!");

                    break;
                }
            case switchenum.three:
                {
                    print("switchenum은 three입니다!");

                    break;
                }
            case switchenum.four:
                {
                    print("switchenum은 four입니다!");

                    break;
                }

            default:
                {
                    print("버그입니다!");
                    break;
                }
        }

    }


    //반복문
    //일정 횟수 이상 , 지정한 횟수만큼 , 여러번 특정 코드를 실행하고 싶을때 사용하는 문법이다.
    //for / while
    //for : 일정 횟수 정도만 반복하고 싶을 때. (특정횟수)
    //while : 특정 조건일때까지만 반복하고 싶을 때. (특정조건)
    //do-while : while문 이지만, 안의 내용을 초기에 한번 실행 하고, 조건 비교를 함.
    //break / continue
    //break : 지금 당장 "반복문" 밖으로 나가는것!
    //continue : 새로이 반복문을 시작하는 것.


    //foreach

    //i++ : i = i + 1;

    public void ForTest()
    {
        //받아온 num의 숫자에 도달할 때까지 0에서부터 1씩 더해서 한번씩 출력하는 함수 제작
        //for(초기식;조건식;반복식)
        for (int i = 0; i <= num; i++)
        {
            print(i);
            //내용
        }
    }

    public void WhileTest()
    {
        int i = 0;
        //특정 조건이 만족할 때 까지 반복하는 함수

        //while (i <= num)
        //{
        //    print(i);
        //    i++;
        //}

        //do
        //{
        //    print(i);
        //    i++;
        //}
        //while (i <= num);

        while (true)
        {
            if (i > num)
            {
                break;
            }
            i++;
            if (i % 2 == 1)
            {
                continue;
            }
            print(i);
        }
    }

    int[] intarray = new int[5];
    int[] intarray2 = { 1, 2, 3, 23, 412 , 3213 };
    public string[] stringarray;
    public Text[] texts;
    //배열 : 변수들의 집합체, 모든 변수에 활용 가능
    //배열의 선언은 []로써 한다
    //배열의 문법적 오류가 없도록 선언하는 방법은 2가지가 있다.
    //1. 정석 : 
    //2. 편법 public  

    public void ArrayTest()
    {
        //배열 안에 있는 성분들에 접근하여, 각각의 인자를 print하는 코드를 작성
        //배열의 순서는 0, 1, 2.... 순서대로 접근해야 함! 첫번째 인자는 0으로 접근할 수 있다.
        /*
        print(intarray2[0]);
        print(intarray2[1]);
        print(intarray2[2]);
        print(intarray2[3]);
        print(intarray2[4]);
        print(intarray2[5]);
        */

        //for (int i = 0; i < intarray2.Length; i++)
        //{
        //    print(intarray2[i]);
        //}

        //public으로 빠져서 스크립트 바깥에서 수정할 수 있는 string형의 배열 내부의 성분에 접근하여 인자들을 프린트 하는 코드
        //for(int i = 0; i < stringarray.Length; i++)
        //{
        //    print(stringarray[i]);
        //}

        //Text들을 Array화 시켜서 특정 문자열을 반복문을 활용해 적는 코드를 만듦.
        //1. public을 통해 num을 받아온다!
        //2. num에서 1씩 뺀 숫자들을 text에 적는다!

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = (num - i).ToString();
        }
    }

    //리스트 : 변수의 집합체
    //배열과의 차이점은 뭐냐? : 크기가 가변성이다.
    List<int> intlist = new List<int>();
    public void Listtest1()
    {
        //List안에 num의 숫자 요소를 넣어주는 함수
        intlist.Add(num);
    }

    public void Listtest2()
    {
        //List 안에 있는 요소들을 전부 print하는 함수
        foreach(int i in intlist)
        {
            print(i);
        }
        /*
        for(int j = 0; j < intlist.Count ; j++)
        {
            print(intlist[j]);
        }
        */
    }


    //foreach : 배열/리스트 안의 요소들에 알아서 찾아서 접근해서 그 요소들을 호출/가공/활용 할 수 있는 반복문
    //메모리 잡아먹는 괴물! -> 간단한 만큼 매우 무거우니 용법에 주의해야 한다!
    public void ForeachTest()
    {
        foreach(string s in stringarray)
        {
            print(s);
        }
    }

    //Dictionaty : 변수의 집합체
    //키 - 값 두 pair로 구성됨
    public void DictionaryTest()
    {
        Dictionary<int, string> dictest = new Dictionary<int, string>();
        dictest.Add(1, "일");
        dictest.Add(2, "이");
        dictest.Add(3, "삼");
        //dictionary 접근 방법 1
        string s = dictest[0];
        //dictionary 접근 방법 2
        if (dictest.TryGetValue(1, out s))
        {

        }
    }
}
