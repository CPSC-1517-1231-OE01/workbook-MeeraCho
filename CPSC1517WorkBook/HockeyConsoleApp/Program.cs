using Hockey.Data;

Console.WriteLine("Welcome to the HockeyPlayer Test App");

//default constructor
HockeyPlayer player1 = new HockeyPlayer();
player1.FirstName = "Stewart";
player1.LastName = "Skinner";

//Object-initializer 결과는 default와 같음. 좀 더 간단 
HockeyPlayer player2 = new HockeyPlayer()
{
    FirstName = "Connor",
    LastName = "Brown",
};

//greedy Constructor 
HockeyPlayer player3 = new HockeyPlayer("Bobby", "orr", "Parry Sound, On", new DateOnly(1948, 3, 20), 196, 73, Position.Defense, Shot.Right);

//output things about the players 
Console.WriteLine($"The player's name is {player1.FirstName} {player1.LastName} and they are born {player1.DateOfBirth}.");
Console.WriteLine($"The player's name is {player2.FirstName} {player2.LastName} and they are born {player2.DateOfBirth}.");
Console.WriteLine($"The player's name is {player3.FirstName} {player3.LastName} and they are born {player3.DateOfBirth}.");

