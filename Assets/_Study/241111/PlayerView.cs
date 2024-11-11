using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    // �����ϴ� �� �ڵ� ��ħ, ���� �����ؼ� �߰��صѰ�.

    [SerializeField] PlayerModel Model;
    [SerializeField] TMP_Text hpText;

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    private void Start()
    {
        hpText.text = Model.hp.ToString();
    }

    private void OnEnable()
    {
        Model.OnChangedHpEvent += SetHPText;
    }

    private void OnDisable()
    {
        Model.OnChangedHpEvent -= SetHPText;
    }

    // === === ===

    public void SetHPText(int hp)
    {
        hpText.text = hp.ToString();
    }
}
