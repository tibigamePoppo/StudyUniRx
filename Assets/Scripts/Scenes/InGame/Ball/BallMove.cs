using Scenes.InGame.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.InGame.Ball
{
    [RequireComponent(typeof(BallStatus), typeof(Rigidbody2D))]
    public class BallMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private Vector2 _velocity;
        [SerializeField, Tooltip("����")]
        private float _power;
        private BallStatus _ballStatus;
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _ballStatus = GetComponent<BallStatus>();
            _velocity = new Vector2(1,1).normalized;
            _rigidbody2D.AddForce(_velocity * _power, ForceMode2D.Impulse);
        }
        //TODO:����Update�ł�����BallStatus���Q�Ƃ������Ă��܂��B�C�x���g�@�\���g���āAIsMovable�̒l���ύX���ꂽ�Ƃ��������̏��������s����悤�ɕύX���Ă݂܂��傤
        private void Update()
        {
            if(_ballStatus.IsMovable == false)
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("DeadFrame"))
            {
                InGameManager.Instance.GameOver();
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                _rigidbody2D.velocity = Vector2.zero;
                var boundVelocity = transform.position - collision.gameObject.transform.position;
                _rigidbody2D.AddForce(boundVelocity.normalized * _power, ForceMode2D.Impulse);
            }
        }
    }
}