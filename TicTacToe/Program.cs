char[][] Board = new char[3][];
Board[0] = new char[] { '1', '2', '3' };
Board[1] = new char[] { '4', '5', '6' };
Board[2] = new char[] { '7', '8', '9' };

char Circle = 'o';
char X = 'x';

Console.WriteLine("Welcome to my Tic-Tac-Toe game :)");
Console.WriteLine("Player 1 will be assigned to shape: O");
Console.WriteLine("Player 2 will be assigned to shape: X");
Console.WriteLine("Player 1 may now choose: Pick a number from 1 to 9");

PrintBoard();

for (int turns = 0; turns < 9; turns++)
{
    while (Place(turns % 2, GetInput()) == false)
    {
        Console.WriteLine("Sorry, that spot is already taken. Try again!");
    }

    PrintBoard();

    if (Check())
    {
        Console.WriteLine($"Player_{(turns % 2) + 1} won! :D");
        return;
    }
}

Console.WriteLine("Tie!");

int GetInput()
{
    string UserInput = Console.ReadLine();

    int result;

    while (int.TryParse(UserInput, out result) == false || result < 1 || result > 9)
    {
        Console.WriteLine("Invalid number. Try again.");
        UserInput = Console.ReadLine();
    }
    return result;
}

void PrintBoard()
{
    ConsoleColor currentColor = Console.BackgroundColor;
    ConsoleColor currentShapeColor = Console.ForegroundColor;
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.WriteLine($"{Board[0][0]} {Board[0][1]} {Board[0][2]}");

    Console.WriteLine($"{Board[1][0]} {Board[1][1]} {Board[1][2]}");

    Console.WriteLine($"{Board[2][0]} {Board[2][1]} {Board[2][2]}");

    Console.WriteLine();

    Console.BackgroundColor = currentColor;
    Console.ForegroundColor = currentShapeColor;
}

//If bool returns true if it succeeds, false if there is already a shape there
bool Place(int player, int board)
{
    int x = 0;
    int y = 0;

    if (board == 1)
    {
        y = 0;
        x = 0;
    }
    else if (board == 2)
    {
        y = 0;
        x = 1;
    }
    else if (board == 3)
    {
        y = 0;
        x = 2;
    }
    else if (board == 4)
    {
        y = 1;
        x = 0;
    }
    else if (board == 5)
    {
        y = 1;
        x = 1;
    }
    else if (board == 6)
    {
        y = 1;
        x = 2;
    }
    else if (board == 7)
    {
        y = 2;
        x = 0;
    }
    else if (board == 8)
    {
        y = 2;
        x = 1;
    }
    else if (board == 9)
    {
        y = 2;
        x = 2;
    }

    // If board already has a circle/x in the specific coordinate, it will return as false.
    if (Board[y][x] == Circle || Board[y][x] == X)
    {
        return false;
    }

    if (player == (int)Players.Player_1)
    {
        Board[y][x] = Circle;
    }
    else
    {
        Board[y][x] = X;
    }
    return true;
}

bool CheckHorizontal()
{
    if (Board[0][0] == Board[0][1] && Board[0][1] == Board[0][2] && Board[0][2] != ' ')
    {
        return true;
    }
    if (Board[1][0] == Board[1][1] && Board[1][1] == Board[1][2] && Board[1][2] != ' ')
    {
        return true;
    }
    if (Board[2][0] == Board[2][1] && Board[2][1] == Board[2][2] && Board[2][2] != ' ')
    {
        return true;
    }
    return false;
}
bool CheckVertical()
{
    if (Board[0][0] == Board[1][0] && Board[1][0] == Board[2][0] && Board[2][0] != ' ')
    {
        return true;
    }
    if (Board[0][1] == Board[1][1] && Board[1][1] == Board[2][1] && Board[2][1] != ' ')
    {
        return true;
    }
    if (Board[0][2] == Board[1][2] && Board[1][2] == Board[2][2] && Board[2][2] != ' ')
    {
        return true;
    }
    return false;
}
bool CheckDiagonal()
{
    if (Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2] && Board[2][2] != ' ')
    {
        return true;
    }
    if (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0] && Board[2][0] != ' ')
    {
        return true;
    }
    return false;
}

bool Check()
{
    return CheckHorizontal() || CheckVertical() || CheckDiagonal();
}

enum Players : int
{
    Player_1 = 0,
    Player_2 = 1,
}
