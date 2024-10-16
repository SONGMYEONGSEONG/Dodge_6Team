using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface iPoolable<T> 
{
    public event Action<T> OnEventPushObject;

    protected void CompletePurPose() { }
}
