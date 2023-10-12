using DSharpPlus;
using DSharpPlus.CommandsNext;
using dcAllahBot.config;
using System.Threading.Tasks;
using dcAllahBot.commands;

namespace dcAllahBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; } 
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();


            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);
            //5. Set up the Task Handler
            Client.Ready += Client_Ready;
           // Client.MessageCreated += MessageCreatedHandler;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                EnableDms =true,
                EnableDefaultHelp = false
            };
            //7. Register commands
            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<basicCommands>();

            //8. Connect to get the Bot online
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

       /* private static async Task MessageCreatedHandler(DiscordClient sender, DSharpPlus.EventArgs.MessageCreateEventArgs e)
        {
           // if(e.Channel.GetMessagesAsync().ToString == "allah")
            await e.Channel.SendMessageAsync("OK?");
        }*/

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}




