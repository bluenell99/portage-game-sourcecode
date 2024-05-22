using UnityEngine;

public static class TerrainMaterialUtility
{
    private static float[] GetTextureMix(Vector3 playerPositition, Terrain terrain)
    {
        Vector3 terrainPosition = terrain.transform.position;
        TerrainData terrainData = terrain.terrainData;
        int mapX = Mathf.RoundToInt((playerPositition.x - terrainPosition.x) / terrainData.size.x * terrainData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerPositition.z - terrainPosition.z) / terrainData.size.z * terrainData.alphamapHeight);

        float[,,] splatMapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);

        float[] cellMix = new float[splatMapData.GetUpperBound(2) + 1];

        for (int i = 0; i < cellMix.Length; i++)
        {
            cellMix[i] = splatMapData[0, 0, i];
        }

        return cellMix;

    }

    public static TerrainLayer GetLayerName(Vector3 playerPosition, Terrain terrain)
    {
        float[] cellMix = GetTextureMix(playerPosition, terrain);
        float strongest = 0;
        int maxIndex = 0;

        for (int i = 0; i < cellMix.Length; i++)
        {
            if (cellMix[i] > strongest)
            {
                maxIndex = i;
                strongest = cellMix[i];
            }
        }

        return terrain.terrainData.terrainLayers[maxIndex];
    }
    
}
