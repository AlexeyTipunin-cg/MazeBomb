using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BotsController : MonoBehaviour
{
    public Bot[] GetBots()
    {
       return GetComponentsInChildren<Bot>();
    }
}
