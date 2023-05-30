using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField, Min(3)] private int lineSegments = 60;
    [SerializeField, Min(1)] private float timeOfTheFlight = 5f;

    public void ShowTrajectoryLine(Vector3 startPoint, Vector3 impulse) 
    {
        float timeStep = timeOfTheFlight / lineSegments;

        Vector3[] lineRendererPoints = CalculateTrajectoryLine(startPoint, impulse, timeStep);

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints); 
    }

    private Vector3 [] CalculateTrajectoryLine(Vector3 startPoint, Vector3 impulse, float timeStep) 
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];

        lineRendererPoints[0] = startPoint;

        for(int i = 0; i < lineSegments; i++) 
        {
            float timeOffset = timeStep * i;

            Vector3 progressBeforeGravity = impulse * timeOffset;
            Vector3 gravityOffset = Vector3.up * -0.5f * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPosition = startPoint + progressBeforeGravity - gravityOffset;
            lineRendererPoints[i] = newPosition;
        }

        return lineRendererPoints;
    }
}
