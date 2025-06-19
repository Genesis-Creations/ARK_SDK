using UnityEngine;

public class ArkSettings : ScriptableObject
{
    [SerializeField] private string graphqlUrl;

    public string GraphQLUrl => graphqlUrl;
}