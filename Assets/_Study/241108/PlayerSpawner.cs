using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] GameObject PlayerPrefab;

    [Range(0, 10)]
    [SerializeField] float randomRange;

    public void PlayerJoined(PlayerRef player)
    {
        Debug.Log("�÷��̾� ����");

        if (player != Runner.LocalPlayer) return;

        // �÷��̾� ����
        Vector3 spawnPos = new Vector3(Random.Range(-randomRange, randomRange), 0, Random.Range(-randomRange, randomRange));

        // Instantiate(PlayerPrefab, spawnPos, Quaternion.identity); // ȥ�� �����
        Runner.Spawn(PlayerPrefab, spawnPos, Quaternion.identity);   // ��Ʈ��ũ���� �� ���� �����
    }

    public void PlayerLeft(PlayerRef player)
    {
        Debug.Log("�÷��̾� ����");
    }
}
