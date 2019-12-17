using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static Vector2 FrictionForce(Rigidbody2D rb, float coefficient)
    {
        return -rb.velocity * coefficient;
    }

    public static float DeltaCoef { get; } = 50;
}
