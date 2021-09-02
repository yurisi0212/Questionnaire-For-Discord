namespace Questionnaire_For_Discord.Net {
    public class TokenManager {

        public TokenManager() {
            DiscordToken = "";
        }

        public string DiscordToken { get; private set; }
    }
}