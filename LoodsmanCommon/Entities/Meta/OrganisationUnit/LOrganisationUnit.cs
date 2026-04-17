using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LoodsmanCommon
{
  public abstract class LOrganisationUnit : Entity
  {
    internal LOrganisationUnit(DataRow dataRow) : base(dataRow.ID(), dataRow.NAME()) 
    {
      Children = Enumerable.Empty<LOrganisationUnit>();
    }

    public virtual LOrganisationUnit Parent { get; internal set; }
    public abstract OrganisationUnitKind Kind { get; }
    public virtual IEnumerable<LOrganisationUnit> Children { get; internal set; }

    /// <summary>Возвращает последовательность всех предков текущего узла (родитель, родитель родителя и т.д.).</summary>
    /// <remarks>
    /// Последовательность начинается с непосредственного родителя и поднимается вверх по дереву.
    ///<br/> Текущий узел (<c>this</c>) в результат не входит.
    ///<br/> Если у узла нет родителя, возвращается пустая последовательность.
    /// </remarks>
    public IEnumerable<LOrganisationUnit> Ancestors()
    {
      for (var n = Parent; n != null; n = n.Parent)
        yield return n;
    }

    /// <summary>Возвращает последовательность текущего узла и всех его предков.</summary>
    /// <remarks>Последовательность начинается с текущего узла, затем идет его родитель и далее вверх по дереву.</remarks>
    public IEnumerable<LOrganisationUnit> AncestorsAndSelf()
    {
      for (var n = this; n != null; n = n.Parent)
        yield return n;
    }

    /// <summary>Возвращает текущий узел и всех его потомков (обход в глубину, PreOrder).</summary>
    /// <remarks>
    /// Сначала возвращается текущий узел, затем рекурсивно все дочерние узлы.
    ///<br/> Используется обход дерева в глубину (PreOrder).
    /// </remarks>
    public IEnumerable<LOrganisationUnit> DescendantsAndSelf()
    {
      return TreeTraversal.PreOrder(Children, n => n.Children);
    }

    /// <summary>Возвращает всех потомков текущего узла (обход в глубину, PreOrder).</summary>
    /// <remarks>
    /// В отличие от <see cref="DescendantsAndSelf"/>, текущий узел не включается в результат.
    ///<br/> Обход выполняется в глубину (PreOrder).
    /// </remarks>
    public IEnumerable<LOrganisationUnit> Descendants()
    {
      return TreeTraversal.PreOrder(this, n => n.Children);
    }
  }
}