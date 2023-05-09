using UnityEngine;

public class wrongPlatforms : MonoBehaviour
{
    public level3 _level3;
    public bool isOnLevel3;
    
    public Color newColor; // цвет, на который нужно изменить материал платформы.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Renderer platformRenderer = GetComponent<Renderer>();

            if (platformRenderer != null)
            {
                Material platformMaterial = platformRenderer.material;

                if (platformMaterial != null)
                {
                    platformMaterial.color = newColor; // Меняем цвет материала на новый.
                }
            }
        }
    }
}
