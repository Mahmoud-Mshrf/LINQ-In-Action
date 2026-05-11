using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_Shared
{
    public class QuestionComparer:IComparer<Question>
    {
        public int Compare(Question? x, Question? y)
        {
            if (x.Marks == y.Marks)
                return x.Title.CompareTo(y.Title);
            else
                return x.Marks.CompareTo(y.Marks);
        }
    }
}
