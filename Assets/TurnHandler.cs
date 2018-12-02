﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour {

    public delegate void EndPlacement();
    public static event EndPlacement DonePlacing;

    public delegate void TimeToShoot();
    public static event TimeToShoot TakeAShot;
}
