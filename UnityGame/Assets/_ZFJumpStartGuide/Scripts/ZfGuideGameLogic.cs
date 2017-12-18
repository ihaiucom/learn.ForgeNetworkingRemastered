//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using BeardedManStudios.Forge.Networking.Generated;
//using BeardedManStudios.Forge.Networking;
//using UnityStandardAssets.Characters.FirstPerson;
//using System;
//using BeardedManStudios.Forge.Networking.Unity;
//using UnityEngine.UI;

//public class ZfGuideGameLogic : ZfGuideGameLogic
//{
//    public Text scoreLabel;
//    private void Start()
//    {
//        // This will be called on every client, so each client will essentially instantiate
//        // their own player on the network. We also pass in the position we want them to spawn at
//        NetworkManager.Instance.InstantiateZfGuidePlayer(position: new Vector3(0, 5, 0));
//    }

//    public override void UpdateName(RpcArgs args)
//    {
//        // Since there is only 1 argument and it is a string we can safely
//        // cast the first argument to a string knowing that it is going to
//        // be the name for the scoring player
//        string playerName = args.GetNext<string>();

//        // Update the UI to show the last player that scored
//        scoreLabel.text = "Last player to score was: " + playerName;
//    }

//}
