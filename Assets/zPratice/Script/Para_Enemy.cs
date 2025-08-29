using UnityEngine;

public class Para_Enemy : Enemy_Base
{


    // Update is called once per frame
    
    public override void Attack()
    {

        GameManager.instance.TakeDamage(damage);

    }
}
