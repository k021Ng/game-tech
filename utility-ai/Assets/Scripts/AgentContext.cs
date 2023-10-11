using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.Utility;

public class AgentContext : MonoBehaviour, IContext
{
    public Agent agent;
    public float deltaSecs;

    public float GetCurTimeNOR()
    {
        float t = TimeSystem.Inst.daySecs / TimeSystem.ONEDAY_SECONDS;
        return Mathf.Clamp01(t);
    }

    public float GetStatNOR(Stat s)
    {
        var v = agent.GetStat(s);
        var max = agent.GetStatMax(s);
        return Mathf.Clamp01(v / max);
    }
}