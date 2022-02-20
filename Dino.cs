using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : Enemy
{
    // Start is called before the first frame update
    
    protected override void Awake()
    {
        //sprite stuff later
        base.Awake();
        Hitbox = new HitBox(24, 32, 0, 16);
        stateManager.AddState("normalState", NormalUpdate, NormalStart);
        stateManager.AddState("chaseState",ChaseUpdate,ChaseStart);
        stateManager.currentState = "normalState";
        //stateManager.AddState
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        //timers
        if (changeDirectionTimer > 0)
        {
            changeDirectionTimer -= Time.deltaTime;
        }
        base.Update();
        
    }
    
    private void SpriteUpdate()
    {
        sprite.Scale = new Vector3(Approach(Mathf.Abs(sprite.Scale.x), 1, 1.75f * Time.deltaTime), Approach(Mathf.Abs(sprite.Scale.y), 1, 1.75f * Time.deltaTime), 1);
        sprite.Flip(facing);
        //logic for animations here
    }
    //normal is walk here
    #region normalState
    public void NormalStart()
    {
        changeDirectionTimer = ChangeTime;
        walkDirection = Random.value > 0.5 ? 1 : -1;
    }
    private string NormalUpdate()
    {


        //if (CanAttackPlayer())
        //{
        //    return ("chaseState");
        //}
        if (walkDirection == 0)
        {
            //idle
            if (changeDirectionTimer < 0)
            {
                walkDirection = Random.value > 0.5 ? 1 : -1;
                changeDirectionTimer = 5f;
            }
        }
        else
        {
            //walk
            if (changeDirectionTimer < 0 && Random.value < 0.01)
            {
                //can change direction or enter idle state
                if (Random.value > 0.6f)
                {
                    walkDirection = 0 ;
                    changeDirectionTimer = 7f;
                }
                else
                {
                    changeDirectionTimer = 5f;
                    walkDirection *= -1;
                }
            }

            if (CheckForWall(xPixel * Mathf.Sign(speed.x)) || CheckIfOnLedge(speed.x > 0))
            {
                speed.x = 0;
                walkDirection *= -1;
            }
            


        }
        speed.x = Approach(speed.x, walkDirection * WalkSpeed, WalkAccel * Time.deltaTime);
        //if (CheckForWall(xPixel * Mathf.Sign(speed.x)) || CheckIfOnLedge(speed.x>0))
        //{
        //    speed = new Vector2(-speed.x, speed.y);
        //}



        return "normalState";
    }
    #endregion
    #region VC
    private int walkDirection=1;
    private float changeDirectionTimer = 0;

    private const float ChangeTime = 4f;
    private const float WalkSpeed = 36f;
    private const float RunSpeed = 100f;
    private const float RunAccel = 300f;
    private const float WalkAccel = 80f;
    private const float AttackHeight = 15f;

    private void WalkStart()
    {
        changeDirectionTimer = ChangeTime;
    }
    private string WalkUpdate()
    {


        if (CanAttackPlayer())
        {
            return ("chaseState");
        }

        //randomly change direction
        if(changeDirectionTimer<0 && Random.value < 0.01)
        {
            //can change direction or enter idle state
            if (Random.value > 0.73f)
            {
                return "normalState";
            }
            else
            {
                changeDirectionTimer = ChangeTime;
                walkDirection *= -1;
            }
        }

        speed.x = Approach(speed.x, walkDirection * WalkSpeed, WalkAccel * Time.deltaTime);

        if (CheckForWall(xPixel * Mathf.Sign(speed.x)) || CheckIfOnLedge(speed.x > 0))
        {
            speed.x = 0;
            walkDirection *= -1;
        }
        return "walkState";
    }

    #endregion
    #region ChaseState
    private void ChaseStart()
    {

    }
    private string ChaseUpdate()
    {
        //exit chase state

        //enter attack state

        walkDirection = (int)Mathf.Sign(player.transform.position.x - transform.position.x);
        speed.x = Approach(speed.x, walkDirection * RunSpeed, RunAccel * Time.deltaTime);

        return "chaseState";
    }
    #endregion
    #region AttackState
    private bool CanAttackPlayer()
    {
        if (DistanceFromPlayer() < 250 && player.transform.position.y-transform.position.y<AttackHeight*pixToWorld && Physics2D.OverlapBox((Vector2)(transform.position + player.transform.position) / 2 - yPixel, new Vector2(Mathf.Abs(transform.position.x - player.transform.position.x), pixToWorld), 0, groundMask))
        {
            //check if there's floor to player
            Vector2 playerToEnemy = transform.position + player.transform.position;
            Physics2D.OverlapBox(playerToEnemy / 2 - yPixel, new Vector2(Mathf.Abs(transform.position.x - player.transform.position.x), pixToWorld),0,groundMask);
            //check if player is in attacking range vertically

        }
        return false;
    }
    private bool StopChasing()
    {
        return false;
    }
    private string AttackUpdate()
    {
        if(DistanceFromPlayer() > 400)
        {
            return "normalState";
        }
        //chases player
        speed = (player.transform.position.x-transform.position.x) * Vector2.right * 300;
        //attack behaviour
        if (DistanceFromPlayer() < 10)
        {
            Attack();
        }

        return "attackState";
    }
    private void Attack()
    {

    }
    #endregion
}
