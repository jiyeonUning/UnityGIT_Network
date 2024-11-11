using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    // 연동하는 거 코드 놓침, 추후 복습해서 추가해둘것.

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
