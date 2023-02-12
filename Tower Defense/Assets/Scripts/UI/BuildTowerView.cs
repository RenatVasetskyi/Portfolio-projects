using UnityEngine;

public class BuildTowerView : TowerSelection
{
    [SerializeField] private LayerMask _towerPlace;
    [SerializeField] private LayerMask _environment;

    [SerializeField] private Camera _camera;  

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

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.layer == 6)
                    {
                        _builView.gameObject.SetActive(true);
                        _builView.transform.position = touch.position;
                    }
                }
            }
        }
    }
    
    private void HideBuildViewWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Moved)
            {
                Ray ray = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.gameObject.layer == 7)
                    {
                        _builView.gameObject.SetActive(false);
                        ResetSelectionView();
                    }
                }
            }
        }
    }  
}
