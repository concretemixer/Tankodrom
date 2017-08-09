using UnityEngine;
using System.Collections;

public class MountMachineGun : Weapon {

    private const float DEVIATION = 0.1f;
    private const float COOLDOWN = 0.075f;
    private float cooldown = 0;

    public override bool Fire(bool primary)
    {
        if (primary != isPrimary)
            return false;

        if (cooldown > 0)
            return false;



        Muzzle m = GetComponentInChildren<Muzzle>();

        float len = (target - m.transform.position).magnitude;
        Vector3 localTarget = transform.forward * len;

        Vector3 shift = Random.rotation * (Vector3.forward * localTarget.magnitude * DEVIATION);

               
        Quaternion t = Quaternion.LookRotation(localTarget + shift);



        GameObject _b = Resources.Load<GameObject>("Bullet");
        GameObject b = (GameObject)Instantiate(_b, m.transform.position, t);

     //   b.GetComponent<Projectile>().target = target;

        cooldown = COOLDOWN;

        return true;
    }

    public void Update()
    {
        cooldown -= Time.deltaTime;
    }
}
