using UnityEngine;
using System.Collections;
using System;

abstract class Sheep : Item, ICollectable
{
    public int LifePoints { get; set; } // The number life points it adds to the dragon after being collected
}