using UnityEngine;
using RPG.Movement;
using RPG.Core;
using System;
using UnityEngine.Serialization;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Weapon defaultWeapon = null;

<<<<<<< HEAD
        Health target;
        float timeSinceLastAttack = Mathf.Infinity;
        Weapon currentWeapon = null;

        private void Start() {
            EquipWeapon(defaultWeapon);
        }
=======
        Transform target;
        float timeSinceLastAttack = 0;
>>>>>>> parent of 9ea9cfe (18 Stop Attacking Already)

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;

            if (!GetIsInRange())
            {
<<<<<<< HEAD
                GetComponent<Mover>().MoveTo(target.transform.position, 1f);
=======
                GetComponent<Mover>().MoveTo(target.position);
>>>>>>> parent of 9ea9cfe (18 Stop Attacking Already)
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            weapon.Spawn(leftHandTransform, rightHandTransform, animator);
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit() event.
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        // Animation Event
        void Hit()
        {
<<<<<<< HEAD
            if(target == null) { return; }

            if (currentWeapon.HasProjectile())
            {
                currentWeapon.LaunchProjectile(leftHandTransform, rightHandTransform, target);
            }
            else
            {
                target.TakeDamage(currentWeapon.GetDamage());
            }
        }

        // Animation Event
        void Shoot()
        {
            Hit();
=======
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
>>>>>>> parent of 9ea9cfe (18 Stop Attacking Already)
        }

        private bool GetIsInRange()
        {
<<<<<<< HEAD
            return Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRange();
=======
            return Vector3.Distance(transform.position, target.position) < weaponRange;
>>>>>>> parent of 9ea9cfe (18 Stop Attacking Already)
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
<<<<<<< HEAD
            StopAttack();
=======
>>>>>>> parent of 9ea9cfe (18 Stop Attacking Already)
            target = null;
            GetComponent<Mover>().Cancel();
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}