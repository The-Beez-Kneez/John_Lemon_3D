using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
  public float fadeDuration =  1f;
  public float displayImageDuration = 1f;
  public GameObject player;
  // End Game by exiting level
  public CanvasGroup exitBackgroundImageCanvasGroup;
  // End Game once caught by enemies
  public CanvasGroup caughtBackgroundImageCanvasGroup;

  bool m_isPlayerAtExit;
  bool m_isPlayerCaught;
  float m_Timer;

  void OnTriggerEnter (Collider other) {
    if(other.gameObject == player) {
      m_isPlayerAtExit = true;
    }
  }

  public void CaughtPlayer () {
    m_isPlayerCaught = true;
  }

  void Update () {
    if(m_isPlayerAtExit) {
      EndLevel(exitBackgroundImageCanvasGroup, false);
    } else if (m_isPlayerCaught) {
      EndLevel(caughtBackgroundImageCanvasGroup, true);
    }
  }

  void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart) {
    m_Timer += Time.deltaTime;

    imageCanvasGroup.alpha = m_Timer / fadeDuration;

    if(m_Timer > fadeDuration + displayImageDuration) {
      if (doRestart) {
        SceneManager.LoadScene(0);
      } else {
        Application.Quit();
      }
    }
  }
}
