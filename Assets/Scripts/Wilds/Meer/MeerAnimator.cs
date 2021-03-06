﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeerAnimator : MonoBehaviour {
    public Stats stats;

    // Threshold from stand to walk animation.
    private float walkThreshold = 0.05f;

    private Rigidbody2D rb;
    private Animator animator;

    void Start() {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    void FixedUpdate() {
        // Get current animation progress.
        float animationTime = this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        float animationProgress = animationTime - Mathf.Floor(animationTime);

        // Retrieve max velocity based on current speed and linear drag.
        float maxVelocity = this.stats.speed / this.rb.drag;

        if (this.rb.velocity.magnitude < this.walkThreshold * maxVelocity) {
            if (animationTime >= 1){
                if (Random.value > 0.01f) {
                    if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle0")) {
                        this.animator.Play("Idle0");
                    }
                } else {
                    if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle1")) {
                        this.animator.Play("Idle1");
                    }
                }
            }
        } else {
            // if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
            //     this.animator.Play("Walk", 0, animationProgress);
            // }
        }
    }
}
