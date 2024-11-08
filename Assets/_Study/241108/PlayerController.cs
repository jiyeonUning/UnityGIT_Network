using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;

    private Vector3 inputDir;


    // �����Ӹ��� ȣ��Ǵ� �Լ� Update
    // ���� ��ǻ�Ϳ��� ó���� �۾��� �����Ѵ�.
    private void Update()
    {
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");
    }

    // ��Ʈ��ũ ��� �ֱ⸶�� ȣ��Ǵ� �Լ� FixedUpdateNetwork
    // ��Ʈ��ũ���� ó���� �۾��� �����Ѵ�.
    public override void FixedUpdateNetwork()
    {
        // �� �������� ��Ʈ��ũ ������Ʈ�� �ƴѰ��, return
        if (HasStateAuthority == false) return;

        // �Է°��� ���� ���, return
        if (inputDir == Vector3.zero) return;

        controller.Move(inputDir * moveSpeed * Runner.DeltaTime);
        transform.forward = inputDir;
    }

    // ��Ʈ��ũ ������Ʈ�� ���� ���� �� ȣ��Ǵ� �Լ� Spawned
    // Awake, Start �Լ��� ��ü���ε� ���Ǳ⵵ �Ѵ�.
    public override void Spawned()
    {
        // �� �������� ��Ʈ��ũ ������Ʈ�� ���,
        if (HasStateAuthority == true)
        {
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.target = transform;
        }
    }
}
