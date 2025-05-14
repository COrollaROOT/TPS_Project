using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPattern
{
    /*제네릭(Generic)은 메서드(함수)나 클래스를 작성할 때 데이터 형식(Type)을 지정하지 않는다.

    그렇기에 코드로 작성한 후, 실제 사용하는 시점에서 데이터 형식을 지정할 수 있도록 하는 기능이다. 

    제네릭은 재사용성이 높고 컴파일 시점에서 타입 체크를 하기 때문에 안정적이다.

    덕분에 제네릭을 쓰면 코드의 가독성과 유지보수성을 향상시킬 수 있다.

    제네릭이 생긴게 <T> 이렇게 T에다가 데이터 타입을 암거나 넣을 수 있다.

    데이터 타입은 말 그대로 자료형(Data Type)이다.*/
    public class ObservableProperty<T>
    {
        [SerializeField] private T _value; // 인스펙터에서 어떤 값인지 확인용도로
        public T Value
        {
            get => _value; // 프로퍼티
            set
            {
                if (_value.Equals(value)) return; // 새로받은 값이 이전값과 같다면 return
                _value = value; // value 대입
                Notify(); // 값이 변경될때 알림
            }
        }
        private UnityEvent<T> _onValueChanged = new(); // using UnityEngine.Events 네임스페이스에서 제공하는 UnityEvent 사용 해당 값이 교체 됬을때 실행

        public ObservableProperty(T value = default) // 
        {
            _value = value; // 들어온 값으로 세팅
        }

        public void Subscribe(UnityAction<T> action) // 구독하는 함수
        {
            _onValueChanged.AddListener(action);
        }

        public void Unsubscribe(UnityAction<T> action) // 구독 해지 함수
        {
            _onValueChanged.RemoveListener(action);
        }

        public void UnsbscribeAll() // 모든 구독 해지 함수
        {
            _onValueChanged.RemoveAllListeners();
        }

        private void Notify() // 구독 대상자들에게 알림을 주는 함수
        {
            _onValueChanged?.Invoke(Value);
        }
    }
}
