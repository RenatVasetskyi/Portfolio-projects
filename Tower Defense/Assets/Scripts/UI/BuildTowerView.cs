using UnityEngine;

public class BuildTowerView : TowerSelection
{
    [SerializeField] private LayerMask _towerPlace;
    [SerializeField] private LayerMask _environment;

    [SerializeField] private Camera _camera;  

    [SerializeField] private GameObject _buildButton;

    private void LateUpdate()
    {                   
        OpenBuildView();
        HideBuildView();       
    }

    private void OpenBuildView()
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
                        _buildButton.gameObject.SetActive(true);
                        _buildButton.transform.position = touch.position;
                    }
                }
            }
        }
    }

    private void HideBuildView()
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
                        _buildButton.gameObject.SetActive(false);
                        ResetSelectionView();
                    }
                }
            }
        }
    }  
}
