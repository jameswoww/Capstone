// GENERATED AUTOMATICALLY FROM 'Assets/__Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Ps4"",
            ""id"": ""ed0701e4-1e4d-480a-9ad6-b479a20929e0"",
            ""actions"": [
                {
                    ""name"": ""buttonSouth"",
                    ""type"": ""Button"",
                    ""id"": ""a06c7982-bd7a-4642-b75e-eac3524098f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""leftStick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""25c720bd-3985-4e9c-8728-44f5b8be9662"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4166204f-56e5-4035-acbd-42fce37b182d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Ps4"",
                    ""action"": ""buttonSouth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63fdb8bd-8b29-40a3-bcb3-b6b2de8948be"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""leftStick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""c8300afc-1137-4f47-ae12-936148476526"",
            ""actions"": [
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""e78fc7e8-7c25-412b-ae17-3e4f2e63caf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""a332bf88-472f-4c81-a8c8-01843f73c110"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""dd83621a-a8fa-484a-bf49-65dc5716210c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""ff6da4de-9bce-40f0-ae38-e1dae382f8ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""796841f8-9ed6-4aa4-96ed-04acdeeed83b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""431fc95a-0178-4e56-aa05-7af68236b446"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q"",
                    ""type"": ""Button"",
                    ""id"": ""888b0df7-8e7a-48b1-bc83-9dde6e7e5a56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""51645d11-268f-4a35-bba5-6b9a29ee56c3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe66b118-1d93-4796-86d4-01bf316f6337"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74b35214-56cb-48b9-97f8-103c1f770517"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f6130298-b996-415e-af50-d1c42d012f10"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""995a86ff-63ad-4619-80dc-54d232914d1a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc7f0b3a-d8ae-4acc-b521-b0ad59d18151"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""56c5105e-1220-4bb0-ab64-ec1e578b5931"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ps4
        m_Ps4 = asset.FindActionMap("Ps4", throwIfNotFound: true);
        m_Ps4_buttonSouth = m_Ps4.FindAction("buttonSouth", throwIfNotFound: true);
        m_Ps4_leftStick = m_Ps4.FindAction("leftStick", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_W = m_Keyboard.FindAction("W", throwIfNotFound: true);
        m_Keyboard_A = m_Keyboard.FindAction("A", throwIfNotFound: true);
        m_Keyboard_S = m_Keyboard.FindAction("S", throwIfNotFound: true);
        m_Keyboard_D = m_Keyboard.FindAction("D", throwIfNotFound: true);
        m_Keyboard_Space = m_Keyboard.FindAction("Space", throwIfNotFound: true);
        m_Keyboard_E = m_Keyboard.FindAction("E", throwIfNotFound: true);
        m_Keyboard_Q = m_Keyboard.FindAction("Q", throwIfNotFound: true);
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

    // Ps4
    private readonly InputActionMap m_Ps4;
    private IPs4Actions m_Ps4ActionsCallbackInterface;
    private readonly InputAction m_Ps4_buttonSouth;
    private readonly InputAction m_Ps4_leftStick;
    public struct Ps4Actions
    {
        private @Controls m_Wrapper;
        public Ps4Actions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @buttonSouth => m_Wrapper.m_Ps4_buttonSouth;
        public InputAction @leftStick => m_Wrapper.m_Ps4_leftStick;
        public InputActionMap Get() { return m_Wrapper.m_Ps4; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Ps4Actions set) { return set.Get(); }
        public void SetCallbacks(IPs4Actions instance)
        {
            if (m_Wrapper.m_Ps4ActionsCallbackInterface != null)
            {
                @buttonSouth.started -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnButtonSouth;
                @buttonSouth.performed -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnButtonSouth;
                @buttonSouth.canceled -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnButtonSouth;
                @leftStick.started -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnLeftStick;
                @leftStick.performed -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnLeftStick;
                @leftStick.canceled -= m_Wrapper.m_Ps4ActionsCallbackInterface.OnLeftStick;
            }
            m_Wrapper.m_Ps4ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @buttonSouth.started += instance.OnButtonSouth;
                @buttonSouth.performed += instance.OnButtonSouth;
                @buttonSouth.canceled += instance.OnButtonSouth;
                @leftStick.started += instance.OnLeftStick;
                @leftStick.performed += instance.OnLeftStick;
                @leftStick.canceled += instance.OnLeftStick;
            }
        }
    }
    public Ps4Actions @Ps4 => new Ps4Actions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_W;
    private readonly InputAction m_Keyboard_A;
    private readonly InputAction m_Keyboard_S;
    private readonly InputAction m_Keyboard_D;
    private readonly InputAction m_Keyboard_Space;
    private readonly InputAction m_Keyboard_E;
    private readonly InputAction m_Keyboard_Q;
    public struct KeyboardActions
    {
        private @Controls m_Wrapper;
        public KeyboardActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @W => m_Wrapper.m_Keyboard_W;
        public InputAction @A => m_Wrapper.m_Keyboard_A;
        public InputAction @S => m_Wrapper.m_Keyboard_S;
        public InputAction @D => m_Wrapper.m_Keyboard_D;
        public InputAction @Space => m_Wrapper.m_Keyboard_Space;
        public InputAction @E => m_Wrapper.m_Keyboard_E;
        public InputAction @Q => m_Wrapper.m_Keyboard_Q;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @W.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @A.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @S.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @D.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
                @Space.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnSpace;
                @E.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnE;
                @Q.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQ;
                @Q.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQ;
                @Q.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnQ;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
                @Q.started += instance.OnQ;
                @Q.performed += instance.OnQ;
                @Q.canceled += instance.OnQ;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IPs4Actions
    {
        void OnButtonSouth(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnW(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void OnE(InputAction.CallbackContext context);
        void OnQ(InputAction.CallbackContext context);
    }
}
