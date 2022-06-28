namespace ImportantPrototype.Mutations
{
    public class DefaultGenotypeMod : GenotypeMod
    {
        public override string GetDescription() => "None";
        protected override void OnApply(ref Mutation mutation) { }
    }
}