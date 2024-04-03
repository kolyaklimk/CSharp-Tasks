using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Text.RegularExpressions;

class Lab6
{
    static void Main(string[] args)
    {
        var newCode = AddUnreachableCode("Input.cs");
        File.WriteAllText("Output.cs", newCode);
        newCode = AddDeadCode("Output.cs");
        File.WriteAllText("Output.cs", newCode);
        string code = File.ReadAllText("Output.cs");
        newCode = RenameVariables(code);
        newCode = AddRandomSpacesAndTabs(newCode);

        File.WriteAllText("Output.cs", newCode);
    }

    static string RenameVariables(string code)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
        var root = tree.GetRoot();

        var rewriter = new VariableRenamer();
        var newRoot = rewriter.Visit(root);

        return newRoot.ToFullString();
    }

    class VariableRenamer : CSharpSyntaxRewriter
    {
        public List<string> words = new List<string>
{
    "apple", "banana", "orange", "pear", "grape",
    "dog", "cat", "rabbit", "hamster", "bird",
    "car", "truck", "bicycle", "motorcycle", "bus",
    "house", "apartment", "villa", "cottage", "mansion",
    "book", "magazine", "newspaper", "journal", "novel",
    "computer", "phone", "tablet", "laptop", "keyboard",
    "chair", "table", "sofa", "bed", "desk",
    "lamp", "mirror", "clock", "painting", "vase",
    "guitar", "drum", "violin", "trumpet", "piano",
    "pen", "pencil", "marker", "eraser", "notebook",
    "flower", "tree", "grass", "bush", "flowerpot",
    "shoe", "boot", "sandal", "slipper", "sneaker",
    "shirt", "pants", "dress", "skirt", "jacket",
    "hat", "glove", "scarf", "tie", "belt",
    "bag", "backpack", "purse", "wallet", "suitcase",
    "umbrella", "raincoat", "jumpsuit", "shorts", "socks",
    "glasses", "sunglasses", "bracelet", "necklace", "ring",
    "watch", "earrings", "headphones", "microphone", "speaker",
    "television", "remote", "projector", "screen", "antenna",
    "radio", "cassette", "CD", "DVD", "Bluray",
    "speaker", "microphone", "guitar", "piano", "violin",
    "drum", "trumpet", "clarinet", "flute", "accordion",
    "globe", "map", "compass", "binoculars", "telescope",
    "microscope", "thermometer", "scale", "measuringtape", "ruler",
    "compass", "protractor", "calculator", "abacus", "computer",
    "camera", "phone", "tablet", "laptop", "watch",
    "flashlight", "candle", "lantern", "torch", "lamp",
    "knife", "fork", "spoon", "chopsticks", "plate",
    "bowl", "cup", "mug", "glass", "pitcher",
    "bottle", "jar", "can", "box", "bag",
    "basket", "tray", "drawer", "shelf", "hook",
    "nail", "screw", "bolt", "nut", "washer",
    "hammer", "saw", "drill", "pliers", "screwdriver",
    "wrench", "axe", "knife", "scissors", "razor",
    "comb", "brush", "mirror", "soap", "shampoo",
    "conditioner", "lotion", "perfume", "deodorant", "toothbrush",
    "toothpaste", "floss", "mouthwash", "towel", "washcloth",
    "sponge", "bucket", "mop", "broom", "vacuum",
    "dustpan", "detergent", "bleach", "vinegar", "fabricsoftener",
    "cleaner", "polish", "wax", "disinfectant", "antibacterial",
    "soap", "shampoo", "conditioner", "lotion", "perfume",
    "deodorant", "toothbrush", "toothpaste", "floss", "mouthwash",
    "towel", "washcloth", "sponge", "bucket", "mop",
    "broom", "vacuum", "dustpan", "detergent", "bleach",
    "vinegar", "fabricsoftener", "cleaner", "polish", "wax",
    "disinfectant", "antibacterial", "handsanitizer", "shower", "bathtub",
    "sink", "toilet", "faucet", "drain", "mirror",
    "showercurtain", "soapdish", "toothbrushholder", "towelrack", "shelving",
    "cabinet", "drawer", "medicinecabinet", "toiletpaper",
    "almond", "applepie", "apricot", "artichoke", "asparagus",
"avocado", "bacon", "bagel", "bakedbeans", "baklava",
"bamboo", "barbecue", "basil", "bison", "blackberry",
"blueberry", "bokchoy", "broccoli", "brownie", "brusselsprouts",
"burrito", "butter", "cabbage", "cake", "calamari",
"cantaloupe", "caramel", "carrot", "cashew", "casserole",
"celery", "cheese", "cherry", "chicken", "chili",
"chocolate", "chowder", "cinnamon", "clam", "cobbler",
"coconut", "coffee", "corn", "crab", "cranberry",
"cucumber", "cupcake", "curry", "date", "donut",
"dumpling", "eggplant", "fig", "flan", "fondue",
"fudge", "garlic", "ginger", "gnocchi", "granola",
"grapefruit", "guacamole", "hamburger", "hazelnut", "honey",
"horseradish", "hotdog", "hummus", "icecream", "jelly",
"kale", "kiwi", "lamb", "lasagna", "lemon",
"lemonade", "lentil", "lettuce", "leek", "licorice",
"lime", "lobster", "macaroni", "mango", "margarine",
"marshmallow", "mayonnaise", "meatball", "meatloaf", "melon",
"meringue", "milk", "milkshake", "muffin", "mushroom",
"mustard", "noodle", "nutmeg", "oatmeal", "olive",
"omelette", "onion", "oyster", "pancake", "papaya",
"parsley", "parsnip", "pasta", "pastry", "peach",
"peanut", "peanutbutter", "peas", "pecan", "pepper",
"persimmon", "pickle", "pie", "pineapple", "pizza",
"plum", "popcorn", "poppyseed", "potato", "pretzel",
"pumpkin", "quiche", "quinoa", "radish", "raisin",
"rhubarb", "rice", "risotto", "salad", "salmon",
"salsa", "salt", "sandwich", "sausage", "scallop",
"scrambledegg", "seaweed", "sesame", "sherbet", "shrimp",
"soup", "soysauce", "spinach", "squash", "steak",
"strawberry", "sugar", "sushi", "sweetpotato", "swisschard",
"taco", "tangerine", "tapenade", "tart", "tea",
"toast", "toffee", "tomato", "truffle", "tuna",
"turkey", "turnip", "vanilla", "vegemite", "vegetable",
"vinegar", "waffle", "walnut", "wasabi", "watermelon",
"whippedcream", "wine", "yogurt", "zucchini"
};

        private Dictionary<string, string> variableMap = new Dictionary<string, string>();
        private Random random = new Random();

        public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            foreach (var variable in node.Declaration.Variables)
            {
                string oldName = variable.Identifier.ValueText;
                string newName = words[new Random().Next(0, 400)];
                variableMap[oldName] = newName;
            }

            return base.VisitLocalDeclarationStatement(node);
        }

        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (token.IsKind(SyntaxKind.IdentifierToken) && variableMap.ContainsKey(token.ValueText))
            {
                return SyntaxFactory.Identifier(token.LeadingTrivia, variableMap[token.ValueText], token.TrailingTrivia);
            }

            return base.VisitToken(token);
        }

        private string GetRandomVariableName()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int length = random.Next(5, 20);
            return new string(System.Linq.Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    static string AddRandomSpacesAndTabs(string code)
    {
        Regex regex = new Regex(@"[ \t]+");

        Random random = new Random();

        string ReplaceMatch(Match match)
        {
            int length = match.Length;
            int numSpaces = random.Next(1, 50);
            int numTabs = random.Next(1, 10);
            return new string(' ', numSpaces) + new string('\t', numTabs);
        }

        string modifiedCode = regex.Replace(code, ReplaceMatch);
        return modifiedCode;
    }

    static string GetRandomName(int length)
    {
        Random r = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        char[] buffer = new char[length];

        for (int i = 0; i < length; i++)
        {
            buffer[i] = chars[r.Next(chars.Length)];
        }

        return new string(buffer);
    }

    static string AddUnreachableCode(string input)
    {
        StringBuilder stringBuilder = new();
        using (StreamReader sr = new StreamReader(input))
        {
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();

                stringBuilder.Append(line);
                stringBuilder.Append("\n");

                if (line.Trim() == "break;" || line.Trim() == "return;")
                {
                    stringBuilder.Append(GenerateRandomInitializations(1).First());
                }
            }
        }

        return stringBuilder.ToString();
    }
    static string AddDeadCode(string input)
    {
        StringBuilder stringBuilder = new();
        using (StreamReader sr = new StreamReader(input))
        {
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();

                if (Regex.IsMatch(line.Trim(), @"^if(.+)$"))
                {
                    Random r = new Random();
                    var randomValue = r.Next() % 10;
                    if (randomValue < 3)
                    {
                        stringBuilder.AppendLine($"string {GetRandomName(randomValue + 7)} = \"Critical string that can change all programm!\";");
                    }
                    else if (randomValue < 6)
                    {
                        stringBuilder.AppendLine($"int {GetRandomName(randomValue + 2)} = {r.Next() % 4123} - 423 + 532 * 53;");
                    }
                    else
                    {
                        stringBuilder.AppendLine($"double {GetRandomName(5)} = 645 / 1123 * 643 / 43532;");
                    }
                    sr.Peek();
                }
                stringBuilder.AppendLine(line);
            }
        }

        return stringBuilder.ToString();
    }

    static List<string> GenerateRandomInitializations(int count)
    {
        List<string> initializations = new List<string>();

        for (int i = 0; i < count; i++)
        {
            string initialization = GenerateRandomInitialization();
            initializations.Add(initialization);
        }

        return initializations;
    }

    static string GenerateRandomInitialization()
    {
        Random random = new Random();

        Type[] types = { typeof(int), typeof(double), typeof(float), typeof(string), typeof(bool) };

        Type randomType = types[random.Next(types.Length)];

        string variableName = "var" + random.Next(1000);

        string value = GenerateRandomValue(randomType);

        string initialization = $"{randomType.Name} {variableName} = {value};";

        return initialization;
    }

    static string GenerateRandomValue(Type type)
    {
        Random random = new Random();

        if (type == typeof(int))
        {
            return random.Next().ToString();
        }
        else if (type == typeof(double))
        {
            return random.NextDouble().ToString();
        }
        else if (type == typeof(float))
        {
            return ((float)random.NextDouble()).ToString();
        }
        else if (type == typeof(string))
        {
            return $"\"{GetRandomName(15)}\"";
        }
        else if (type == typeof(bool))
        {
            return (random.Next(2) == 0).ToString().ToLower();
        }
        else
        {
            throw new ArgumentException("Unsupported type");
        }
    }

}
