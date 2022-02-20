using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{
    public string currentAnimation;
    public SpriteRenderer SR;
    public Animator animator;
    public Player player;


    public Dictionary<int, string> animNames = new Dictionary<int, string> { [0] = "Run", [1] = "Jump", [2] = "Fall1", [3] = "Duck", [4] = "Idle", [5] = "WallHug", [6] = "BallAir", [7] = "DashH" };
    private void Awake()
    {
        player = transform.parent.GetComponent<Player>();
        SR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    public void Play(string animationName)
    {

        if (currentAnimation != animationName )
        {
            currentAnimation = animationName;
            animator.Play(animationName);
        }
    }
    //public int CurrentFrame
    //{
    //    get
    //    {
    //        var cAnimation = animator.GetCurrentAnimatorClipInfo(0)[0];
    //        return Mathf.RoundToInt(cAnimation.weight * cAnimation.clip.frameRate * cAnimation.clip.length);
    //    }
    //}
    public bool IsPlaying(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

    public void Flip(int flip)
    {
        var scale = transform.localScale;

        if (flip == 1)
        {
            transform.localScale = new Vector3(Mathf.Abs(scale.x), scale.y, scale.z);
        }
        else
        {
            transform.localScale = new Vector3(-Mathf.Abs(scale.x), scale.y, scale.z);
        }
       
    }
    public Vector3 Scale
    {
        get
        {
            return transform.localScale;
        }
        set
        {
            value.x = value.x * player.facing;
            transform.localScale = value;
        }
    }
    public void SetSpriteColor(Color color)
    {
        SR.color = color;
    }
}
