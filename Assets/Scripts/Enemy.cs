using UnityEngine;

public abstract class Enemy : Character
{
    private void Start()
    {
        Behavior();
    }
    public abstract void Behavior();
}