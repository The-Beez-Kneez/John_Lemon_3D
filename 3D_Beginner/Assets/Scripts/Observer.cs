using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
  public Transform player;

  public GameEnding gameEnding;

  bool m_isPlayerInRange;

  void OnTriggerEnter (Collider other) {
    if (other.transform == player) {
      m_isPlayerInRange = true;
    }
  }

  void OnTriggerExit (Collider other) {
    if (other.transform == player) {
      m_isPlayerInRange = false;
    }
  }

  // Need to check the line of sight when the player character is actually in range
  // Chck line of sight by checking whether there are any Colliders along the path of a line starting from a point.
  void Update () {
    if (m_isPlayerInRange) {
      // You may remember that JohnLemon’s position is on the ground, between his feet.  To make sure the Observer can see JohnLemon’s centre of mass, you’re pointing the direction up one unit by adding Vector3.up.  Vector3.up is a shortcut for (0, 1, 0).
      Vector3 direction = player.position - transform.position + Vector3.up;

      Ray ray = new Ray(transform.position, direction);

      RaycastHit rayCastHit;

      if (Physics.Raycast(ray, out rayCastHit)) {
        if (rayCastHit.collider.transform == player) {
          gameEnding.CaughtPlayer ();
        }
      }
    }
  }
}
