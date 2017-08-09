using UnityEngine;
using System.Collections;

public class MachineGun : Weapon {

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

        Vector3 localTarget = (target - m.transform.position);
        Vector3 shift = Random.rotation * (Vector3.fwd * localTarget.magnitude * DEVIATION);

               
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
