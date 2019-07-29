using System;
using UnityEngine;
using UnityEngine.Serialization;
namespace _Tenkinoko.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    //ここで注意しないといけないのはFreezeRotationを全てオンにする
    public class CharactorController : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 velocity = Vector3.zero;
        Vector3 nomal = Vector3.zero;
        public int speed;
        [Header("ここで左右確認")] public bool turn;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Debug.Log(nomal);
            if (turn)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Move(-speed * nomal.y);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Move(speed * nomal.y);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    Move(speed * nomal.y);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Move(-speed * nomal.y);
                }
            }
        }
        //        nomalは法線ベクトルを表す
        //        ここの法線ベクトルを使って角度を算出する
        private void OnCollisionEnter(Collision other)
        {
            foreach (ContactPoint contact in other.contacts)
            {
                if (contact.thisCollider.name == name)
                {
                    nomal = contact.normal;
                }
            }
        }
        private void Move(float x)
        {
            rb.AddForce(new Vector3(nomal.y * -1, nomal.x, 0) * x);
        }
    }
}