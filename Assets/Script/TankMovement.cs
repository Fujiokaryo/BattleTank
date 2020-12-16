using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed; //移動速度
    public float turnSpeed; //旋回速度
    private Rigidbody rb;   //RigidBodyを代入する用の変数
    private float movementInputValue;　//移動値の代入用変数
    private float turnInputValue;　　　//旋回値の代入用変数
    void Start()
    {
        rb = GetComponent<Rigidbody>();　//rbにRigidbodyを代入
    }

    // Update is called once per frame
    void Update()
    {
        TankMove();
        TankTurn();
    }


    //前進・後退のメソッド
    void TankMove()
    {
        movementInputValue = Input.GetAxis("Vertical");　//前進・後退の入力待ち状態にする
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    //旋回のメソッド
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
