using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform lookatTr;
    public Transform lookatTarget;

    // Update is called once per frame
    void Update()
    {
        LookatTest1();
    }

    public void LookatTest1()
    {
        //Lookat : 사람이 뭔갈 바라보듯이, 오브젝트가 특정 오브젝트를 바라보는 방향으로 Rotate하게 함!
        lookatTr.LookAt(lookatTarget);
    }
}
