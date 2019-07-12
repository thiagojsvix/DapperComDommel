using System;
using Dommel;

namespace Queries.App.Extesion
{
    public class CustomTableNameResolver : DommelMapper.ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
            return type.Name;
        }
    }
}
