
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;

public class PlayerStatus : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 10)]
    public float WalkSpeed { get; set; } // 겉는 속도

    [field: SerializeField]
    [field: Range(0, 10)]
    public float RunSpeed { get; set; } // 뛰는 속도

    [field: SerializeField]
    [field: Range(0, 10)]
    public float RotateSpeed { get; set; } // 화면 회전 속도

    public ObservableProperty<bool> IsAiming { get; private set; } = new(); // 조준 하고 있는지 확인
    public ObservableProperty<bool> IsMoving { get; private set; } = new(); // 움직이고 있는지 확인
    public ObservableProperty<bool> IsAttacking { get; private set; } = new(); // 공격 하고 있는지 확인
}
