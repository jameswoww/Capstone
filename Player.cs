using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BoxActor
{
    Controller controller;
    Sprite sprite;
    LayerMask enemyMask;
    //singleton player
    public static Player s;
   
    private void Awake()
    {
        s = this;
        sprite = transform.GetChild(0).GetComponent<Sprite>();
        groundMask = LayerMask.GetMask("Ground");
        enemyMask = LayerMask.GetMask("Enemy");
        boxCollider = GetComponent<BoxCollider2D>();
        stateManager = new StateManager();
        stateManager.AddState("normalState", NormalUpdate, NormalStart, NormalEnd);
        stateManager.AddState("attackState", AttackUpdate, AttackStart, AttackEnd);
        stateManager.AddState("dashState", DashUpdate, DashStart, DashEnd,StartDashCoroutine);
        Hitbox = new HitBox(24, 32, 0, 16);
        physicsHitbox = Hitbox.GetPhysicsBox();

    }
    // Start is called before the first frame update
    void Start()
    {
        controller = Controller.S;
        stateManager.currentState = "normalState";
    }

    // Update is called once per frame
    public override void Update()
    {
        //timers
        {
            if (chargeAttackTimer > ChargeAttackTime)
            {
                charged = true;
                charging = true;
            }
            else if (chargeAttackTimer > 0)
            {
                charging = true;
                charged = false;
            }
            else
            {
                charging = false;
                charged = false;
            }
            if (attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
            }
            if (jumpGraceTimer > 0) jumpGraceTimer -= Time.deltaTime;
            //get Ground

            if (CheckOnGround())
            {
                onGround = true;
                jumpGraceTimer = JumpGraceTime;
            }
            else
            {
                onGround = false;
            }
            if (varJumpTimer > 0)
            {
                varJumpTimer -= Time.deltaTime;
            }
            //if (liftBoostTimer > 0)
            //{
            //    liftBoostTimer -= Time.deltaTime;
            //}
            //else
            //{
            //    liftBoost = Vector2.zero;
            //}
            //facing
            if (speed.x < 0)
            {
                facing = -1;
            }
            else if (speed.x > 0)
            {
                facing = 1;
            }
            // wall slide timer
            //if (wallSlideDir != 0)
            //{
            //    wallSlideTimer -= Time.deltaTime;
            //    wallSlideDir = 0;
            //}
            ////force move x
            //if (forceMoveXTimer > 0)
            //{
            //    forceMoveXTimer -= Time.deltaTime;
            //    input.joy.x = forceMoveX;
            //}
            //else
            //{

            //}

        }
        if (onGround)
        {
            speed.y = 0;
        }
        LastAim = controller.leftStick;
        base.Update();
        UpdateSprite();
        PixMoveX(speed.x * Time.deltaTime, groundMask);
        PixMoveY(speed.y * Time.deltaTime, groundMask);
        wasOnGround = onGround;
        
    }
    #region Sprite
    public void UpdateSprite()
    {
        sprite.SetSpriteColor(Color.white);
        sprite.Scale = new Vector3(Approach(Mathf.Abs(sprite.Scale.x), 1, 1.75f * Time.deltaTime), Approach(Mathf.Abs(sprite.Scale.y), 1, 1.75f * Time.deltaTime), 1);
        sprite.Flip(facing);
        if (stateManager.currentState == "attackState")
        {
            return;
        }
        if (charged)
        {
            if (OnInterval(0.25f))
            {
                sprite.SetSpriteColor(Color.red);
            }
        }
        else if (charging)
        {
            if(OnInterval(0.1f)){
                sprite.SetSpriteColor(Color.red);
            }
        }
        // state stuff

        //if (stateManager.currentState == 3)
        //{
        //    sprite.Play(6);
        //}
        //else if (stateManager.currentState == 2)
        //{
        //    sprite.Play(7);
        //}

        //else if (Ducking && stateManager.currentState == 1)
        //{
        //    sprite.Play(3);
        //}
        if (onGround)
        {
            //push anim
            //idle
            if (Mathf.Abs(speed.x) <= RunAccel / 40f && controller.leftStick.x == 0)
            {
                //idlecarry
                //edge
                sprite.Play("Idle");

            }
            //run carry here
            //normal run
            //skid flip
            else
            {
                sprite.Play("Run");
            }
        }
        //wallslide
        //else if (wallSlideDir != 0)
        //{
        //    sprite.Play(5);
        //}
        else if (speed.y > 0)
        {
           sprite.Play("jump");

        }
        else if (speed.y < 0)
        {
            if (sprite.currentAnimation == "jump")
            {
                sprite.Play("jump2fall");
            }

            else if (sprite.currentAnimation == "jump2fall" && sprite.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                sprite.Play("fall");
            }
            else
            {
                sprite.Play("fall");
            }
        }
        //else
        //{
        //    sprite.Play(2);
        //}



        

        
    }
    
    #endregion
    #region constants




    ////public static ParticleType P_DashA;
    ////public static ParticleType P_DashB;
    ////public static ParticleType P_CassetteFly;
    ////public static ParticleType P_Split;
    ////public static ParticleType P_SummitLandA;
    ////public static ParticleType P_SummitLandB;
    ////public static ParticleType P_SummitLandC;

    //public const float MaxFall = 480f;
    //private const float Gravity = 2700f;
    //private const float HalfGravThreshold = 100f;

    //private const float FastMaxFall = 720f;
    //private const float FastMaxAccel = 900f;

    //public const float MaxRun = 270f;
    //public const float RunAccel = 2600f;
    //private const float RunReduce = 1000f;
    //private const float AirMult = .65f;

    //private const float HoldingMaxRun = 70f;
    //private const float HoldMinTime = .35f;

    //private const float BounceAutoJumpTime = .1f;

    //private const float DuckFriction = 500f;
    //private const int DuckCorrectCheck = 4;
    //private const float DuckCorrectSlide = 50f;

    //private const float DodgeSlideSpeedMult = 1.2f;
    //private const float DuckSuperJumpXMult = 1.25f;
    //private const float DuckSuperJumpYMult = .5f;

    //private const float JumpGraceTime = 0.1f;
    //private const float JumpSpeed = -315f;
    //private const float JumpHBoost = 50f;
    //private const float VarJumpTime = .2f;
    //private const float CeilingVarJumpGrace = .05f;
    //private const int UpwardCornerCorrection = 4;
    //private const float WallSpeedRetentionTime = .06f;

    //private const int WallJumpCheckDist = 3;
    //private const float WallJumpForceTime = .13f;
    //private const float WallJumpHSpeed = MaxRun;

    //public const float WallSlideStartMax = -60f;
    //private const float WallSlideTime = 1.2f;

    //private const float BounceVarJumpTime = .2f;
    //private const float BounceSpeed = -140f;
    //private const float SuperBounceVarJumpTime = .2f;
    //private const float SuperBounceSpeed = -185f;

    //private const float SuperJumpSpeed = JumpSpeed;
    //private const float SuperJumpH = 260f;
    //private const float SuperWallJumpSpeed = -160f;
    //private const float SuperWallJumpVarTime = .25f;
    //private const float SuperWallJumpForceTime = .2f;
    //private const float SuperWallJumpH = MaxRun + JumpHBoost * 2;

    //private const float DashSpeed = 720f;
    //private const float EndDashSpeed = 400f;
    //private const float EndDashUpMult = .75f;
    //private const float DashTime = .15f;
    //private const float DashCooldown = .2f;
    //private const float DashRefillCooldown = .1f;
    //private const int DashHJumpThruNudge = 6;
    //private const int DashCornerCorrection = 4;
    //private const int DashVFloorSnapDist = 3;
    //private const float DashAttackTime = .3f;

    //private const float BoostMoveSpeed = 80f;
    //public const float BoostTime = .25f;

    //private const float DuckWindMult = 0f;
    //private const int WindWallDistance = 3;

    //private const float ReboundSpeedX = 120f;
    //private const float ReboundSpeedY = -120f;
    //private const float ReboundVarJumpTime = .15f;

    //private const float ReflectBoundSpeed = 220f;

    //private const float DreamDashSpeed = DashSpeed;
    //private const int DreamDashEndWiggle = 5;
    //private const float DreamDashMinTime = .1f;

    //public const float ClimbMaxStamina = 110;
    //private const float ClimbUpCost = 100 / 2.2f;
    //private const float ClimbStillCost = 100 / 10f;
    //private const float ClimbJumpCost = 110 / 4f;
    //private const int ClimbCheckDist = 2;
    //private const int ClimbUpCheckDist = 2;
    //private const float ClimbNoMoveTime = .1f;
    //public const float ClimbTiredThreshold = 20f;
    //private const float ClimbUpSpeed = -45f;
    //private const float ClimbDownSpeed = 80f;
    //private const float ClimbSlipSpeed = 30f;
    //private const float ClimbAccel = 900f;
    //private const float ClimbGrabYMult = .2f;
    //private const float ClimbHopY = -120f;
    //private const float ClimbHopX = 100f;
    //private const float ClimbHopForceTime = .2f;
    //private const float ClimbJumpBoostTime = .2f;
    //private const float ClimbHopNoWindTime = .3f;

    //private const float LaunchSpeed = 280f;
    //private const float LaunchCancelThreshold = 220f;

    //private const float LiftYCap = -130f;
    //private const float LiftXCap = 250f;

    //private const float JumpThruAssistSpeed = -40f;

    //private const float InfiniteDashesTime = 2f;
    //private const float InfiniteDashesFirstTime = .5f;
    //private const float FlyPowerFlashTime = .5f;

    //private const float ThrowRecoil = 80f;
    //private static readonly Vector2 CarryOffsetTarget = new Vector2(0, -12);

    //private const float ChaserStateMaxTime = 4f;

    //public const float WalkSpeed = 64f;

    //public const int StNormal = 0;
    //public const int StClimb = 1;
    //public const int StDash = 2;
    //public const int StSwim = 3;
    //public const int StBoost = 4;
    //public const int StRedDash = 5;
    //public const int StHitSquash = 6;
    //public const int StLaunch = 7;
    //public const int StPickup = 8;
    //public const int StDreamDash = 9;
    //public const int StSummitLaunch = 10;
    //public const int StDummy = 11;
    //public const int StIntroWalk = 12;
    //public const int StIntroJump = 13;
    //public const int StIntroRespawn = 14;
    //public const int StIntroWakeUp = 15;
    //public const int StBirdDashTutorial = 16;
    //public const int StFrozen = 17;
    //public const int StReflectionFall = 18;
    //public const int StStarFly = 19;
    //public const int StTempleFall = 20;
    //public const int StCassetteFly = 21;
    //public const int StAttract = 22;

    //public const string TalkSfx = "player_talk";


    //public const float MaxFall = 480f;
    //private const float Gravity = 2700f;
    //private const float HalfGravThreshold = 100f;

    //private const float FastMaxFall = 720f;
    //private const float FastMaxAccel = 900f;

    //public const float MaxRun = 270f;
    //public const float RunAccel = 2600f;
    //private const float RunReduce = 1000f;
    //private const float AirMult = .65f;

    //private const float HoldingMaxRun = 70f;
    //private const float HoldMinTime = .35f;

    //private const float BounceAutoJumpTime = .1f;

    //private const float DuckFriction = 500f;
    //private const int DuckCorrectCheck = 4;
    //private const float DuckCorrectSlide = 50f;

    //private const float DodgeSlideSpeedMult = 1.2f;
    //private const float DuckSuperJumpXMult = 1.25f;
    //private const float DuckSuperJumpYMult = .5f;

    //private const float JumpGraceTime = 0.1f;
    //private const float JumpSpeed = -315f;
    //private const float JumpHBoost = 50f;
    //private const float VarJumpTime = .2f;
    //private const float CeilingVarJumpGrace = .05f;
    //private const int UpwardCornerCorrection = 4;
    //private const float WallSpeedRetentionTime = .06f;

    private const float AirMult = 0.65f;
    private const float RunAccel = 2600f;
    private const float RunReduce = 1000f;
    private const float MaxRun = 270;
    private const float MaxFall = -480;
    private const float FastMaxFall = -720;
    private const float FastMaxAccel = 900f;
    private const float HalfGravThreshold = -100f;
    private const float Gravity = 2700;
    private const float JumpSpeed = 315;
    private const float VarJumpTime = 0.2f;
    private const float JumpHBoost = 50f;
    private const float JumpGraceTime = 0.1f;
    private const float DashSpeed = 720f;
    private const float EndDashSpeed = 400f;
    private const float EndDashUpMult = .75f;
    private const float DashTime = .15f;
    private const float DashCooldown = .2f;
    private const float AttackDelay = .5f;

    private const float ChargeAttackTime = 0.5f;
    
    #endregion
    #region variables

    [SerializeField]
    private Vector2 speed = Vector2.zero;
    [SerializeField]
    private bool onGround = false;
    [SerializeField]
    private bool wasOnGround = false;
    [SerializeField]
    private float maxFall;
    [SerializeField]
    public int facing = 1;
    [SerializeField]
    private float varJumpTimer;
    private float varJumpSpeed;
    private float jumpGraceTimer;
    private Vector2 dashDir;
    private Vector2 lastAim;
    private float attackDelay;

    private float chargeAttackTimer = 0;
    private bool charging = false;
    private bool charged = false;

    #endregion
    #region normalState

    private void NormalStart()
    {
        maxFall = MaxFall;

    }
    private void NormalEnd()
    {

    }
    private string NormalUpdate()
    {
        //if (LiftBoost.y < 0 && wasOnGround && !onGround && Speed.y <= 0)
        //    Speed.y = LiftBoost.y;

        //for testing 
        //if (CanDash)
        //{
        //    input.ConsumeGrabBuffer();
        //    Die();
        //}
        //if (CanGrab)
        //{
        //    input.ConsumeGrabBuffer();
        //    Pickup();
        //}
        //FreeBallCheck();
        //if (CanThrow)
        //{
        //    input.ConsumeGrabBuffer();

        //    Throw(-LastAim);
        //    if (onGround && LastAim.y < 0)
        //    {

        //    }
        //    else
        //    {
        //        return StartDash();
        //    }

        //}

        //if (!Ducking && onGround && input.joy.y == -1 && Speed.y <= 0)
        //{
        //    Ducking = true;
        //    sprite.Scale = new Vector3(.8f, 1.2f, 1);

        //}
        //if (Ducking && input.joy.y != -1)
        //{
        //    if (CanUnduck)
        //    {
        //        Ducking = false;
        //    }
        //}
        if (controller.dashButtonDown && controller.dashButtonTimer > 0) 
        {
            return BeginDash();

        }

        //running friction
        //if (Ducking && onGround)
        //    Speed.x = Approach(Speed.x, 0, DuckFriction * 3 * Time.deltaTime);
        //else



        //attack logic
        //charge
        if (controller.attackButtonDown)
        {
            ChargeAttack();
        }
        else if (chargeAttackTimer >= ChargeAttackTime)
        {
            chargeAttackTimer = 0;
            //chargeAttack
        }
        else if (chargeAttackTimer>0) 
        {
            chargeAttackTimer = 0;
            attackType = "landCombo1";
            return "attackState";
        }
        

        //x velocity
        {
            float mult = onGround ? 1 : AirMult;
            //if (onGround && level.CoreMode == Session.CoreModes.Cold)
            //    mult *= .3f;

            float max = MaxRun;
            //float max = holding == null ? MaxRun : MaxRun;
            //if (level.InSpace)
            //    max *= SpacePhysicsMult;
            if (Mathf.Abs(speed.x) > max && Mathf.Sign(speed.x) == controller.leftStick.x)
                speed.x = Approach(speed.x, max * controller.leftStick.x, RunReduce * mult * Time.deltaTime);  //Reduce back from beyond the max speed
            else
            {
                speed.x = Approach(speed.x, max * controller.leftStick.x, RunAccel * mult * Time.deltaTime);   //Approach the max speed
            }

        }
        //vertical
        //calculate maxfall
        {
            float mf = MaxFall;
            float fmf = FastMaxFall;
            //adjust mf fmf here
            if (controller.leftStick.y == -1 && speed.y <= mf)
            {
                maxFall = Approach(maxFall, fmf, FastMaxAccel * Time.deltaTime);

            }
            else
            {
                maxFall = Approach(maxFall, mf, FastMaxAccel * Time.deltaTime);
            }

        }
        //gravity
        {
            if (!onGround)
            {
                float max = maxFall;
                //wallslide here
                //Wall Slide
                if (controller.leftStick.x == facing)
                {
                    //if (speed.y <= 0 && wallSlideTimer > 0 && holding == null && Physics2D.OverlapBox(Position + xPixel * facing, Collider.size * pixToWorld, 0, groundMask) && CanUnduck)
                    //{
                    //    Ducking = false;
                    //    wallSlideDir = facing;
                    //}

                    //if (wallSlideDir != 0)
                    //{
                    //    //if (wallSlideTimer > WallSlideTime * .5f && ClimbBlocker.Check(level, this, Position + Vector2.UnitX * wallSlideDir))
                    //    //    wallSlideTimer = WallSlideTime * .5f;

                    //    max = Mathf.Lerp(-MaxFall, WallSlideStartMax, wallSlideTimer / WallSlideTime);
                    //    //if (wallSlideTimer / WallSlideTime > .65f)
                    //    //    CreateWallSlideParticles(wallSlideDir);
                    //}
                }
                float mult = (Mathf.Abs(speed.y) < HalfGravThreshold) && controller.southButtonDown ? .5f : 1f;
                speed.y = Approach(speed.y, max, Gravity * mult * Time.deltaTime);
            }
        }
        if (varJumpTimer > 0)
        {
            if (controller.southButtonDown)
            {
                speed.y = Mathf.Max(speed.y, varJumpSpeed);

            }
            else
            {
                varJumpTimer = 0;
            }
        }
        if (controller.southButtonTimer > 0)
        {
            if (jumpGraceTimer > 0)
            {
                Jump();
            }
            //else if (CanUnduck)
            //{
            //    bool canUnDuck = CanUnduck;
            //    if (canUnDuck && WallJumpCheck(1))
            //    {
            //        //if (Facing == Facings.Right && Input.Grab.Check && Stamina > 0 && Holding == null && !ClimbBlocker.Check(Scene, this, Position + Vector2.UnitX * WallJumpCheckDist))
            //        //    ClimbJump();
            //        //else if (DashAttacking && DashDir.X == 0 && DashDir.Y == -1)
            //        //    SuperWallJump(-1);
            //        //else
            //        WallJump(-1);
            //    }
            //    else if (canUnDuck && WallJumpCheck(-1))
            //    {
            //        //if (Facing == Facings.Left && Input.Grab.Check && Stamina > 0 && Holding == null && !ClimbBlocker.Check(Scene, this, Position + Vector2.UnitX * -WallJumpCheckDist))
            //        //    ClimbJump();
            //        //else if (DashAttacking && DashDir.X == 0 && DashDir.Y == -1)
            //        //    SuperWallJump(1);
            //        //else
            //        WallJump(1);
            //    }
            //    //else if ((water = CollideFirst<Water>(Position + Vector2.UnitY * 2)) != null)
            //    //{
            //    //    Jump();
            //    //    water.TopSurface.DoRipple(Position, 1);
            //    //}
            //}
        }


        return "normalState";
    }
    #endregion
    #region Jumps
    //LiftBoost

    public void Jump(bool particles = true, bool playSfx = true)
    {
        // in input on JumpPressed
        controller.ConsumeJumpBuffer();
        jumpGraceTimer = 0;
        varJumpTimer = VarJumpTime;
        //AutoJump = false;
        //dashAttackTimer = 0;
        //wallSlideTimer = WallSlideTime;
        //wallBoostTimer = 0;

        speed.x += JumpHBoost * controller.leftStick.x;
        speed.y = JumpSpeed;
        //speed += LiftBoost;
        varJumpSpeed = speed.y;

        //LaunchedBoostCheck();

        //if (playSfx)
        //{
        //    if (launched)
        //        Play(Sfxs.char_mad_jump_assisted);

        //    if (dreamJump)
        //        Play(Sfxs.char_mad_jump_dreamblock);
        //    else
        //        Play(Sfxs.char_mad_jump);
        //}

        //sprite.Scale = new Vector2(.8f, 1.2f);
        //if (particles)
        //    Dust.Burst(BottomCenter, Calc.Up, 4);

        //SaveData.Instance.TotalJumps++;
    }

    #endregion
    #region attackState

    private void ChargeAttack()
    {
        chargeAttackTimer += Time.deltaTime;
        //flickerSprite
        
    }
    //variables
    public string attackType;
    public Vector2 attackBox;
    public Vector2 attackBoxOffset;
    public int attackDamage;
    public int attackId;
    private Vector2 attackLaunchVector = Vector2.zero;

    private void AttackStart()
    {
        //set launch Vector to start adjust individually on special attacks
        attackLaunchVector = Vector2.right*facing;
        speed = Vector2.zero;
        attackId += 1;
        //check attack type to set parameters for coroutine, invoke coroutine in start
        if (attackType == "landCombo1")
        {


            sprite.Play("landCombo1");
            speed.x = facing*30;
            attackBox = new Vector2(3, 1.75f);
            attackBoxOffset = new Vector2(1.5f * facing, 1);
            StartCoroutine(LandCombo1Coroutine());
        }
        else if (attackType == "landCombo2")
        {
            sprite.Play("landCombo2");
            speed.x = facing * 50;
            attackBox = new Vector2(3, 1.75f);
            attackBoxOffset = new Vector2(1.5f * facing, 1);
            StartCoroutine(LandCombo2Coroutine());
        }
        else if (attackType == "landCombo3")
        {
            sprite.Play("landCombo1");
            speed.x = facing * 50;
            attackBox = new Vector2(3, 1.75f);
            attackBoxOffset = new Vector2(1.5f * facing, 1);
            StartCoroutine(LandCombo3Coroutine());
        }
        else if (attackType == "upperCut")
        {
            attackLaunchVector = new Vector2(0,500);
            sprite.Play("upperCut");
            speed = new Vector2(facing * 25, 300);
            attackBox = new Vector2(2.5f, 3);
            attackBoxOffset = new Vector2(0.75f * facing, 1.3f);
            StartCoroutine(UpperCutCoroutine());
        }
        else if (attackType == "strike")
        {
            attackLaunchVector = new Vector2(200*facing, 50);
            sprite.Play("landCombo1");
            speed.x = facing * 300;
            attackBox = new Vector2(3, 1.75f);
            attackBoxOffset = new Vector2(1.5f * facing, 1);
            StartCoroutine(StrikeCoroutine());
        }

    }
    private void AttackEnd()
    {
        speed = Vector2.zero;
    }
    private string AttackUpdate()
    {
        //physics check collider;
        Attack(1,attackId,attackLaunchVector);
        return "attackState";
    }
    
    //coroutine changes attackbox and confirms follow up on attacks.
    IEnumerator LandCombo1Coroutine()
    {
        
        yield return new WaitForSeconds(0.20f);
        //follow up
        CheckForFollowUp("landCombo2", 0.5f) ;
        
    }
    IEnumerator LandCombo2Coroutine()
    {

        yield return new WaitForSeconds(0.20f);
        if (stateManager.currentState == "attackState")
        {
            
            if (controller.attackButtonTimer > 0)
            {
                if (controller.leftStick == Vector2.right * facing)
                {
                    attackType = "strike";
                    controller.ConsumeAttackBuffer();
                    stateManager.ResetState();
                    stateManager.currentState = "attackState";
                }
                else if (controller.leftStick == Vector2.up)
                {
                    attackType = "upperCut";
                    controller.ConsumeAttackBuffer();
                    stateManager.ResetState();
                    stateManager.currentState = "attackState";
                }
                else
                {
                    attackType = "landCombo3";
                    controller.ConsumeAttackBuffer();
                    stateManager.ResetState();
                    stateManager.currentState = "attackState";
                }
            }
            else
            {
                attackDelay = 0.5f;
                stateManager.currentState = "normalState";
            }
        }

    }
    IEnumerator LandCombo3Coroutine()
    {
        //speed = Vector2.right * facing * 200;
        //yield return new WaitForSeconds(0.02f);

        yield return new WaitForSeconds(0.11f);
        speed = Vector2.zero;
        yield return new WaitForSeconds(0.10f);

        stateManager.currentState = "normalState";
        attackDelay = 1f;
    }
    IEnumerator UpperCutCoroutine()
    {
        //speed = Vector2.right * facing * 200;
        //yield return new WaitForSeconds(0.02f);
        
        yield return new WaitForSeconds(0.13f);
        
        stateManager.currentState = "normalState";
        attackDelay = 1f;
    }
    IEnumerator StrikeCoroutine()
    {
        //speed = Vector2.right * facing * 200;
        //yield return new WaitForSeconds(0.02f);

        yield return new WaitForSeconds(0.15f);
        speed = Vector2.zero;
        yield return new WaitForSeconds(0.05f);

        stateManager.currentState = "normalState";
        attackDelay = 1f;
    }
    //check at the end of corouting for follow up if triggered
    private void CheckForFollowUp(string attackName,float delay)
    {
        if (stateManager.currentState == "attackState")
        {
            if (controller.attackButtonTimer > 0)
            {
                attackType = attackName;
                controller.ConsumeAttackBuffer();
                stateManager.ResetState();
                stateManager.currentState = "attackState";
            }
            else
            {
                attackDelay = delay;
                stateManager.currentState = "normalState";
            }
        }
    }
    private void Attack(int attackValue, int attackId,Vector2 launchVector)
    {
        foreach (Collider2D hits in Physics2D.OverlapBoxAll((Vector2)transform.position + attackBoxOffset, attackBox,0,enemyMask))
        {
            hits.GetComponent<Enemy>().Hit(attackDamage, attackId, attackLaunchVector);
        }
        //Physics2D enemy Scan, attackId so that attacked enemy can't be hit by the same attack   
    }
    #endregion
    #region dashState
    //public bool CanDash
    //{
    //    get
    //    {
    //        return input.GrabPressed;
    //    }
    //}

    public string BeginDash()
    {
        //dashCanceled = false;
        controller.ConsumeDashBuffer();
        return "dashState";
    }
    public void DashStart()
    {
        speed = Vector2.zero;
    }
    public void DashEnd()
    {

    }
    public bool dashCanceled = false;
    public string DashUpdate()
    {
        //if (dashCanceled)
        //{
        //    return 1;
        //}
        return "dashState";
    }

    //cast Coroutine as method
    public void StartDashCoroutine()
    {

        StartCoroutine(DashCoroutine());
    }
    public IEnumerator DashCoroutine()
    {
        //start next frame after first frame of dashUpdate
        var dir = LastAim;
        //diagonal cut
        if (dir.magnitude != 1)
        {
            dir *= 0.72f;
        }
        //trail.gameObject.transform.position = Position + dir * pixToWorld * 10;
        //trail.emitting = true;
        yield return null;
        //Invoke("ActivateMirage", 0.06f);
        //Invoke("ActivateMirage", 0.12f);
        //Invoke("ActivateMirage", 0.18f);



        //setShake = new Vector3(dir.x, dir.y, 5f);
        //camShakeTime = 0.20f;
        //input.Rumble(2, 0.25f);

        dashDir = dir;
        var newSpeed = dir * DashSpeed;
        speed = newSpeed;

        yield return new WaitForSeconds(DashTime);
        //if (!dashCanceled)
        //{
        //    trail.emitting = false;
        //    if (DashDir.y >= 0)
        //    {
        //        Speed = DashDir * EndDashSpeed;
        //    }
        //    if (Speed.y > 0)
        //        Speed.y *= EndDashUpMult;

        //    stateManager.currentState = 1;
        //}

        //trail.emitting = false;
        if (dashDir.y >= 0)
        {
            speed = dashDir * EndDashSpeed;
        }
        if (speed.y > 0)
            speed.y *= EndDashUpMult;
        stateManager.currentState = "normalState";
        //else
        //{
        //    yield return new WaitForSeconds(0.1f);
        //    trail.emitting = false;
        //}

    }

    //public void ActivateMirage()
    //{
    //    foreach (Mirage m in mirages)
    //    {
    //        if (!m.gameObject.activeInHierarchy)
    //        {
    //            m.Set(transform.position);
    //            return;
    //        }
    //    }
    //}
    public Vector2 LastAim
    {
        set
        {
            lastAim = value;
        }
        get
        {
            if (lastAim == Vector2.zero)
            {
                return Vector2.right * facing;
            }
            else
            {
                return lastAim;
            }

        }
    }
    #endregion
    #region Gizmos
    private void OnDrawGizmos()
    {
        if (stateManager.currentState== "attackState")
        {
            Gizmos.DrawWireCube((Vector2)transform.position + attackBoxOffset, attackBox);
        }
        
    }
    //GayDicks
    
    #endregion


}
