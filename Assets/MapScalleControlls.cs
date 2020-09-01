// GENERATED AUTOMATICALLY FROM 'Assets/MapScalleControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MapScalleControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MapScalleControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MapScalleControlls"",
    ""maps"": [
        {
            ""name"": ""Map"",
            ""id"": ""42ea79d5-3e50-44dd-bca5-9e43ab7862f7"",
            ""actions"": [
                {
                    ""name"": ""StartScale"",
                    ""type"": ""Button"",
                    ""id"": ""39733f45-2637-4b9d-883e-b0dfe0fe28de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""StopScale"",
                    ""type"": ""Button"",
                    ""id"": ""348f8af6-7440-4871-8acf-b6dcf9ab91a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""0720b917-5d51-4d4b-9652-661783111394"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartScale"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7feb9789-3509-401b-b9ec-4024ac6277d5"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""9ebb7797-8af9-4823-b2f9-65c44ac34b09"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""7c8667eb-3d3f-40c6-a84d-8824e07b3062"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopScale"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""56b6c546-e1db-4dbd-a539-392223967592"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f2029c9b-07c7-424f-babc-bdff0935e378"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopScale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_StartScale = m_Map.FindAction("StartScale", throwIfNotFound: true);
        m_Map_StopScale = m_Map.FindAction("StopScale", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_StartScale;
    private readonly InputAction m_Map_StopScale;
    public struct MapActions
    {
        private @MapScalleControlls m_Wrapper;
        public MapActions(@MapScalleControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartScale => m_Wrapper.m_Map_StartScale;
        public InputAction @StopScale => m_Wrapper.m_Map_StopScale;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @StartScale.started -= m_Wrapper.m_MapActionsCallbackInterface.OnStartScale;
                @StartScale.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnStartScale;
                @StartScale.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnStartScale;
                @StopScale.started -= m_Wrapper.m_MapActionsCallbackInterface.OnStopScale;
                @StopScale.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnStopScale;
                @StopScale.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnStopScale;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartScale.started += instance.OnStartScale;
                @StartScale.performed += instance.OnStartScale;
                @StartScale.canceled += instance.OnStartScale;
                @StopScale.started += instance.OnStopScale;
                @StopScale.performed += instance.OnStopScale;
                @StopScale.canceled += instance.OnStopScale;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    public interface IMapActions
    {
        void OnStartScale(InputAction.CallbackContext context);
        void OnStopScale(InputAction.CallbackContext context);
    }
}
