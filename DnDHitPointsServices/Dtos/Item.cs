namespace DnDHitPointsServices.Dtos
{
    public class Item
    {
        public string Name { get; set; }

        public ItemModifier Modifier { get; set; }

        public class ItemModifier
        {
            public string AffectedObject { get; set; }

            public string AffectedValue { get; set; }

            public int Value { get; set; }
        }
    }
}