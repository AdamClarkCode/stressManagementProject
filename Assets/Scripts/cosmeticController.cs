using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosmeticController : MonoBehaviour
{

    public SpriteRenderer tile;
    private varController vr;

    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        setCos();
    }

    void setCos()
    {
        vr = GameObject.FindGameObjectWithTag("varController").GetComponent<varController>();
        tile = GameObject.FindGameObjectWithTag("background").GetComponent<SpriteRenderer>();
        tile.sprite = vr.tile;

        AnimatorOverrideController aoc = new AnimatorOverrideController(animator.runtimeAnimatorController);
        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        foreach (var a in aoc.animationClips)
            anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, vr.hat));
        aoc.ApplyOverrides(anims);
        animator.runtimeAnimatorController = aoc;
    }

    
}
