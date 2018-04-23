using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletCard : Card
{
    public NormalBullet m_bulletPrefab;
    public float m_bulletSpeed = 60; 
    public override void Play(ShootHelper user)
    {
        AudioHandler audioHandler = user.shooter.GetComponent<AudioHandler>();
        audioHandler.PlaySound("Shoot");
        Ray bulletDirection = user.GetOffsetRay();
        NormalBullet shotBullet = Instantiate(m_bulletPrefab, bulletDirection.origin, Quaternion.LookRotation(bulletDirection.direction));
        shotBullet.GetComponent<Rigidbody>().velocity = bulletDirection.direction * m_bulletSpeed;
        shotBullet.shooter = user.shooter;
    }
}
