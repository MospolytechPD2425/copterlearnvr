using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Details.Connections
{
    public class Connections : MonoBehaviour
    {
        [SerializeField] private List<Connection> _connections = new();
        public void Add(Connection connection)
        {
            _connections.Add(connection);
        }
        public void Remove(ContactPoint point)
        {
            var item = _connections.FirstOrDefault(c => c.ContactPoint1 == point || c.ContactPoint2 == point);
            if (item.ContactPoint1 == null && item.ContactPoint2 == null)
            {
                _connections.Remove(item);
            }
        }
        public bool Check(Connection connection)
        {
            var con = _connections.FirstOrDefault(c => 
                c.ContactPoint1 == connection.ContactPoint1 || c.ContactPoint1 == connection.ContactPoint2 &&
                c.ContactPoint2 == connection.ContactPoint2 || c.ContactPoint2 == connection.ContactPoint1);
            if (con != null)
            {
                return true;
            }
            return false;
        }
        public bool ContainsContactPoint(ContactPoint point)
        {
            foreach (Connection connection in _connections)
            {
                if (connection.ContactPoint1 ==  point || connection.ContactPoint2 == point)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
