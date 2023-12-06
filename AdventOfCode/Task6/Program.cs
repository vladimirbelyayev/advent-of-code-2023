// (15 - t) * t > 40 where t is time spent winding up the boat
// -t^2 + 15t - 40 > 0
// t^2 - 15t + 40 < 0

// standard quadratic form,  ax^2 + bx + c  = 0
// quadratic formula, x = (-b +/- sqrt(b^2 - 4ac)) / 2a
// t = x (just a naming change, to closer represent time - t (ms))

// t1 = (15 + sqrt((-15)^2 - 4 * 1 * 40)) / (2 * 1)
// t2 = (15 - sqrt((-15)^2 - 4 * 1 * 40)) / (2 * 1)

// t1 = 11.5
// t2 = 3.5

// 3.5 < t < 11.5

// tDelta = t1-t2 = 8 (tDelta is all the possible seconds which you can hold to win the race)

// Task inputs
// Time:        54     70     82     75
// Distance:   239   1142   1295   1253

// To see how much margin of error you have, determine the number of ways you can beat the record in each race; in this example, if you multiply these values together, you get 288 (4 * 8 * 9).
// Determine the number of ways you could beat the record in each race. What do you get if you multiply these numbers together?
// If you multiply the numbers together you get all possible outcomes how you can win the race


var inputs = new[]
{
    54, 239,
    70, 1142,
    82, 1295,
    75, 1253
};

var numberOfWaysToBeatRecords = new List<long>();

for (var i = 0; i < 4 * 2; i += 2)
{
    var availTimeForRace = inputs[i]; // available total time for the race
    var recordDistance = inputs[i + 1]; //record distance for the race

    var tDelta = CalculatetDelta(availTimeForRace, recordDistance);
    numberOfWaysToBeatRecords.Add(tDelta);
}

var allPossibleWaysToWin = numberOfWaysToBeatRecords.Aggregate((a, b) => a * b);

Console.WriteLine($"All possible ways (combinations) how to win the races: {allPossibleWaysToWin}");

//Part 2.
string totalTimeForRaceStr = "";
string totalRecordDistanceStr = "";
for (var i = 0; i < 4 * 2; i += 2)
{
    totalTimeForRaceStr += inputs[i];// available total time for the race
    totalRecordDistanceStr += inputs[i + 1]; //record distance for the race
}

Console.WriteLine($"Time: {totalTimeForRaceStr}");
Console.WriteLine($"Distance: {totalRecordDistanceStr}");
CalculatetDelta(long.Parse(totalTimeForRaceStr), long.Parse(totalRecordDistanceStr));

Console.ReadKey();
return;


long CalculatetDelta(long availTimeForRace, long recordDistance)
{
    long b = availTimeForRace;
    long c = recordDistance;

    var t1 = (b + Math.Sqrt(Math.Pow(-1 * b, 2) - 4 * c)) / 2;
    var t2 = (b - Math.Sqrt(Math.Pow(-1 * b, 2) - 4 * c)) / 2;

    Console.WriteLine($"{t2} < t < {t1}");
    Console.WriteLine($"Where value of t is millisecond which will win the race");

    var tDelta = (long) Math.Floor(t1) - (long) Math.Floor(t2);
    Console.WriteLine($"Possible options of seconds to choose from, how long to wind up the boat, to beat current record (tDelta): {tDelta}");

    return tDelta;
}