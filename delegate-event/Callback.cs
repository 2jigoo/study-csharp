using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_event
{

    delegate int GetResultDelegate();

    class Target
    {
        public void Do(GetResultDelegate getResult)
        {
            Console.WriteLine(getResult());
        }
    }

    class Source
    {
        public int getResult()
        {
            return 10;
        }

        public void Test()
        {
            Target target = new Target();
            target.Do(new GetResultDelegate(this.getResult));
        }
    }
}
