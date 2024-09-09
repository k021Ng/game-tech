using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Book
{
    public class AIAgent : MonoBehaviour
    {
        public float maxMoveSpeed = 4f;
        // public float mass = 1f; // 模拟重量
        public float turnSpeed = 20f;
        // public float walkForce = 4f;
        public float maxAccel = 1f;

        [Header("RUNTIME")]
        public Vector3 velocity;
        public Vector3 accel;
        // public Vector3 steerForce;
        // public int forceNextId;
        public float movePathTick = 0f;
        public int movePathStartIdx = 0;
        public List<Vector3> movePoints = new List<Vector3>();

        [Header("DEBUG")]
        public Color forwardColor = Color.red;
        public float forwardLength = 1f;
        public Color accelColor = Color.green;
        [Range(1f, 100f)]
        public float accelDebugScale = 1f;
        public bool showMovePath;
        public Color movePathColor = Color.red;
        public float movePointInterval = 0.1f;
        public int maxMovePoint = 100;

        public Vector3 pos
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Vector3 forward
        {
            get { return transform.forward; }
            set { transform.forward = value; }
        }

        public Vector3 right
        {
            get { return transform.right; }
        }

        private void Start()
        {
            // velocity = maxMoveSpeed * forward;
        }
        
        private void Update()
        {
            float dt = Time.deltaTime;

            // var force = steerForce;
            // if (force.magnitude < 0.01f && velocity.magnitude < maxMoveSpeed)
            //     force = walkForce * forward;

            // acc = force / mass;
            // velocity += acc * dt;
            pos += velocity * dt;

            // forward
            // 太小的速度值就不进行方向偏转
            if (velocity.magnitude > 0.001f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velocity), turnSpeed * Time.deltaTime);
            }

            if (showMovePath)
            {
                movePathTick += Time.deltaTime;
                if (movePathTick >= movePointInterval)
                {
                    movePathTick = 0f;
                    if (movePoints.Count < maxMovePoint)
                    {
                        movePoints.Add(pos);
                    }
                    else
                    {
                        int idx = movePathStartIdx;
                        movePoints[idx] = pos;
                        movePathStartIdx = (movePathStartIdx + 1) % movePoints.Count;
                    }
                }
            }
        }

        private void LateUpdate() 
        {
            velocity += accel * Time.deltaTime;
            if (velocity.magnitude > maxMoveSpeed)
            {
                velocity = velocity.normalized * maxMoveSpeed;
            }
            // 没有收到力的作用
            if (Utils.IsZero(accel))
            {
                velocity = Vector3.zero;
            }

            accel = Vector3.zero;
        }

        // Dictionary<int, Vector3> forceMap = new Dictionary<int, Vector3>();
        // public int AddForce(int forceId, Vector3 force)
        // {
        //     if (forceMap.ContainsKey(forceId) == false && Utils.IsZero(force))
        //         return forceId;

        //     RemoveForce(forceId);

        //     if (forceId <= 0)
        //     {
        //         forceId = forceNextId;
        //         forceNextId += 1;
        //     }
        //     forceMap[forceId] = force;
        //     UpdateSteerForce();
        //     return forceId;
        // }

        // public bool RemoveForce(int forceId)
        // {
        //     bool ret = forceMap.Remove(forceId);
        //     UpdateSteerForce();
        //     return ret;
        // }

        // private void UpdateSteerForce()
        // {
        //     steerForce = Vector3.zero;
        //     foreach (var kv in forceMap)
        //     {
        //         steerForce += kv.Value;
        //     }
        // }

        private void OnDrawGizmos() 
        {
            if (showMovePath)
            {
                Gizmos.color = movePathColor;
                for (int i = 1; i < movePoints.Count; ++i)
                {
                    var idx0 = (movePathStartIdx + i - 1) % movePoints.Count;
                    var idx1 = (movePathStartIdx + i) % movePoints.Count;
                    Gizmos.DrawLine(movePoints[idx0], movePoints[idx1]);
                }
            }

            Gizmos.color = forwardColor;
            Vector3 startPos = transform.position + Vector3.up * 1f;
            Gizmos.DrawLine(startPos, startPos + transform.forward * forwardLength);

            Gizmos.color = accelColor;
            startPos = transform.position + Vector3.up * 0f;
            Gizmos.DrawLine(startPos, startPos + accel * accelDebugScale);
        }
    }
}
