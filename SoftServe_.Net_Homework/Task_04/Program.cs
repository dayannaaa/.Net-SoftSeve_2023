
#region  Вводиться рядок слів. Вивести слова в зворотньому порядку.

/*string str = Console.ReadLine();
str = new string(str.Reverse().ToArray());
Console.WriteLine(str);

// це завдання виводить слова навпаки
*/
Console.WriteLine("------------TASK 1-----------");
Console.Write("Enter text: ");
string str = Console.ReadLine();
string[] words = str.Split(' ');
Console.Write("Result is: ");
for (int i = words.Length - 1; i >= 0; i--)
{
    Console.Write(words[i] + " ");
}
Console.ReadKey();
#endregion

#region Обрахувати кількість пробілів в рядку, яку введе користувач.
//Console.Write(str.Split(' ').Length.ToString());
Console.WriteLine("\n\n\n------------TASK 2-----------");
Console.Write("Enter a line:");
string line = Console.ReadLine();
int count = 0;
for (int i = 0; i < line.Length; i++)
{
    if (line[i] == ' ')
    {
        count++;
    }
}
Console.WriteLine("Number of spaces in a line: {0}", count);

#endregion

#region Дано текст.Визначте відсоткове відношення малих і великих літер до загальної кількості символів в ньому.
Console.WriteLine("\n\n\n------------TASK 3-----------");
Console.Write("Enter text: ");
string text = Console.ReadLine();
int lowerCase = 0;
int upperCase = 0;
int total = 0;
for (int i = 0; i < text.Length; i++)
{
    if (char.IsLower(text[i]))
    {
        lowerCase++;
    }
    else if (char.IsUpper(text[i]))
    {
        upperCase++;
    }
    total++;
}
Console.WriteLine("Lower case percentage: " + (lowerCase * 100 / total));
Console.WriteLine("Upper case percentage: " + (upperCase * 100 / total));
#endregion

#region Написати функцію, яка приймає словосполучення і перетворює його в абревіатуру.
Console.WriteLine("\n\n\n------------TASK 4-----------");

Console.Write("Enter a phrase:");
string phrase = Console.ReadLine();
string[] words_ = phrase.Split(' ');
string abbreviation = "";
foreach (string word in words_)
{
    abbreviation += word[0];
}
Console.WriteLine("Abbreviation: {0}", abbreviation);
Console.ReadKey();

#endregion

#region Сформувати з введених слів рядок, розділивши їх комою з пробілом.
Console.WriteLine("\n\n\n------------TASK 5-----------");
Console.WriteLine("Enter the number of words");
int n = int.Parse(Console.ReadLine());
string[] texts = new string[n];
for (int i = 0; i < n; i++)
{
    Console.WriteLine("Enter the word");
    texts[i] = Console.ReadLine();
}
string result = string.Join(", ", texts);
Console.WriteLine(result);
#endregion
