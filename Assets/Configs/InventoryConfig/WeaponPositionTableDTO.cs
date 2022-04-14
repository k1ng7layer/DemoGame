using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    CHIBI,
    NORMAL_HUMAN,
}
public enum WeaponType
{
    SWORD,
    AXE,
    SPEAR,
    STAFF,
}
[CreateAssetMenu(fileName ="new_weapon_config", menuName = "Configs/WeaponPositionTableDTO")]
public class WeaponPositionTableDTO : ScriptableObject
{
    [SerializeField] CharacterType _characterType;
    [SerializeField] WeaponType _weaponType;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private Vector3 _armedPosition;
    [SerializeField] private Vector3 _defaultRotation;
    [SerializeField] private Vector3 _armedRotation;
    [SerializeField] private Vector3 _defaultScale;
    [SerializeField] private Vector3 _armedScale;
    public CharacterType CharacterModelType => _characterType;
    public WeaponType WeaponType => _weaponType;
    public Vector3 DefaultPosition => _defaultPosition;
    public Vector3 ArmedPosition => _armedPosition;
    public Vector3 DefaultRotation => _defaultRotation;
    public Vector3 ArmedRotation => _armedRotation;
    public Vector3 DefaultScale => _defaultScale;
    public Vector3 ArmedScale => _armedScale;
}


