using System;
using System.Collections.Generic;
using System.Text;

namespace BrainstormingApp.Model
{
    class IdeaList
    {
        public string word { get; set; }
    }
    class IdeaRoot
    {
        public List<IdeaList> responses;
    }
}
