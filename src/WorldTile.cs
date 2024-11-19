namespace Tower_Defence_Game.src
{
    internal class WorldTile
    {
        internal BaseDefendUnit DefendUnit {  get; set; }
        internal BaseAttackUnit AttackUnit { get; set; }

        internal WorldTile()
        {
            DefendUnit = null;
            AttackUnit = null;

        }

        public WorldTile(BaseDefendUnit defendUnit, BaseAttackUnit attackUnit)
        {
            DefendUnit = defendUnit;
            AttackUnit = attackUnit;

        }

        public override string ToString()
        {
            string output = "---";

            if (DefendUnit != null)
            {
                output = DefendUnit.ToString();

            }
            else if (AttackUnit != null)
            {
                output = AttackUnit.ToString();

            }

            return output;
        }

    }
}
