using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire_For_Discord.Net.Command {

    public class QueCommand : ModuleBase {

        [Command("que", RunMode = RunMode.Async)]
        public async Task Que(params string[] msg) {
            if(msg.Length < 3) {
                await ReplyAsync("むり");
                return;
            }

            if (msg.Length > 21) {
                await ReplyAsync("まじでむり");
                return;
            }

            IEmote[] emotes = new IEmote[msg.Length -1];

            var embed = new EmbedBuilder();
            embed.WithTitle(msg[0]);
            embed.WithAuthor(Context.User.Username, Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl());
            embed.WithColor(Color.Blue);
            embed.WithTimestamp(DateTime.Now);

            var description = "";
            foreach (var str in msg.Select((value, index) => new { value, index })) {
                if (str.index == 0) continue;
                var emoji = EmojiManager.Get(str.index-1);
                description += new Emoji(emoji).ToString() + str.value + "\n";
                emotes[str.index - 1] = new Emoji(emoji);
            }

            embed.WithDescription(description);
            await Context.Channel.SendMessageAsync(embed: embed.Build()).GetAwaiter().GetResult().AddReactionsAsync(emotes);
        }
    }
}