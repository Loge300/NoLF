using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TurretSpin : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform spawnPoint;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float bps = 1f;

    private Transform target;
    private float timeUntilFire;

    private void Update() {
        if(target == null) {
            FindTarget();
            return;
        }

        if(!CheckTargetIsInRange()) {
            target = null;
        } else {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1f/bps) {
                Hit();
                timeUntilFire = 0f;
            }
        }
    }

    //creates a nail object in direction of the target
    private void Hit() {
        GameObject hitObj = Instantiate(hitPrefab, spawnPoint);
        SpinHit hitScript = hitObj.GetComponent<SpinHit>();
    }

    //creates a range and finds a target that enters range
    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
        if(hits.Length > 0) {
            target = hits[0].transform;
        }
    }

    //sees if a target is in range
    private bool CheckTargetIsInRange() {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    //shows range
    private void OnDrawGizmosSelected() {
        //Handles.color = Color.cyan;
        //Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
