using UnityEngine;

public abstract class AnimatedChest : MonoBehaviour
{
    abstract public void PlayOpenAnimation();
    abstract public void ShowLocked();
    abstract public void ShowUnlocked();
    abstract public void ShowUnlocking();
}