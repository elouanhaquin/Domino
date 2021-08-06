using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DominoSpawner : MonoBehaviour
{
    [SerializeField] GameObject m_domino;
    [SerializeField] int m_maxDominos;
    [SerializeField] BezierCurve m_curve;

    private float m_pointIterator;
    private float m_iteratorStep;


    void Awake()
    {
        m_pointIterator = 0.0f;
        m_iteratorStep = 1 / (float)m_maxDominos;

        GameObject dominoMaster = GameObject.FindGameObjectWithTag("DominoMaster") == null ? this.gameObject : GameObject.FindGameObjectWithTag("DominoMaster");
        Instantiate(m_domino, new Vector3(-15,8,0), Quaternion.identity , dominoMaster.transform);

        for (int i = 1; i < dominoMaster.transform.childCount+1 && i < m_maxDominos; i++)
        {
            if (m_curve != null && m_curve.GetPointAt(i / (float)dominoMaster.transform.childCount+1) != null && i + 1 < m_maxDominos)
            {
                var vec = new Vector3(m_curve.GetPointAt((i+1) * m_iteratorStep).x, m_curve.GetPointAt((i + 1) * m_iteratorStep).y, m_curve.GetPointAt((i + 1) * m_iteratorStep).z);
                var go = Instantiate(m_domino, new Vector3(m_curve.GetPointAt(m_pointIterator).x, m_curve.GetPointAt(m_pointIterator).y, m_curve.GetPointAt(m_pointIterator).z), Quaternion.identity, dominoMaster.transform);
                go.transform.LookAt(vec);

                m_pointIterator += m_iteratorStep;
            }
        }
        
    }

}
