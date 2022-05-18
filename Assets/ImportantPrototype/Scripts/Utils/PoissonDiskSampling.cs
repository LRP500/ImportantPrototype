using System.Collections.Generic;
using UnityEngine;

namespace ImportantPrototype.Utils
{
    public static class PoissonDiskSampling
    {
        public static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize, int numSampleBeforeRejection = 30)
        {
            float cellSize = radius / Mathf.Sqrt(2);
            int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x / cellSize), Mathf.CeilToInt(sampleRegionSize.y / cellSize)];

            var points = new List<Vector2>();
            var spawnPoints = new List<Vector2> {
                sampleRegionSize / 2 // Starting point
            };

            while (spawnPoints.Count > 0)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Count);
                var spawnCentre = spawnPoints[spawnIndex];

                bool candidateAccepted = false;
                for (int i = 0; i < numSampleBeforeRejection; i++)
                {
                    // Random angle
                    float angle = Random.value * Mathf.PI * 2;

                    // Random direction from angle
                    var dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

                    // Random point outside spawn centre's point
                    var candidate = spawnCentre + dir * Random.Range(radius, 2 * radius);

                    if (!IsValid(candidate, sampleRegionSize, cellSize, radius, points, grid)) continue;
                    
                    points.Add(candidate);
                    spawnPoints.Add(candidate);
                    grid[(int)(candidate.x / cellSize), (int)(candidate.y / cellSize)] = points.Count;
                    candidateAccepted = true;
                    
                    break;
                }

                // Remove spawn point if no candidate accepted
                if (!candidateAccepted)
                {
                    spawnPoints.RemoveAt(spawnIndex);
                }
            }

            return points;
        }

        private static bool IsValid(Vector2 candidate, Vector2 sampleRegionSize, float cellSize, float radius, IReadOnlyList<Vector2> points, int[,] grid)
        {
            if (!(candidate.x >= 0) ||
                !(candidate.x < sampleRegionSize.x) ||
                !(candidate.y >= 0) ||
                !(candidate.y < sampleRegionSize.y))
                return false;
            
            int cellX = (int)(candidate.x / cellSize);
            int cellY = (int)(candidate.y / cellSize);
            int searchStartX = Mathf.Max(0, cellX - 2);
            int searchStartY = Mathf.Max(0, cellY - 2);
            int searchEndX = Mathf.Min(cellX + 2, grid.GetLength(0) - 1);
            int searchEndY = Mathf.Min(cellY + 2, grid.GetLength(1) - 1);

            for (int x = searchStartX; x <= searchEndX; x++)
            {
                for (int y = searchStartY; y <= searchEndY; y++)
                {
                    int pointIndex = grid[x, y] - 1;
                    if (pointIndex == -1) continue;
                    
                    // As sqrMagnitude is cheaper then magnitude,
                    // we compare the squared distance between the candidate and the spawn point
                    // with the squared radius.
                    float sqrDst = (candidate - points[pointIndex]).sqrMagnitude;
                    if (sqrDst < radius * radius)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
