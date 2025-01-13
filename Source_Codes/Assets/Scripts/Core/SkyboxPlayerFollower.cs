using UnityEngine;

public class SkyboxPlayerFollower : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform'u
    public float parallaxFactor = 0.1f; // Parallax etkisi için çarpan
    private Material skyboxMaterial;

    void Start()
    {
        // Skybox Material'ını al
        skyboxMaterial = RenderSettings.skybox;
    }

    void Update()
    {
        // Oyuncunun pozisyonuna göre kaydırma işlemi
        Vector3 playerPosition = player.position;
        float offsetX = playerPosition.x * parallaxFactor;
        float offsetZ = playerPosition.z * parallaxFactor;

        // Skybox'ın offset değerlerini güncelle
        skyboxMaterial.SetFloat("_Rotation", offsetX);
        skyboxMaterial.SetFloat("_ParallaxOffset", offsetZ); // Shader'da buna karşılık gelen bir property olmalı,

        skyboxMaterial.SetFloat("_StarCollectionX", offsetX);
        skyboxMaterial.SetFloat("_StarCollectionY", offsetZ); // Shader'da buna karşılık gelen bir property olmalı
    }
}
