﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Player : MonoBehaviour {
    // Public variables

    public Rigidbody2D rigidBody2D;

    // Private variables

    private System.Random random = new System.Random();

    private int direction;
    private int rotationSpeed; // Degrees

    private float arcHeight;
    private float arcWidth;

    private float velX;
    private float velY;

    void Awake() {
        direction = 1;
        rotationSpeed = 20;

        arcHeight = 0.0f;
        arcWidth = 0.0f;
    }

    public int GetDirection() { return direction; }
    public void SetDirection(int direction) { this.direction = direction; }

    public float GetArcHeight() { return arcHeight; }
    public void SetArcHeight(float arcHeight) { this.arcHeight = arcHeight; }

    public float GetArcWidth() { return arcWidth; }
    public void SetArcWidth(float arcWidth) { this.arcWidth = arcWidth; }

    public float GetVelocityX() { return velX; }
    public float GetVelocityY() { return velY; }

    public void UpdateVelocity() { // Recalculates velocity based on gravity, arcHeight, and arcWidth
        velY = (float)Math.Sqrt(-2 * Physics2D.gravity.y * arcHeight);
        velX = arcWidth / (-velY/Physics2D.gravity.y);

        rigidBody2D.velocity = new Vector2(velX * direction, velY);
        rotationSpeed = random.Next((int)(velX * velY), (int)(velX * velY) * 5);
    }

    public void UpdateRotation() {
        //this.transform.eulerAngles += Vector3.forward * -direction * rotationSpeed * Time.deltaTime;
        this.rigidBody2D.angularVelocity = 600.0f * rotationSpeed * -direction;
    }
}
