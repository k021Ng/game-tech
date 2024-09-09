using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Book
{
    public class AvoidAgent : AIBehavoir
    {
        public float collisionRadius = 0.4f;

        [Header("RUNTIME")]
        public AIAgent agent;
        public AIAgent[] targets;
        public AIAgent collisionAgent;

        [Header("DEBUG")]
        public Color collisionRadiusColor = Color.red;

        private void Awake() 
        {
            agent = GetComponent<AIAgent>();
            targets = GameObject.FindObjectsOfType<AIAgent>();
        }

        void Update()
        {
            collisionAgent = null;

            // 找到最近的 target
            float shortestTime = float.MaxValue;
            AIAgent firstTarget = null;
            float firstMinSeparation = 0f;
            Vector3 firstRelativePos = Vector3.zero;
            Vector3 firstRelativeVel = Vector3.zero;
            float firstDistance = 0.0f;
            foreach (var t in targets)
            {
                if (t == agent)
                    continue;

                Vector3 rpos = (t.pos - agent.pos).ZeroY();
                float rdist = rpos.magnitude;
                Vector3 rvel = t.velocity - agent.velocity;
                float rspeed = rvel.magnitude;
                float timeToCollision = Vector3.Dot(rpos, rvel);
                // WHY?
                timeToCollision /= rspeed * rspeed * -1;
                float minSeparation = rdist - rspeed * timeToCollision;
                if (minSeparation > 2 * collisionRadius)
                    continue;
                if (timeToCollision > 0.0f && timeToCollision < shortestTime)
                {
                    shortestTime = timeToCollision;
                    firstTarget = t;
                    firstMinSeparation = minSeparation;
                    firstRelativePos = rpos;
                    firstRelativeVel = rvel;
                    firstDistance = rdist;
                }
            }

            if (firstTarget == null)
            {
                return;
            }
            if (firstMinSeparation <= 0.0f || firstDistance < 2 * collisionRadius)
                firstRelativePos = firstTarget.pos;
            else
                firstRelativePos += firstRelativeVel * shortestTime;
            
            collisionAgent = firstTarget;
            agent.accel = (-firstRelativePos.normalized * agent.maxAccel).ZeroY();
        }

        void OnDrawGizmos()
        {
            Handles.color = collisionRadiusColor;
            Handles.DrawWireDisc(transform.position, Vector3.up, collisionRadius * 2f);

            if (collisionAgent != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position + Vector3.up * 0.5f, collisionAgent.pos + Vector3.up * 0.5f);
            }
        }
    }
}