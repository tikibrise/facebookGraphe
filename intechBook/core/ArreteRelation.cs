using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    class ArreteRelation
    {
        ArreteRelation(int orig, int dest, TypeRelation relation)
        {
            _orig = orig;
            _dest = dest;
            _relation = relation;
        }

        int _orig;
        int _dest;

        TypeRelation _relation;
    }
}

enum  TypeRelation 
{
    AMI=1,
    COLLEGUE=2
};