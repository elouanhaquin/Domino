using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourbesPlacement : MonoBehaviour
{

    [SerializeField] int m_nbPoints;

    [SerializeField] Transform m_LimitUL;
    [SerializeField] Transform m_LimitDL;
    [SerializeField] Transform m_LimitUR;
    [SerializeField] Transform m_LimitDR;

    [SerializeField] BezierCurve m_scriptBezier;


    void Awake()
    {
        float minX = m_LimitDR.position.x;
        float minZ = m_LimitDR.position.z;
        float maxX = m_LimitUL.position.x;
        float maxZ = m_LimitUL.position.z;

        float posX = minX;
        float posZ = minZ;

        for (int i = 1; i <= m_nbPoints; i++)
        {
            posX = Mathf.Lerp(minX, maxX, i/(float)m_nbPoints);
            posZ = Mathf.Lerp(minZ, maxZ, Mathf.Sin(i));
            m_scriptBezier.AddPointAt(new Vector3(posX, 3, posZ));
        }
    }

    void Update()
    {
        
    }
}
