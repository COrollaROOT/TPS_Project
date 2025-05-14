using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPattern
{
    /*���׸�(Generic)�� �޼���(�Լ�)�� Ŭ������ �ۼ��� �� ������ ����(Type)�� �������� �ʴ´�.

    �׷��⿡ �ڵ�� �ۼ��� ��, ���� ����ϴ� �������� ������ ������ ������ �� �ֵ��� �ϴ� ����̴�. 

    ���׸��� ���뼺�� ���� ������ �������� Ÿ�� üũ�� �ϱ� ������ �������̴�.

    ���п� ���׸��� ���� �ڵ��� �������� ������������ ����ų �� �ִ�.

    ���׸��� ����� <T> �̷��� T���ٰ� ������ Ÿ���� �ϰų� ���� �� �ִ�.

    ������ Ÿ���� �� �״�� �ڷ���(Data Type)�̴�.*/
    public class ObservableProperty<T>
    {
        [SerializeField] private T _value; // �ν����Ϳ��� � ������ Ȯ�ο뵵��
        public T Value
        {
            get => _value; // ������Ƽ
            set
            {
                if (_value.Equals(value)) return; // ���ι��� ���� �������� ���ٸ� return
                _value = value; // value ����
                Notify(); // ���� ����ɶ� �˸�
            }
        }
        private UnityEvent<T> _onValueChanged = new(); // using UnityEngine.Events ���ӽ����̽����� �����ϴ� UnityEvent ��� �ش� ���� ��ü ������ ����

        public ObservableProperty(T value = default) // 
        {
            _value = value; // ���� ������ ����
        }

        public void Subscribe(UnityAction<T> action) // �����ϴ� �Լ�
        {
            _onValueChanged.AddListener(action);
        }

        public void Unsubscribe(UnityAction<T> action) // ���� ���� �Լ�
        {
            _onValueChanged.RemoveListener(action);
        }

        public void UnsbscribeAll() // ��� ���� ���� �Լ�
        {
            _onValueChanged.RemoveAllListeners();
        }

        private void Notify() // ���� ����ڵ鿡�� �˸��� �ִ� �Լ�
        {
            _onValueChanged?.Invoke(Value);
        }
    }
}
