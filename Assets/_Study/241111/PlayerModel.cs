using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.Events;

public class PlayerModel : NetworkBehaviour
{
    //  Networked : 네트워크에서 동기화할 데이터를 선정
    //       조건 - 데이터는 프로퍼티(속성)으로 작성해야 한다.
    // + OnChangedRender(nameof(함수명)) : 네트워크 데이터가 변경되었을 때 호출되는 함수를 설정해줄 수 있다.

    [Networked, OnChangedRender(nameof(OnChangedHP))] public int hp { get; set; }
                                                      public int maxHp;

    public UnityAction<int> OnChangedHpEvent;
    public void OnChangedHP() => OnChangedHpEvent?.Invoke(hp);
}
