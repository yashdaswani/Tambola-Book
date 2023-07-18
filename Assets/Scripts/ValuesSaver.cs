using Personal;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Personal
{

public class ValuesSaver : MonoBehaviour
{
    public static ValuesSaver Instance;
    private void Awake()
    {
        Instance = this;
    }
    public List<Group> Groups = new List<Group>();
    public List<AllGroupsUI> AllGroups;
    public class AllGroupsUI
    {
        public string GroupName;
        public GameObject GroupDetails;
        public List<GameObject> PlayersLists;
    }
    public void UpdateGroupValues()
    {
        List<Group> NewGroups = new List<Group>();
        foreach (var group in AllGroups)
        {
            Group _tempgroup = new Group(group.GroupName);
            foreach(var players in group.PlayersLists)
            {
                Group.Player _player = new Group.Player();
                _player.playerName = players.transform.GetChild(0).name;


                _tempgroup.PlayerList.Add(_player);
            }
            NewGroups.Add(_tempgroup);
        }
        if(NewGroups != Groups)
        {
            Groups = NewGroups;
        }
    }
}
}
