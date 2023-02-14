using UnityEngine;
using UnityEngine.EventSystems;

public class BuildTowerView : TowerSelection
{
    [SerializeField] private LayerMask _towerPlace;
    [SerializeField] private LayerMask _environment;

    [SerializeField] private Camera _camera;

    private float _maxRayDistance = 120f;
   
    private void LateUpdate()
    {
        OpenBuildViewWithTouch();
        HideBuildViewWithTouch();       
    }

    private void OpenBuildViewWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {               
                Ray ray = _camera.ScreenPointToRay(touch.position);
 
                if (Physics.Raycast(ray, _maxRayDistance, _towerPlace))
                {
                    _buildView.SetActive(true);
                    _buildView.transform.position = touch.position;                  
                }
            }
        }
    }
    
    private void HideBuildViewWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {               
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, _maxRayDistance, _towerPlace))
                    return;

                if (Physics.Raycast(ray, _maxRayDistance, _environment))
                {                                     
                    _buildView.SetActive(false);
                    ResetSelectionView();
                }
            }
        }
    }  
}
