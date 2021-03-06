﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingAnimator : MonoBehaviour {
    public Stats stats;
    public float threshold = 0.05f;

    private Rigidbody2D rb;
    private Animator animator;

    void Start() {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }
    void FixedUpdate() {
        // Retrieve max velocity based on current speed and linear drag.
        float maxVelocity = this.stats.speed / this.rb.drag;

        // Set animator facing if current velocity exceeds the threshold.
        if (this.rb.velocity.magnitude > this.threshold * maxVelocity) {
            this.animator.SetFloat("FaceX", this.rb.velocity.x);
            this.animator.SetFloat("FaceY", this.rb.velocity.y);
        }
    }
}
