using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerSelection : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private Camera _camera;  

    [SerializeField] private GameObject _buildButton;

    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.layer == gameObject.layer)
                    {
                        _buildButton.gameObject.SetActive(true);
                        _buildButton.transform.position = touch.position;
                    }
                    else
                    {
                        _buildButton.gameObject.SetActive(false);
                    }
                }
            }
        }      
    }
}
