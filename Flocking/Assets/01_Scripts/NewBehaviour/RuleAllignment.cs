﻿using System.Collections.Generic;
using UnityEngine;

public class RuleAllignment : FlockBehaviourBase
{
    public override Vector3 CalculateVelocity(Boid boid, List<Boid> otherBoids)
    {
        return Vector2.zero;
    }
}




