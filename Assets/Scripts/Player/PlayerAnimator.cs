using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerMovement mov;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("Particle FX")]
    [SerializeField] private GameObject jumpFX;
    [SerializeField] private GameObject landFX;
    private ParticleSystem _jumpParticle;
    private ParticleSystem _landParticle;

    public bool startedJumping { private get; set; }
    public bool justLanded { private get; set; }

    public bool onWall { private get; set; }

    public bool dashStarted { private get; set; }

    public float speed { private get; set; }



    private void Start()
    {
        mov = GetComponent<PlayerMovement>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
        anim = spriteRend.GetComponent<Animator>();

        _jumpParticle = jumpFX.GetComponent<ParticleSystem>();
        _landParticle = landFX.GetComponent<ParticleSystem>();
    }

    private void LateUpdate()
    {
        CheckAnimationState();

        ParticleSystem.MainModule jumpPSettings = _jumpParticle.main;

        ParticleSystem.MainModule landPSettings = _landParticle.main;
    }

    private void CheckAnimationState()
    {
        if (startedJumping)
        {
            anim.SetBool("Jump", true);
            GameObject obj = Instantiate(jumpFX, transform.position - (Vector3.up * transform.localScale.y / 2), Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            startedJumping = false;
            return;
        }

        if (justLanded)
        {
            anim.SetBool("Jump", false);
            GameObject obj = Instantiate(landFX, transform.position - (Vector3.up * transform.localScale.y / 1.5f), Quaternion.Euler(-90, 0, 0));
            Destroy(obj, 1);
            justLanded = false;
            return;
        }

        if (onWall)
        {
            anim.SetBool("onWall", true);
            onWall = false;
            return;
        }

        if (!onWall)
        {
            anim.SetBool("onWall", false);
            return;
        }
    }
}
