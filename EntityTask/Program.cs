using System;
using System.Collections.Generic;

namespace EntityTask
{
    class Program
    {
        static void Main()
        {
            List<Entity> list = new List<Entity>()
            {
                new Entity {Id = 1, ParentId = 0, Name = "Root entity"},
                new Entity {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
            };
            var res = Parents(list);
        }

        public static Dictionary<int, List<Entity>> Parents(List<Entity> list)
        {
            var dict = new Dictionary<int, List<Entity>>();
            foreach (var l in list)
            {
                if (!dict.ContainsKey(l.ParentId))
                {
                    dict.Add(l.ParentId, new List<Entity>());
                }
                dict[l.ParentId].Add(l);
            }
            return dict;
        }
    }

    public class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
}
