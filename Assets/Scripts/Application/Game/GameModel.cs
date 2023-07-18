namespace HangedMan
{
    public class GameModel : UIModel
    {
        private readonly GameConfiguration configuration;

        private WordProvider wordProvider;

        public WordProvider WordProvider => wordProvider;
        public GameConfiguration Configuration => configuration;

        public GameModel(GameConfiguration configuration)
        {
            this.configuration = configuration;
            wordProvider = new WordProvider(configuration);
        }

    }
}