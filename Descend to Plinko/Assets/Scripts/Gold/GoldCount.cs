using Assets.Scripts.Gold;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class GoldCount : MonoBehaviour
{
    [SerializeField] private Bank _bank;
    private TextMeshProUGUI _textMeshPro;
    private CeilGold _ceilGold;

    private void OnEnable()
    {
        _bank.GoldChanged += SetGoldCount;
    }

    private void OnDisable()
    {
        _bank.GoldChanged -= SetGoldCount;
    }

    private void Start()
    {
        _ceilGold = new CeilGold();
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text = _ceilGold.Ceil(_bank.GoldCount);
    }

    private void SetGoldCount(long count)
    {
        _textMeshPro.text = _ceilGold.Ceil(count);
    }
}