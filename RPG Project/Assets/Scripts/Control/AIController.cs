using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;
<<<<<<< Updated upstream
using RPG.Attributes;
using GameDevTV.Utils;
using UnityEngine.AI;
=======
>>>>>>> Stashed changes

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 3f;
<<<<<<< Updated upstream
        [SerializeField] float agroCooldownTime = 5f;
=======
>>>>>>> Stashed changes
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolerance = 1f;
        [SerializeField] float waypointDwellTime = 3f;
        [Range(0,1)]
        [SerializeField] float patrolSpeedFraction = 0.2f;
<<<<<<< Updated upstream
        [SerializeField] float shoutDistance = 5f;
=======
>>>>>>> Stashed changes

        Fighter fighter;
        Health health;
        Mover mover;
        GameObject player;

<<<<<<< Updated upstream
        LazyValue<Vector3> guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        float timeSinceAggrevated = Mathf.Infinity;
        int currentWaypointIndex = 0;

        private void Awake() {
=======
        Vector3 guardPosition;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        int currentWaypointIndex = 0;

        private void Start() {
>>>>>>> Stashed changes
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");

<<<<<<< Updated upstream
            guardPosition = new LazyValue<Vector3>(GetGuardPosition);
            guardPosition.ForceInit();
        }

        public void Reset()
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.Warp(guardPosition.value);
            timeSinceLastSawPlayer = Mathf.Infinity;
            timeSinceArrivedAtWaypoint = Mathf.Infinity;
            timeSinceAggrevated = Mathf.Infinity;
            currentWaypointIndex = 0;
        }

        private Vector3 GetGuardPosition()
        {
            return transform.position;
        }

        private void Start() {
=======
            guardPosition = transform.position;
>>>>>>> Stashed changes
        }

        private void Update()
        {
            if (health.IsDead()) return;

<<<<<<< Updated upstream
            if (IsAggrevated() && fighter.CanAttack(player))
=======
            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
>>>>>>> Stashed changes
            {
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }

            UpdateTimers();
        }

<<<<<<< Updated upstream
        public void Aggrevate()
        {
            timeSinceAggrevated = 0;
        }

=======
>>>>>>> Stashed changes
        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
<<<<<<< Updated upstream
            timeSinceAggrevated += Time.deltaTime;
=======
>>>>>>> Stashed changes
        }

        private void PatrolBehaviour()
        {
<<<<<<< Updated upstream
            Vector3 nextPosition = guardPosition.value;
=======
            Vector3 nextPosition = guardPosition;
>>>>>>> Stashed changes

            if (patrolPath != null)
            {
                if (AtWaypoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();
            }

            if (timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                mover.StartMoveAction(nextPosition, patrolSpeedFraction);
            }
        }

        private bool AtWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void AttackBehaviour()
        {
            timeSinceLastSawPlayer = 0;
            fighter.Attack(player);
<<<<<<< Updated upstream

            AggrevateNearbyEnemies();
        }

        private void AggrevateNearbyEnemies()
        {
            RaycastHit[] hits = Physics.SphereCastAll(transform.position, shoutDistance, Vector3.up, 0);
            foreach (RaycastHit hit in hits)
            {
                AIController ai = hit.collider.GetComponent<AIController>();
                if (ai == null) continue;

                ai.Aggrevate();
            }
        }

        private bool IsAggrevated()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance || timeSinceAggrevated < agroCooldownTime;
=======
        }

        private bool InAttackRangeOfPlayer()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
>>>>>>> Stashed changes
        }

        // Called by Unity
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}