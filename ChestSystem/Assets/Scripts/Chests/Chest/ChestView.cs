using System.Collections;
using UnityEngine;
public class ChestView : MonoBehaviour
{
    private AnimatedCommonChest animatedChest;
    public ChestView()
    {

    }

    public void SetAnimatedChest(AnimatedCommonChest animatedChest)
    {
        this.animatedChest = animatedChest;
    }
    public virtual void ShowLocked() {
        animatedChest.ShowLocked();
    }
    public virtual void ShowUnlocked() {
        animatedChest.ShowUnlocked();
    }
    public virtual void ShowOpenAnimation() {
        animatedChest.PlayOpenAnimation();
    }

    public void StartUnlocking()
    {
        animatedChest.ShowUnlocking();
    }
}