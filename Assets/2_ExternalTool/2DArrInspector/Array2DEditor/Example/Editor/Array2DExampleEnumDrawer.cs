using UnityEditor;
using ToronPuzzle.Data;
namespace Array2DEditor
{
    [CustomPropertyDrawer(typeof(Array2DExampleEnum))]
    public class Array2DExampleEnumDrawer : Array2DEnumDrawer<ExampleEnum> {}

    [CustomPropertyDrawer(typeof(Array2DModuleID))]
    public class Array2DModuleIDDrawer : Array2DEnumDrawer<ModuleID> {}
}
