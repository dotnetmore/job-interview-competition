using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace prototype_pattern
{
  [Serializable]
    public class TreeNode : INodePrototype
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public UserInfo UserInfo { get; set; }

        public INodePrototype Clone(bool isDeepCopy)
        {
            if (isDeepCopy)
            {
                return (INodePrototype)this.DeepCopy();
            }
            else
            {
                return (INodePrototype)this.MemberwiseClone();
            }
        }

        private object DeepCopy()
        {
            var binaryFormatter = new BinaryFormatter();
            var serializationStream = new MemoryStream();

            binaryFormatter.Serialize(serializationStream, this);
            serializationStream.Seek(0, SeekOrigin.Begin);

            return binaryFormatter.Deserialize(serializationStream);
        }

        public void PrintAbout()
        {
            Console.WriteLine($"Index={this.Index} Name={this.Name}  UserInfo.Age={this.UserInfo.Age}  UserInfo.Name={this.UserInfo.Name}");
        }

    }
}