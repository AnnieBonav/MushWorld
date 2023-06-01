using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class CollectedGrabbables
{
    private Dictionary<Grabbable, int> _collectedGrabbables = new Dictionary<Grabbable, int>();

    public int Add(Grabbable collectedGrabbable)
    {
        foreach (KeyValuePair<Grabbable, int> collectedGrabbablePair in _collectedGrabbables)
        {
            Grabbable tempGrabable = collectedGrabbablePair.Key;
            if(collectedGrabbable == tempGrabable)
            {
                int newAmount = collectedGrabbablePair.Value + 1;
                _collectedGrabbables[tempGrabable] = newAmount;
                return newAmount;
            }
        }

        _collectedGrabbables.Add(collectedGrabbable, 1);
        return -1;
    }

    public int Consume(Grabbable consumedGrabbable)
    {
        foreach (KeyValuePair<Grabbable, int> collectedGrabbablePair in _collectedGrabbables)
        {
            Grabbable tempGrabable = collectedGrabbablePair.Key;
            if (consumedGrabbable == tempGrabable)
            {
                int newAmount = collectedGrabbablePair.Value - 1;
                _collectedGrabbables[tempGrabable] = newAmount;

                if(newAmount <= 0)
                {
                    RemoveCollectedGrabbable(tempGrabable);
                }
                return newAmount;
            }
        }
        return -1; // This will not happen
    }

    public void RemoveCollectedGrabbable(Grabbable removedGrabbable)
    {
        _collectedGrabbables.Remove(removedGrabbable);
    }
}
