using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public abstract class PuzzleBase : NetworkBehaviour
{
    public int seed;
    protected bool active = false;
    public abstract void InitializePuzzle();
    public virtual void SetActive(bool status)
    {
        active = status;
    }
}
