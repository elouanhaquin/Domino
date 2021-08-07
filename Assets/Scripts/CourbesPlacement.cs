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
        float minX = m_LimitDL.position.x;
        float minZ = m_LimitDL.position.z;
        float maxX = m_LimitUR.position.x;
        float maxZ = m_LimitUR.position.z;

        float posX = minX;
        float posZ = minZ;

        bool isRight = false;
        
        for (int i = 1; i <= m_nbPoints; i++)
        {  
            m_scriptBezier.AddPointAt(new Vector3(posX, 0, isRight ? minZ : maxZ ));
            m_scriptBezier[i-1].globalHandle1 = new Vector3(posX -10, 0, isRight ? minZ-1.4f : maxZ+1.4f);
            m_scriptBezier[i-1].globalHandle2 = new Vector3(posX +10, 0, isRight ? minZ+1.4f : maxZ-1.4f);
          //  m_scriptBezier[i-1].globalHandle2 = new Vector3(posX, 3, isRight ? minZ+1 : maxZ-1);
            posX = i % 2 != 0 ? posX + 10 : posX;
            isRight = i % 2 ==0;
        }
    }

    void Update()
    {
        
    }
}
