using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{ 
    [SerializeField] private WarningPopup warningPopup; 
    public WarningPopup WarningPopup { get { return warningPopup; } private set { } }

    [SerializeField] private GameUIController gameUI;
    public GameUIController GameUI { get { return gameUI; } private set { } }
}
