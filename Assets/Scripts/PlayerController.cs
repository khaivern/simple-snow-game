using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody2D rb;
  [SerializeField] float torqueAmount = 1f;
  [SerializeField] float moveSpeed = 30f;
  [SerializeField] float boostSpeed = 50f;
  [SerializeField] ParticleSystem snowEffect;
  SurfaceEffector2D surfaceEffector2D;
  bool canMove = true;

  void Start()
  {
    surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (!canMove) return;
    RotatePlayer();
    RespondToBoost();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Ground")
    {
      snowEffect.Play();
    }
  }

  void OnCollisionExit2D(Collision2D other)
  {
    if (other.gameObject.tag == "Ground")
    {
      snowEffect.Stop();
    }
  }

  public void DisableControls()
  {
    canMove = false;
  }

  void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      surfaceEffector2D.speed = boostSpeed;
    }
    else
    {
      surfaceEffector2D.speed = moveSpeed;
    }
  }

  void RotatePlayer()
  {
    if (!canMove) return;
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb.AddTorque(torqueAmount);
    }

    else if (Input.GetKey(KeyCode.RightArrow))
    {
      rb.AddTorque(-torqueAmount);
    }
  }
}
