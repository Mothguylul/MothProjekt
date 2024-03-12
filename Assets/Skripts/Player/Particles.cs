using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Particles : MonoBehaviour
{
    public ParticleSystem groundJumpEffect, particlesGroundColl;
    public ParticleSystem runEffect;

    private Rigidbody2D rigid;
    private bool hasJumped, hasEntered = false;

    private Player player;
    private PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        playerMovement = GetComponent<PlayerMovement>();

        player.ShouldPlayParticles += HandleGroundCollEffect;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleGroundCollEffect()
    {
        groundJumpEffect.Play();

        if (playerMovement.hasDoubleJumped)
            particlesGroundColl.Play();

    }
}
