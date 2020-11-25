using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : GameMenu_Base
{
    [SerializeField] private Button _restart;
    [SerializeField] private Button _backToMenu;
    [SerializeField] private PC_InputCrontroller _input;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _play.onClick.AddListener(OnMenuClicked);
        _restart.onClick.AddListener(OnRestartClicked);
        _backToMenu.onClick.AddListener(OnMainMenuClicked);
    }

    protected override void OnDestroy()
    {
        _play.onClick.RemoveListener(OnMenuClicked);
        _restart.onClick.RemoveListener(OnRestartClicked);
        _backToMenu.onClick.RemoveListener(OnMainMenuClicked);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyUp(KeyCode.Escape))
            OnMenuClicked();
    }

    protected override void OnMenuClicked()
    {
        base.OnMenuClicked();
        _input.StopPlay();
        Time.timeScale = _menu.activeInHierarchy ? 0 : 1;
    }

    public void OnMainMenuClicked()
    {
        ServiceManager.Instanse.ChangeLvl((int)Scenes.MainMenu);
    }

    private void OnRestartClicked()
    {
        _serviceManager.Restart();
    }
}