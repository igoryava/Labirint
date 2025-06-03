using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallJoystickInput : MonoBehaviour
{
    [SerializeField] private PlayerBall _ball;
    [SerializeField] private Joystick _joystick;

    private void Update()
    {
        _ball.Move(new Vector2(_joystick.Horizontal, _joystick.Vertical));
    }
}