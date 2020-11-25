using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [Header("Soul Score")]
    [SerializeField] private TextMeshProUGUI _uiAmountSoul;
    [SerializeField] private float _hpPerSoul;

    [Header("UI Key")]
    [SerializeField] private GameObject _uiKey;

    private Player_Controller _player;
    private Health_Controller _playerHP;
    private GraveController _crate;
    public int _amountSouls = 0;
    int _maxSouls = 9999999;
    bool _key = false;
    bool _canOpenCrate = true;

    private void Start()
    {
        _amountSouls = PlayerPrefs.GetInt("Soul_Score");
        _uiAmountSoul.SetText(_amountSouls.ToString());
        _player = GetComponent<Player_Controller>();
        _playerHP = GetComponent<Health_Controller>();
    }

    #region Soul
    public void AddSoul(int num)
    {
        _amountSouls += num;
        _uiAmountSoul.SetText(_amountSouls.ToString());
    }

    public int GetSoul()
    {
        return _amountSouls;
    }

    public void Heal()
    {
        if (_amountSouls <= 0)
            return;

        _amountSouls -= 5;
        _uiAmountSoul.SetText(_amountSouls.ToString());
        _playerHP.RestoreHP(_hpPerSoul * 5);
    }
    #endregion

    #region Crate
    public void SetCanOpenCrate(bool can)
    {
        _canOpenCrate = can;
    }

    public bool GetCanOpenCrate()
    {
        return _canOpenCrate;
    }

    public void Crate(GraveController crate)
    {
        _crate = crate;
    }
    public void OpenCrate()
    {
        _crate.TakeSoul();
    }
    #endregion

    #region Key
    public bool HasKey()
    {
        return _key;
    }

    public void TakeKey()
    {
        _uiKey.SetActive(true);
        _key = true;
    }    
    #endregion
}
