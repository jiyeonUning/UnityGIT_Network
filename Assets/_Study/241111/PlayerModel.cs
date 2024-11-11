using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.Events;

public class PlayerModel : NetworkBehaviour
{
    //  Networked : ��Ʈ��ũ���� ����ȭ�� �����͸� ����
    //       ���� - �����ʹ� ������Ƽ(�Ӽ�)���� �ۼ��ؾ� �Ѵ�.
    // + OnChangedRender(nameof(�Լ���)) : ��Ʈ��ũ �����Ͱ� ����Ǿ��� �� ȣ��Ǵ� �Լ��� �������� �� �ִ�.

    [Networked, OnChangedRender(nameof(OnChangedHP))] public int hp { get; set; }
                                                      public int maxHp;

    public UnityAction<int> OnChangedHpEvent;
    public void OnChangedHP() => OnChangedHpEvent?.Invoke(hp);
}
