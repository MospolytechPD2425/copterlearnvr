using Details.Connections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ContactPoint = Details.Connections.ContactPoint;

namespace Details.Connections
{
    [System.Serializable]
    public class Connection
    {
        [SerializeField] private ContactPoint contactPoint1;
        [SerializeField] private ContactPoint contactPoint2;

        public ContactPoint ContactPoint1 { get => contactPoint1; }
        public ContactPoint ContactPoint2 { get => contactPoint2; }

        public Connection(ContactPoint point1, ContactPoint point2)
        {
            contactPoint1 = point1;
            contactPoint2 = point2;
        }
    }
}