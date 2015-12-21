using GameOnlineTutorial.Interfaces;

namespace GameOnlineTutorial.Item
{
    public abstract class Item : IItem
    {
        public string itemName { get; }
        public int healingEffect { get; }
        public int permenentDmgBoost { get; }
        public int permenentDefBoost { get; }
        public int permenentHealthBoost { get; }
    }
}
