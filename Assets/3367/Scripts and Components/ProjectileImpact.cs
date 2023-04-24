using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script is a simple interaction with the projectile impact on the projectile standard script.
/// original: Tim Lewis
/// date: 8/4/2022
/// </summary>
/// 
public class ProjectileImpact : MonoBehaviour
{
    [SerializeField]
    private bool enableDebugHitMessage;
    [SerializeField]
    private UnityEvent m_MyEvent;

    public void ExecuteEvent()
    {
        if(enableDebugHitMessage == true)
        {
            Debug.Log("ProjectileImpactScript: Hit");
        }

        m_MyEvent.Invoke();
    }
}
