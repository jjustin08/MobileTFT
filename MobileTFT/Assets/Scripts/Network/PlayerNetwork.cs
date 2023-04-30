using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] private Transform spawnedObjectPrefab;
    private Transform spawnedTransform;
    private PlayerInputActions playerInputActions ;
    private WaitForFixedUpdate dragFixedUpdate = new WaitForFixedUpdate();


    private NetworkVariable<Vector2> NetworkPos = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        NetworkPos.Value = transform.position;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Press.performed += click;

       
    }



    void Update()
    {
        if(!IsOwner)
            return;


        //if(Input.GetMouseButton(0))
        //{
        //    Vector3 mousePosition = Input.mousePosition;
        //    mousePosition.z = Camera.main.nearClipPlane; // Set the z position to the near clip plane of the camera
        //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);


        //    NetworkPos.Value = worldPosition;
        //    TransformServerRpc(new ServerRpcParams());
            
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    TestClientRpc(new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new List<ulong> { 1 } } });
        //    SpawnPrefabServerRpc(new ServerRpcParams());
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    DestryPrefabServerRpc(new ServerRpcParams());

        //}

    }

    public void click(InputAction.CallbackContext context)
    {
        if (!IsOwner)
            return;

        

        StartCoroutine(dragUpdate(context));
        

        //TestClientRpc(new ClientRpcParams { Send = new ClientRpcSendParams { TargetClientIds = new List<ulong> { 1 } } });
        // SpawnPrefabServerRpc(new ServerRpcParams());

        
        
    }

    private IEnumerator dragUpdate(InputAction.CallbackContext context)
    {
        while(context.ReadValueAsButton())
        {
            Vector2 position = playerInputActions.Player.TouchPosition.ReadValue<Vector2>();

            position = Camera.main.ScreenToWorldPoint(position);

            NetworkPos.Value = position;
            TransformServerRpc(new ServerRpcParams());

            yield return dragFixedUpdate;
        }
        
    }

    public Vector3 getNetPosition()
    {

        return NetworkPos.Value;
    }

    // runs functions on server
    [ServerRpc]
    private void TransformServerRpc(ServerRpcParams param)
    {
        transform.position = NetworkPos.Value;
    }
    
    [ServerRpc]
    private void SpawnPrefabServerRpc(ServerRpcParams param)
    {
        spawnedTransform = Instantiate(spawnedObjectPrefab);
        spawnedTransform.GetComponent<NetworkObject>().Spawn(true);
    } 
    
    [ServerRpc]
    private void DestryPrefabServerRpc(ServerRpcParams param)
    {
        Destroy(spawnedTransform.gameObject);
    }
    // runs functions on client
    [ClientRpc]
    private void TestClientRpc(ClientRpcParams param)
    {
        print("sup");
    }
}
