using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu_Base : MonoBehaviour
{
    protected ServiceManager _serviceManager;
    [SerializeField] protected GameObject _menu;


    [Header("MainButtons")]
    [SerializeField] protected Button _play;
    [SerializeField] protected Button _quit;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        _serviceManager = ServiceManager.Instanse;
        _quit.onClick.AddListener(OnQuitClicked);
    }

    protected virtual void OnDestroy()
    {
        _quit.onClick.RemoveListener(OnQuitClicked);
    }

    protected virtual void Update() { }

    protected virtual void OnMenuClicked()
    {
        _menu.SetActive(!_menu.activeInHierarchy);
    }

    private void OnQuitClicked()
    {
        _serviceManager.Quit();
    }
}
