using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] GameObject m_bullet;
    [SerializeField] Transform m_bulletReference;
    [SerializeField] Character m_Character;

    private void OnEnable()
    {
        m_Character.Onfire.AddListener(Fire);
    }

    private void OnDisable()
    {
        m_Character.Onfire.RemoveListener(Fire);
    }

    private void Fire (){

        Instantiate(m_bullet, m_bulletReference.position, m_bulletReference.rotation);
    }
}
