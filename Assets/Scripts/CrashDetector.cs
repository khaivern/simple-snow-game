using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float delay = 0.5f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;

  bool deadAlready = false;
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Ground" && !deadAlready)
    {
      FindObjectOfType<PlayerController>().DisableControls();
      crashEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      Invoke("ReloadScene", delay);
      deadAlready = true;
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
