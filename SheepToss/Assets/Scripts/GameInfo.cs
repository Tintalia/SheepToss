using UnityEngine;
using System.Collections;
using System;

class GameInfo : GameObject
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan RemainingTime { get; set; }
    public int Points { get; set; }
}