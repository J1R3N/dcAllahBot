using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace dcAllahBot.commands
{
    public class basicCommands : BaseCommandModule
    {
        [Command("bomb")]
        public async Task AllahWords(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Allah Uakbar!!! {ctx.User.Username} wird in 5 Sekunden weggebombt");
        }

        [Command("allah")]
        public async Task allah(CommandContext ctx)
        {

        }
        
    }
}
