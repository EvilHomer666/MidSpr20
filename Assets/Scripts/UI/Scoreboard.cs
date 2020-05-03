using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; // << Using system.OI for input output

// Custom name space not inheriting from Misbehavior
namespace Game.ScoreboardData
{
public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreEntries = 8;
    }
}
