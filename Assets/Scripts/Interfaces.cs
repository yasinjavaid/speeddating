using System.Collections;
using System.Collections.Generic;

public interface IPinBallBounce
{
    void StartImpact();
}
public interface IHealthSysyem
{
    int healthTotalPoints { get; set; }
    int health { get; set; }
    bool isDie { get; set; }
    void Hit(int amount);
    void Die();
}

