
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPattern;

public class PlayerStatus : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 10)]
    public float WalkSpeed { get; set; } // �Ѵ� �ӵ�

    [field: SerializeField]
    [field: Range(0, 10)]
    public float RunSpeed { get; set; } // �ٴ� �ӵ�

    [field: SerializeField]
    [field: Range(0, 10)]
    public float RotateSpeed { get; set; } // ȭ�� ȸ�� �ӵ�

    public ObservableProperty<bool> IsAiming { get; private set; } = new(); // ���� �ϰ� �ִ��� Ȯ��
    public ObservableProperty<bool> IsMoving { get; private set; } = new(); // �����̰� �ִ��� Ȯ��
    public ObservableProperty<bool> IsAttacking { get; private set; } = new(); // ���� �ϰ� �ִ��� Ȯ��
}
