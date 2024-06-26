using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgSearchTransitiveClosure
{
    public class Graph
    {
        int countVers;
        int countEdges;
        List<List<int>> adj;
        bool dir;

        public Graph()
        {
            adj = new List<List<int>>();
            countEdges = -1;
            countVers = -1;
            dir = false;
        }

        public int CountVers { get { return countVers; } set { countVers = value; } }
        public int CountEdges { get { return countEdges; } set { countEdges = value; } }
        public bool Dir { get { return dir; } set { dir = value; } }
        public List<List<int>> Adj { get { return adj; } set { adj = value; } }

    }
}
