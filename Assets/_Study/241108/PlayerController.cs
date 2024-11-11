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


    // 프레임마다 호출되는 함수 Update
    // 개인 컴퓨터에서 처리할 작업을 구현한다.
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
    // Rpc = 원격 함수 호출
    // RpcSources = 누가 해당 함수를 실행할 수 있는지 설정해줄 수 있다.
    // RpcTargets = 누가 해당 함수를 실행할 것인지 설정해줄 수 있다.
    public void TakeHitRpc(int damage)
    {
        playerModel.hp--;
    }


 
    // 네트워크 통신 주기마다 호출되는 함수 FixedUpdateNetwork
    // 네트워크에서 처리할 작업을 구현한다.
    public override void FixedUpdateNetwork()
    {
        // 내 소유권의 네트워크 오브젝트가 아닌경우, return
        if (HasStateAuthority == false) return;

        // 입력값이 없을 경우, return
        if (inputDir == Vector3.zero) return;

        controller.Move(inputDir * moveSpeed * Runner.DeltaTime);
        transform.forward = inputDir;
    }

    // 네트워크 오프젝트가 생성 됐을 때 호출되는 함수 Spawned
    // Awake, Start 함수의 대체제로도 사용되기도 한다.
    public override void Spawned()
    {
        // 내 소유권의 네트워크 오브젝트일 경우,
        if (HasStateAuthority == true)
        {
            CameraController camController = Camera.main.GetComponent<CameraController>();
            camController.target = transform;
        }

        playerModel.hp = playerModel.maxHp;
    }
}
