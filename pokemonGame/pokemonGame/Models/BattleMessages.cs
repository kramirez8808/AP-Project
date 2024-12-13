using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemonGame.Models
{
    public class BattleMessages
    {
        public const string TITLE = "Bienvenido a la Batalla Pokemon";

        public static class MessageKey
        {
            public static string STRIKE = "Strike";
            public static string HEALTH_DECREASE = "HealthDecrease";
            public static string WINNER = "Winner";
            public static string LOSER = "Loser";
            public static string INTERACTION = "Interaction";
        }

        public static string GetRandomMessage(string category, Dictionary<string, string> variables)
        {
            if (!Messages.ContainsKey(category))
                throw new ArgumentException("Invalid message category.");

            var templates = Messages[category];
            var template = templates[Random.Next(templates.Count)];

            foreach (var variable in variables)
            {
                template = template.Replace($"{{{variable.Key}}}", variable.Value);
            }

            return template;
        }
        private static readonly Random Random = new Random();

        private static readonly Dictionary<string, List<string>> Messages = new Dictionary<string, List<string>>
    {
        { MessageKey.STRIKE, new List<string> {
            "{attacker} strikes {defender} with {move}! It's super effective!",
            "{attacker} used {move} on {defender}! {defender} looks shaken!",
            "{attacker} attacked {defender} with {move}, dealing massive damage!",
            "{attacker} launched {move} at {defender}! It's a critical hit!",
        }},
        { MessageKey.HEALTH_DECREASE, new List<string> {
            "{defender} lost {amount} HP!",
            "{defender}'s health dropped by {amount} points!",
            "{defender} is barely standing with {amount} HP lost!",
            "{defender} looks exhausted, losing {amount} HP!",
        }},
        { MessageKey.WINNER, new List<string> {
            "{winner} emerges victorious! What an incredible battle!",
            "{winner} has won the match! {loser} was no match!",
            "The winner is {winner}! {loser} has fainted!",
            "{winner} reigns supreme! Congratulations!",
        }},
        { MessageKey.LOSER, new List<string> {
            "{loser} has fainted! Better luck next time!",
            "{loser} is unable to continue!",
            "{loser} has been defeated. It's over for now!",
            "{loser} lost the match! What a tough loss!",
        }},
        { MessageKey.INTERACTION, new List<string> {
            "{pokemon1} and {pokemon2} seem to be sizing each other up!",
            "{pokemon1} looks curious about {pokemon2}!",
            "{pokemon1} and {pokemon2} are preparing for a face-off!",
            "{pokemon1} is cautiously watching {pokemon2}!",
        }},
    };
    }
}