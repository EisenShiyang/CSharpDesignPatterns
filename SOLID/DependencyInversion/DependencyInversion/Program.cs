using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    class Program
    {
        public class Research 
        {
            //public Research(Relationships relationships)
            //{
            //    var relations = relationships.Relations;
            //    foreach(var v in relations.Where(x => x.Item1.Name=="Hank" && x.Item2 == Relationship.Parent))
            //    {
            //        Console.WriteLine("Hank has a child called "+v.Item3.Name);
            //    }
            //}
            public Research(IRelationshipBrowser b)
            {
                foreach (var v in b.FindAllChildrenOf("Hank"))
                    Console.WriteLine("Hank has a child called " + v.Name);
            }
            static void Main(string[] args)
            {
                var parent = new Person { Name = "Hank" };
                var child1 = new Person { Name = "Candy" };
                var child2 = new Person { Name = "Candy2" };
                var relationships = new Relationships();
                relationships.AddParentAndChild(parent, child1);
                relationships.AddParentAndChild(parent, child2);
                new Research(relationships);
            }
        }
        public enum Relationship
        {
            Parent,
            Child,
            Sibling
        }
        public class Person
        {
            public string Name;
        }
        public interface IRelationshipBrowser
        {
            IEnumerable<Person> FindAllChildrenOf(string name);
        }
        public class Relationships : IRelationshipBrowser
        {
            private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
            public void AddParentAndChild(Person parent, Person child)
            {
                relations.Add((parent, Relationship.Parent, child));
                relations.Add((child, Relationship.Child, parent));
            }

            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                return relations.Where(x => x.Item1.Name==name && x.Item2 == Relationship.Parent).Select(r => r.Item3);
            }

            public List<(Person, Relationship, Person)> Relations => relations;

        }
    }
}
