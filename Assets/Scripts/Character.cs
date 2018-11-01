using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour
{


    public UnityEvent Onfire;

    private Animator m_animator;
    private bool m_picked;

    public Text remotepick;
    public Text remoteinstru;
    public Text LightInstr;
    public Text babyCry;

    float waittime = 5;
   
    private bool m_enableIK;
    private float m_weightIK;
    private Vector3 m_positionIK;


    // Use this for initialization
    void Start()
    {
        // Initialize Animator
        m_animator = GetComponent<Animator>();

     
        remotepick.enabled = false;
        remoteinstru.enabled = false;
        LightInstr.enabled = false;
        babyCry.enabled = false;

    }



    public void Move(float turn, float forward, bool jump, bool picked)
    {
        m_animator.SetFloat("Turn", turn);
        m_animator.SetFloat("Forward", forward);

        m_picked = picked;

        if (jump)
        {
            m_animator.SetTrigger("Jump");
        }

        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Pickable")
        {
            var pickable = other.GetComponent<Pickable>();

            //Debug.Log("PickingTrigger");
            //Debug.Log(pickable.picked);

            if (m_picked && pickable != null && !pickable.picked)
            {
                // do something
                Transform rightHand = m_animator.GetBoneTransform(HumanBodyBones.RightHand);
                pickable.BePicked(rightHand);

                m_animator.SetTrigger("Pick");
                StartCoroutine(UpdateIK(other));// Start corroutine to update position and weight
            }
        }
    }

    private IEnumerator UpdateIK(Collider other)
    {
        m_enableIK = true;

        while (m_enableIK)
        {
            m_positionIK = other.transform.position;
            m_weightIK = m_animator.GetFloat("IK");
            yield return null;
        }


    }

    public void DisableIK()
    {
        m_enableIK = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (m_enableIK)
        {
            m_animator.SetIKPosition(AvatarIKGoal.RightHand, m_positionIK);
            m_animator.SetIKPositionWeight(AvatarIKGoal.RightHand, m_weightIK);
        }
    }

    public void AimFire(bool aimDown, bool aimHold, bool fire)
    {

        m_animator.SetBool("Aim", aimHold);

        if (aimHold && fire)
        {
            m_animator.SetTrigger("Fire");
            if (Onfire != null)
            {
                Onfire.Invoke();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "remote")
        {
            remotepick.enabled = true;
          
        }
        if(other.gameObject.tag =="tv"){
            remoteinstru.enabled = true;
        }
        if(other.gameObject.tag =="Light"){
            LightInstr.enabled = true;
        }
        if (other.gameObject.tag == "Baby")
        {
            babyCry.enabled = true;
        }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "remote")
        {
            remotepick.enabled = false;

        }
        if (other.gameObject.tag == "tv")
        {
            remoteinstru.enabled = false;
        }
        if (other.gameObject.tag == "Light")
        {
            LightInstr.enabled = false;

        }
        if (other.gameObject.tag == "Baby")
        {
            babyCry.enabled = false;
        }

    }
    IEnumerator WaitTime(){
        yield return new WaitForSeconds(2);
    }
}
