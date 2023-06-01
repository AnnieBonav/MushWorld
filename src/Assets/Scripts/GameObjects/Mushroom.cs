using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MushroomType { Live, Dizzy, Speed, Small, Big }
public class Mushroom : Grabbable
{
    public static event Action<int> CollectedMushroom;

    [SerializeField] private MushroomType _type;
    [SerializeField] private int _points;

    public override void Grab()
    {
        // DoAction(); // TODO: Add sensible actions
        base.Grab(); // This starts a collected grababble action (on parent grabbable) that lets inventory manager know something happened
    }

    private void DoAction() // TODO: Make delegate or smt so the function that is called is just asisgned when the mushroom is created and does not need to be checked at runtime
        // Consider: Should the mushroom be the one handling what effect it has on the game? Or only emit an action and have the element that gets affected by it heart it? 
    {
        switch (_type)
        {
            case MushroomType.Live:
                AddLive();
                break;
            case MushroomType.Dizzy:
                MakeDizzy();
                break;
            case MushroomType.Small:
                MakeSmall();
                break;
            case MushroomType.Big:
                MakeBig();
                break;
        }
    }

    private void AddLive()
    {
        print("Adds Live.");
        CollectedMushroom?.Invoke(_points);
    }

    private void MakeDizzy()
    {
        print("Makes dizzy");
    }

    private void MakeSmall()
    {
        print("Makes small");
    }

    private void MakeBig()
    {
        print("Makes big");
    }
}
