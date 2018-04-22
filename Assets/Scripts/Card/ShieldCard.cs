﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCard : Card {
    public ShotObjects m_shieldPrefab;
	public float m_shieldLifeTime = 4;
	public Vector3 m_shieldPositionOffset;
    public override void Play(ShootHelper user)
    {
        Ray shieldDirection = user.GetOffsetRay();
        ShotObjects shotBullet = Instantiate(m_shieldPrefab, shieldDirection.origin + user.m_bulletSpawnPoint.rotation * m_shieldPositionOffset, Quaternion.LookRotation(shieldDirection.direction));
        shotBullet.shooter = user.shooter;
		shotBullet.m_lifeTime = m_shieldLifeTime;
    }
}