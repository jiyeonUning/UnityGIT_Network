using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] PlayerModel playerModel;
    [SerializeField] Weapon weapon;

    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;

    private Vector3 inputDir;


    // �����Ӹ��� ȣ��Ǵ� �Լ� Update
    // ���� ��ǻ�Ϳ��� ó���� �۾��� �����Ѵ�.
    private void Update()
    {
        inputDir.x = Input.GetAxisRaw("Horizontal");
        inputDir.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HasStateAuthority == false) return;

            weapon.Fire();
        }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    // Rpc = ���� �Լ� ȣ��
    // RpcSources = ���� �ش� �Լ��� ������ �� �ִ��� �������� �� �ִ�.
    // RpcTargets = ���� �ش� �Լ��� ������ ������ �������� �� �ִ�.
    public void TakeHitRpc(int damage)
    {
        playerModel.hp--;
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

        playerModel.hp = playerModel.maxHp;
    }
}
