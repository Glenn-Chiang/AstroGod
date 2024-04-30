using System.Collections;
using UnityEngine;

public class BurstGunController : GunController
{
    protected override void Fire()
    {
        StartCoroutine(ShootBurst());
    }

    private IEnumerator ShootBurst()
    {
        // TODO: How many shots to fire in a burst?
        int numberOfShots = 3;
        float shotInterval = 0.1f;
        for (int i = 0; i < numberOfShots; i++)
        {
            Shoot();
            yield return new WaitForSeconds(shotInterval);
        }
    }
}