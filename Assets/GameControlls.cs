// GENERATED AUTOMATICALLY FROM 'Assets/GameControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControlls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""42ea79d5-3e50-44dd-bca5-9e43ab7862f7"",
            ""actions"": [
                {
                    ""name"": ""Scalling"",
                    ""type"": ""Button"",
                    ""id"": ""39733f45-2637-4b9d-883e-b0dfe0fe28de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ed727c0-d87d-4348-b225-b40e4086f21d"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scalling"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Scalling = m_Movement.FindAction("Scalling", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Scalling;
    public struct MovementActions
    {
        private @GameControlls m_Wrapper;
        public MovementActions(@GameControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scalling => m_Wrapper.m_Movement_Scalling;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Scalling.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnScalling;
                @Scalling.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnScalling;
                @Scalling.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnScalling;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scalling.started += instance.OnScalling;
                @Scalling.performed += instance.OnScalling;
                @Scalling.canceled += instance.OnScalling;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    public interface IMovementActions
    {
        void OnScalling(InputAction.CallbackContext context);
    }
}
