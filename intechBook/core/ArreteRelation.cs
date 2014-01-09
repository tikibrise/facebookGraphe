using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class ArreteRelation
    {
        public ArreteRelation(SommetPersonne orig, SommetPersonne dest, TypeRelation relation)
        {
            _orig = orig;
            _dest = dest;
            Relation = relation;
        }

        SommetPersonne _orig;
        SommetPersonne _dest;

        public SommetPersonne Orig { get { return _orig; } }
        public SommetPersonne Dest { get { return _dest; } }
        public TypeRelation Relation { get; set; }
    }
}

public enum  TypeRelation 
{
    AMI=1,
    COLLEGUE=2,
    CAMARADE=3,
    BUSINESS=4
};