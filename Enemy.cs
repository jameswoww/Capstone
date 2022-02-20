using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BoxActor
{
    protected Sprite sprite;
    protected Player player;
    protected int facing = 1;
    protected virtual void Awake()
    {
        //sprite = transform.GetChild(0).GetComponent<Sprite>();
        
        player = Player.s;
        groundMask = LayerMask.GetMask("Ground");
        boxCollider = GetComponent<BoxCollider2D>();
        stateManager = new StateManager();
        //Hitbox = new HitBox(24, 32, 0, 16);
        physicsHitbox = Hitbox.GetPhysicsBox();

    }
    #region variables
    protected int lastHitBy = 0;
    [SerializeField]
    protected bool onGround;
    protected bool wasOnGround;
    [SerializeField]
    protected Vector2 speed = Vector2.zero;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        onGround = CheckOnGround();
        base.Update();
        PixMoveX(speed.x * Time.deltaTime, groundMask);
        PixMoveY(speed.y * Time.deltaTime, groundMask,yZero);
        wasOnGround = onGround;
    }
    public void Hit(int damage,int attackId,Vector2 launchVector)
    {
        if (lastHitBy == attackId)
        {
            return;
        }
        lastHitBy = attackId;
        if (launchVector.magnitude>1.5)
        {
            speed = launchVector;
        }
        else
        {
            Stagger(launchVector);
        }
        
    }
    protected float DistanceFromPlayer()
    {
        return (player.Position - Position).magnitude*wsRatio;
    }
    protected bool CheckForWall(Vector2 offsetWS)
    {
        return (Physics2D.OverlapBox(Position + offsetWS, physicsHitbox.wsSize, 0, groundMask));
    }
    protected bool CheckIfOnLedge(bool movingRight)
    {
        if (movingRight)
        {
            return (Physics2D.OverlapBox(new Vector2(RightWS,BottomWS) + pixToWorld * new Vector2(1, -1), pixToWorld * Vector2.one, 0, groundMask));
        }
        else
        {
            return (Physics2D.OverlapBox(new Vector2(LeftWS,BottomWS) - pixToWorld * Vector2.one, pixToWorld * Vector2.one, 0, groundMask));
        }
         

    }
    private void Stagger(Vector2 launchVector)
    {
        if(onGround && (launchVector==Vector2.right|| launchVector == Vector2.left))
        {
            Debug.Log("staggered");
            speed = new Vector2(launchVector.x * 30, 100);
        }
        else
        {
            speed = launchVector.normalized * 50;
        }
    }
    //function call when hitting wall adjust later
    private void yZero()
    {
        speed.y = 0;
    }
    //only for testing remove later
    private void Gravity()
    {
        if (onGround)
        {
            speed.x = Approach(speed.x, 0, 200* Time.deltaTime);
        }
        else
        {
            speed.y = Approach(speed.y, -250, 1000 * Time.deltaTime);
        }
    }
}
