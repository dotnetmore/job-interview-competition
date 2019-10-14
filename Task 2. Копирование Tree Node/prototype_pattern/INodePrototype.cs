using System.Dynamic;

namespace prototype_pattern
{
    public interface INodePrototype
    {

        int Index { get; set; }
        string Name { get; set; }

        UserInfo UserInfo { get; set; }

        INodePrototype Clone(bool isDeepCopi);
    }
}
