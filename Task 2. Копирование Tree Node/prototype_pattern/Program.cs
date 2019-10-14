using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prototype_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var NodeOne = new TreeNode()
            {
                Index = 0,
                Name = "NodeOne",
                UserInfo = new UserInfo { Age = 2, Name = "Name" }
            };

         
            INodePrototype NodeCloneOne = NodeOne.Clone(false);

            NodeCloneOne.Index = 1;
            NodeCloneOne.UserInfo.Age = 3;

            NodeOne.PrintAbout();
            ((TreeNode)NodeCloneOne).PrintAbout();


            //FULL DEEP COPY
            INodePrototype NodeCloneTwo = NodeOne.Clone(true);

            NodeCloneTwo.Index = 2;
            NodeCloneTwo.UserInfo.Age = 5;

            NodeOne.PrintAbout();
            ((TreeNode)NodeCloneTwo).PrintAbout();

            Console.ReadLine();
        }
    }
}
