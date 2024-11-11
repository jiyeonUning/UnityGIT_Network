using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Weapon : NetworkBehaviour
{
    [SerializeField] Transform muzzlePoint;

    [SerializeField] int damage;
    [SerializeField] float range;

    public void Fire()
    {
        if (Runner.GetPhysicsScene().Raycast(muzzlePoint.position, muzzlePoint.forward, out RaycastHit info, range))
        {
            if (info.transform.tag != "player") return;

            PlayerController player = info.transform.GetComponent<PlayerController>();
            player.TakeHitRpc(damage);
        }
    }
}
