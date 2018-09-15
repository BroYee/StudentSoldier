using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    

    public float moveSpeed = 10.0f;
    //움직이는 속도를 정의해 줍니다.
    void Start()
    {
        
    }

    void Update()
    {
        MoveControl();
        //캐릭터를 움직이는 함수를 프레임마다 호출 합니다.
    }

    void MoveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //아까 지정한 Axes를 통해 키의 방향을 판단하고 속도와 프레임 판정을 곱해 이동량을 정해줍니다.
        transform.Translate(distanceX, distanceY, 0);
        //이동량만큼 실제로 이동을 반영합니다.
    }
    
}
