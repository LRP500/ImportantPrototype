namespace ImportantPrototype.System
{
    public static class ContextMenuPath
    {
        public const string Root = GameInfo.Title + "/";
        public const string Stats = Root + "Stats/";
        public const string Managers = Root + "Managers/";
        public const string Characters = Root + "Characters/";
        public const string Items = Root + "Items/";
        public const string Weapons = Root + "Weapons/";
        public const string WeaponsFiringModes = Weapons + "Firing Modes/";
        public const string WeaponShotBehaviours = Weapons + "Weapon Shot Behaviours/";
        public const string ProjectileBehaviours = Weapons + "Projectile Behaviours/";
        public const string Familiars = Root + "Familiars/";
        public const string FamiliarBehaviours = Familiars + "Behaviours/";
        public const string Mutations = Root + "Mutations/";
        public const string GenotypeMods = Root + "Genotype Mods/";
        

        public const string Content = Root + "Content/";
        
        private const string Collections = Root + "Collections/";
        public const string AssetLists = Collections + "Asset Lists/";

        private const string ECA = Root + "ECA/";
        public const string Actions = ECA + "Actions/";
        public const string LevelUpActions = Actions + "Level Up/";

        private const string Tools = Root + "Tools/";
        public const string Console = Tools + "Console/";
        public const string ConsoleCommands = Console + "Commands/";
    }
}