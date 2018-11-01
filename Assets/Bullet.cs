using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody m_rigidBody;
    [SerializeField] float m_power;

    private void OnEnable()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.AddForce(transform.forward * m_power);
    }


}
