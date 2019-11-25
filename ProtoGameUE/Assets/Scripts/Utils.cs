using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public const float DEFAULT_JUMP_HEIGHT = 350f;
    public static bool isGrounded(Rigidbody2D rigidbody2D)
    {
        return rigidbody2D.velocity.y > -0.01f && rigidbody2D.velocity.y < 0.01f;
    }
}
