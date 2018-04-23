using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ShootHelper
{
    public Transform m_bulletSpawnPoint;
    public Camera m_camera;
    public Transform shooter;

    public Ray GetOffsetRay()
    {
        Ray retRay = new Ray();
        retRay.origin = m_bulletSpawnPoint.position;
        retRay.direction = m_bulletSpawnPoint.forward;

        Transform cameraTransform = m_camera.transform;
        string[] ignoreLayers = {"Shield", "Projectile"};
        int layerMask = ~LayerMask.GetMask(ignoreLayers);
        RaycastHit hitInfo;
        if (Physics.Raycast(cameraTransform.position + cameraTransform.forward * m_camera.nearClipPlane, cameraTransform.forward, out hitInfo, Mathf.Infinity, layerMask))
        {
            retRay.direction = (hitInfo.point - m_bulletSpawnPoint.position).normalized;
        }
        return retRay;
    }
}