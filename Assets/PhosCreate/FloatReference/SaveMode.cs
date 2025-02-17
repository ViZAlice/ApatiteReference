namespace PhosCreate.FloatReference
{
    internal abstract class SaveMode
    {
        
    }

    internal class NoSave: SaveMode{}
    internal class AsSettings: SaveMode{}
    internal class InSlot: SaveMode{}
}