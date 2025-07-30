using UnityEngine;

public class SnowBrush : MonoBehaviour
{
      private static readonly int DrawPosition = Shader.PropertyToID("_DrawPosition");
      
      [SerializeField] private CustomRenderTexture _snowMap;
      [SerializeField] private Material _showMaterial;
      
      private Camera _mainCamera;
      
      private void Start()
      {
            _snowMap.Initialize();
            _mainCamera = Camera.main;
      }

      private void Update()
      {
            if (!Input.GetMouseButton(0)) 
                  return;
            
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
                  _showMaterial.SetVector(DrawPosition, hit.textureCoord); 
      }
}
