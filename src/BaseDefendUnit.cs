namespace Tower_Defence_Game.src
{
    internal class BaseDefendUnit
    {
        public override string ToString()
        {
            return "-T-";
        }

    }

    internal class AttackProjectileSingle : BaseDefendUnit
    {
        public override string ToString()
        {
            return "APS";
        }

    }

    internal class AttackHitscanSingle : BaseDefendUnit
    {
        public override string ToString()
        {
            return "AHS";
        }

    }

}
